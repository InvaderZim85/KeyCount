using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyCount.Data;
using KeyCount.DataObjects;
using KeyCount.DataObjects.Import;
using Microsoft.EntityFrameworkCore;
using ZimLabs.TableCreator;
using Timer = System.Timers.Timer;

namespace KeyCount.Business
{
    /// <summary>
    /// Provides several functions
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// Occurs when the stats are updated
        /// </summary>
        public event EventHandler<StatsEntry?>? StatsUpdated;

        /// <summary>
        /// The instance for the interaction with the database
        /// </summary>
        private readonly AppDbContext _context = new();

        /// <summary>
        /// The queue which contains the keys
        /// </summary>
        private readonly ConcurrentQueue<Keys> _keyQueue = new();

        /// <summary>
        /// The thread which consumes the <see cref="_keyQueue"/>
        /// </summary>
        private Thread? _queueThread;

        /// <summary>
        /// Contains the value which indicates if the stop was requested
        /// </summary>
        private bool _stopRequested;

        /// <summary>
        /// Contains the timer which updates the stats every minute
        /// </summary>
        private Timer? _statsTimer;

        /// <summary>
        /// Creates a new instance of the <see cref="DataManager"/>
        /// </summary>
        public DataManager()
        {
            _context.Database.EnsureCreated();
        }

        #region Queue / Timer
        /// <summary>
        /// Starts the queue consumer
        /// </summary>
        public void Start()
        {
            _queueThread = new Thread(ConsumeQueue);
            _queueThread.Start();

            _statsTimer = new Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
            _statsTimer.Elapsed += async (_, _) =>
            {
                var stats = await LoadStatsAsync();
                StatsUpdated?.Invoke(this, stats);
            };

            _statsTimer.Start();
        }

        /// <summary>
        /// Stops the queue consumer
        /// </summary>
        public void Stop()
        {
            _stopRequested = true;
            _statsTimer?.Stop();
        }

        /// <summary>
        /// Adds the key to the queue
        /// </summary>
        /// <param name="key">The key which should be added to the queue</param>
        public void AddToQueue(Keys key)
        {
            _keyQueue.Enqueue(key);
        }

        /// <summary>
        /// Consumes the queue
        /// </summary>
        private async void ConsumeQueue()
        {
            while (!_stopRequested)
            {
                while (!_keyQueue.IsEmpty)
                {
                    while (_keyQueue.TryDequeue(out var entry))
                        await AddKeyAsync(entry);
                }

                // Wait 500 milliseconds before the next try
                Thread.Sleep(500); 
            }
        }
        #endregion

        #region Loading methods
        /// <summary>
        /// Loads the day list 
        /// </summary>
        /// <returns>The list with the day entries</returns>
        public async Task<List<DayKeyCount>> LoadDayListAsync()
        {
            return await _context.DayCounts.AsNoTracking().OrderByDescending(o => o.Day).ToListAsync();
        }

        /// <summary>
        /// Loads the key list 
        /// </summary>
        /// <returns>The list with the keys</returns>
        public async Task<List<KeyListEntry>> LoadKeyListAsync()
        {
            return await _context.KeyList.AsNoTracking().OrderBy(o => o.KeyCode).ToListAsync();
        }

        /// <summary>
        /// Loads the previous count
        /// </summary>
        /// <returns>The previous count</returns>
        public async Task<int> LoadPreviousCountAsync()
        {
            var yesterday = DateTime.Now.AddDays(-1);
            var entry = await _context.DayCounts.FirstOrDefaultAsync(f => f.Day.Date == yesterday.Date);
            return entry?.Count ?? 0;
        }

        /// <summary>
        /// Loads the count of the current day
        /// </summary>
        /// <returns>The count of the current date</returns>
        public async Task<int> LoadTodayCountAsync()
        {
            var entry = await _context.DayCounts.FirstOrDefaultAsync(f => f.Day.Date == DateTime.Now.Date);
            return entry?.Count ?? 0;
        }

        /// <summary>
        /// Loads the statistics
        /// </summary>
        /// <returns>The statistics</returns>
        public async Task<StatsEntry?> LoadStatsAsync()
        {
            if (!_keyQueue.IsEmpty)
                return null;

            var result = new StatsEntry();

            if (await _context.DayCounts.AnyAsync())
            {
                var maxEntry = await _context.DayCounts.AsNoTracking().OrderByDescending(o => o.Count)
                    .FirstOrDefaultAsync();
                var average = await _context.DayCounts.AsNoTracking().AverageAsync(a => a.Count);

                result.MaxKeyCount = $"{maxEntry.Count:N0} - {maxEntry.Day:dd.MM.yyyy}";
                result.AverageKeyCount = average.ToString("N0");
            }

            if (await _context.KeyList.AnyAsync())
            {
                var mostUsedKey = await _context.KeyList.AsNoTracking().OrderByDescending(o => o.Count)
                    .FirstOrDefaultAsync();
                var leastUsedKey = await _context.KeyList.AsNoTracking().OrderBy(o => o.Count).FirstOrDefaultAsync();

                result.MostUsedKey = $"{mostUsedKey.Key} - {mostUsedKey.Count:N0}";
                result.LeastUsedKey = $"{leastUsedKey.Key} - {leastUsedKey.Count:N0}";
            }

            return result;
        }
        #endregion

        #region Various
        /// <summary>
        /// Prepares the lists
        /// </summary>
        /// <returns>The awaitable task</returns>
        public async Task PrepareListAsync()
        {
            if (!await _context.DayCounts.AnyAsync())
                return;

            var tmpDate = await _context.DayCounts.AsNoTracking().MinAsync(m => m.Day);
            var maxDate = await _context.DayCounts.AsNoTracking().MaxAsync(m => m.Day);

            while (tmpDate < maxDate)
            {
                if (await _context.DayCounts.AllAsync(a => a.Day.Date != tmpDate.Date))
                    await _context.DayCounts.AddAsync(new DayKeyCount
                    {
                        Day = tmpDate.Date
                    }); // Add a "empty" entry

                tmpDate = tmpDate.AddDays(1);
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a key to the list
        /// </summary>
        /// <param name="key"></param>
        /// <returns>The awaitable task</returns>
        private async Task AddKeyAsync(Keys key)
        {
            // Day count
            var today = await _context.DayCounts.FirstOrDefaultAsync(f => f.Day.Date == DateTime.Now.Date);
            if (today == null)
            {
                await _context.DayCounts.AddAsync(new DayKeyCount
                {
                    Day = DateTime.Now.Date,
                    Count = 1
                });
            }
            else
            {
                today.Count++;
            }

            // Key list
            var keyListEntry = await _context.KeyList.FirstOrDefaultAsync(f => f.KeyCode == (int)key);
            if (keyListEntry == null)
            {
                await _context.KeyList.AddAsync(new KeyListEntry
                {
                    KeyCode = (int)key,
                    Key = key.ToString(),
                    Count = 1
                });
            }
            else
            {
                keyListEntry.Count++;
            }

            await _context.SaveChangesAsync();
        }
        #endregion

        #region Import
        /// <summary>
        /// Imports a list of day key entries
        /// </summary>
        /// <param name="values">The list with the values</param>
        /// <returns>The awaitable task</returns>
        public async Task ImportCountListAsync(List<DayCountDto> values)
        {
            foreach (var entry in values.Where(w => w.Count != 0)) // Ignore "empty" entries...
            {
                var dayEntry = await _context.DayCounts.FirstOrDefaultAsync(f => f.Day.Date == entry.Date.Date);
                if (dayEntry != null)
                    continue;

                var newEntry = new DayKeyCount
                {
                    Day = entry.Date,
                    Count = entry.Count
                };

                Debug.WriteLine(newEntry.CreateValueList());

                await _context.DayCounts.AddAsync(newEntry);
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Imports a list of keys
        /// </summary>
        /// <param name="values">The list with the keys</param>
        /// <returns>The awaitable task</returns>
        public async Task ImportKeyListAsync(List<KeyListEntry> values)
        {
            foreach (var entry in values)
            {
                var keyEntry = await _context.KeyList.FirstOrDefaultAsync(f => f.KeyCode == entry.KeyCode);
                if (keyEntry != null)
                {
                    keyEntry.Count = entry.Count;
                }
                else
                {
                    await _context.KeyList.AddAsync(new KeyListEntry
                    {
                        KeyCode = entry.KeyCode,
                        Key = entry.Key,
                        Count = entry.Count
                    });
                }
            }

            await _context.SaveChangesAsync();
        }
        #endregion

        /// <summary>
        /// Finalizes the data manager (in case of some errors)
        /// </summary>
        ~DataManager()
        {
            if (_stopRequested)
                return;

            Stop();
        }
    }
}
