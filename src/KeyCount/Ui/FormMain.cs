using System;
using System.Windows.Forms;
using KeyCount.Business;
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
        /// Occurs when the form was loaded
        /// </summary>
        /// <param name="sender">The <see cref="FormMain"/></param>
        /// <param name="e">The event arguments</param>
        private async void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Init the manager
                await _manager.PrepareListAsync();

                // Add the event to the hook
                _hook.KeyUp += Hook_KeyUp;
                // Start the hook
                _hook.Start();

                // Load the count of today
                _todayCount = await _manager.LoadTodayCountAsync();
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
        private async void Hook_KeyUp(object? sender, KeyEventArgs e)
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

                // Add the key...
                await _manager.AddKeyAsync(e.KeyCode);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Can't save key data.");
            }
        }
    }
}
