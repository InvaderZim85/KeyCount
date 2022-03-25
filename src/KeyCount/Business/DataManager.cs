using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyCount.Data;
using KeyCount.DataObjects;
using KeyCount.DataObjects.Import;
using Microsoft.EntityFrameworkCore;

namespace KeyCount.Business
{
    /// <summary>
    /// Provides several functions
    /// </summary>
    internal class DataManager
    {
        /// <summary>
        /// The instance for the interaction with the database
        /// </summary>
        private readonly AppDbContext _context = new();

        /// <summary>
        /// Loads the day list 
        /// </summary>
        /// <returns>The list with the day entries</returns>
        public async Task<List<DayKeyCount>> LoadDayListAsync()
        {
            return await _context.DayCounts.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Loads the key list 
        /// </summary>
        /// <returns>The list with the keys</returns>
        public async Task<List<KeyListEntry>> LoadKeyListAsync()
        {
            return await _context.KeyList.AsNoTracking().ToListAsync();
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
        /// Prepares the lists
        /// </summary>
        /// <returns>The awaitable task</returns>
        public async Task PrepareListAsync()
        {
            var tmpDate = await _context.DayCounts.AsNoTracking().MinAsync(m => m.Day);
            var maxDate = await _context.DayCounts.AsNoTracking().MaxAsync(m => m.Day);

            while (tmpDate < maxDate)
            {
                if (await _context.DayCounts.AllAsync(a => a.Day.Date != tmpDate.Date))
                    await _context.DayCounts.AddAsync(new DayKeyCount()); // Add a "empty" entry

                tmpDate = tmpDate.AddDays(1);
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a key to the list
        /// </summary>
        /// <param name="key"></param>
        /// <returns>The awaitable task</returns>
        public async Task AddKeyAsync(Keys key)
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

        /// <summary>
        /// Imports a list of day key entries
        /// </summary>
        /// <param name="values">The list with the values</param>
        /// <returns>The awaitable task</returns>
        public async Task ImportCountListAsync(List<DayCountDto> values)
        {
            foreach (var entry in values)
            {
                var dayEntry = await _context.DayCounts.FirstOrDefaultAsync(f => f.Day.Date == entry.Date.Date);
                if (dayEntry != null)
                    continue;

                await _context.DayCounts.AddAsync(new DayKeyCount
                {
                    Day = entry.Date,
                    Count = entry.Count
                });
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
                    continue;

                await _context.KeyList.AddAsync(new KeyListEntry
                {
                    KeyCode = entry.KeyCode,
                    Key = entry.Key,
                    Count = entry.Count
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
