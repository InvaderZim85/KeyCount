using System;
using System.Linq;
using System.Windows.Forms;
using KeyCount.Business;
using KeyCount.DataObjects;
using KeyCount.Global;
using Serilog;

namespace KeyCount.Ui
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// The instance of the keyboard hook
        /// </summary>
        private readonly GlobalKeyboardHook _hook = new();

        /// <summary>
        /// The instance of the data manager
        /// </summary>
        private readonly DataManager _manager = new();

        /// <summary>
        /// Contains the previous count
        /// </summary>
        private int _previousCount;

        /// <summary>
        /// Contains the count of today
        /// </summary>
        private int _todayCount;

        /// <summary>
        /// Contains the start date (needed for day changes)
        /// </summary>
        private DateTime _startDate;

        /// <summary>
        /// Creates a new instance of the <see cref="FormMain"/>
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the data
        /// </summary>
        private void ShowData()
        {
            // Show the data
            var percentage = 0d;
            if (_previousCount > 0)
                percentage = 100d / _previousCount * _todayCount;

            Text = $"KeyCount - {DateTime.Now:dd.MM.yyyy} - {_todayCount:N0}";
            textBoxCurrent.Text = percentage > 0
                ? $"{_todayCount:N0} ({percentage:N2}%)"
                : _todayCount.ToString("N0");

            textBoxPrevious.Text = _previousCount.ToString("N0");

            // Set the progress bar
            if (_previousCount == 0 || _previousCount < _todayCount)
            {
                // Reset the progress bar, because we have no previous data
                progressBar.Value = 0;
            }
            else
            {
                progressBar.Maximum = _previousCount;
                progressBar.Value = _todayCount;
            }

            // Set the taskbar
            Helper.SetTaskbarProgress(_previousCount, _todayCount);
        }

        /// <summary>
        /// Sets / shows the statistics
        /// </summary>
        /// <param name="stats">The statistics</param>
        private void SetStats(StatsEntry? stats)
        {
            if (stats == null)
                return;

            BeginInvoke((MethodInvoker)delegate
            {
                groupBoxStatistics.Text = $"Statistics (last update: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";

                // Clear the controls
                foreach (var textBox in groupBoxStatistics.Controls.OfType<TextBox>())
                {
                    textBox.Clear();
                }

                textBoxLeastUsedKey.Text = stats.LeastUsedKey;
                textBoxMostUsedKey.Text = stats.MostUsedKey;
                textBoxStatsAverage.Text = stats.AverageKeyCount;
                textBoxStatsMax.Text = stats.MaxKeyCount;
            });
        }

        /// <summary>
        /// Occurs when the form was loaded
        /// </summary>
        /// <param name="sender">The <see cref="FormMain"/></param>
        /// <param name="e">The event arguments</param>
        private async void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Start the queue thread
                _manager.Start();

                // Add the stats event
                _manager.StatsUpdated += (_, stats) =>
                {
                    SetStats(stats);
                };

                // Set the start date
                _startDate = DateTime.Now;

                // Init the manager
                await _manager.PrepareListAsync();

                // Add the event to the hook
                _hook.KeyUp += Hook_KeyUp;
                // Start the hook
                _hook.Start();

                // Load the previous and the current count
                _previousCount = await _manager.LoadPreviousCountAsync();
                _todayCount = await _manager.LoadTodayCountAsync();

                // Load the stats
                var stats = await _manager.LoadStatsAsync();
                SetStats(stats);
            }
            catch (Exception ex)
            {
                ex.ShowLogError();
            }
        }

        /// <summary>
        /// Occurs when a key was pressed
        /// </summary>
        /// <param name="sender">The sender (<see cref="_hook"/>)</param>
        /// <param name="e">The key</param>
        /// <exception cref="NotImplementedException"></exception>
        private void Hook_KeyUp(object? sender, KeyEventArgs e)
        {
            try
            {
                // Check if the date has changed
                if (_startDate.Date < DateTime.Now.Date) // Day was changed
                {
                    // Switch the counts
                    _previousCount = _todayCount;
                    _todayCount = 0;
                    // Reset the start date
                    _startDate = DateTime.Now;
                }

                // Update the current count
                _todayCount++;

                // Add the key...
                _manager.AddToQueue(e.KeyCode);

                ShowData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Can't save key data.");
            }
        }

        /// <summary>
        /// Occurs when the form is closing
        /// </summary>
        /// <param name="sender">The <see cref="FormMain"/></param>
        /// <param name="e">The close event arguments</param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hook.Stop();

            _manager.Stop();
        }

        /// <summary>
        /// Occurs when the user hits the close button
        /// </summary>
        /// <param name="sender">The <see cref="buttonExit"/></param>
        /// <param name="e">The event arguments</param>
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Occurs when the user hits the show data button
        /// </summary>
        /// <param name="sender">The <see cref="buttonShowData"/></param>
        /// <param name="e">The event arguments</param>
        private void ButtonShowData_Click(object sender, EventArgs e)
        {
            var statsForm = new FormStats(_manager);
            statsForm.ShowDialog();
        }

        /// <summary>
        /// Occurs when the form was first shown
        /// </summary>
        /// <param name="sender">The <see cref="FormMain"/></param>
        /// <param name="e">The event arguments</param>
        private void FormMain_Shown(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
