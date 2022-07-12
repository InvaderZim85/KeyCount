using System;
using System.Windows.Forms;
using KeyCount.Business;
using KeyCount.DataObjects;
using KeyCount.Global;
using ZimLabs.TableCreator;

namespace KeyCount.Ui
{
    public partial class FormStats : Form
    {
        /// <summary>
        /// The instance of the data manager
        /// </summary>
        private readonly DataManager _manager;

        /// <summary>
        /// Creates a new instance of the <see cref="FormStats"/>
        /// </summary>
        /// <param name="manager"></param>
        public FormStats(DataManager manager)
        {
            InitializeComponent();

            _manager = manager;
        }

        /// <summary>
        /// Loads and shows the data
        /// </summary>
        private async void LoadShowData()
        {
            Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                var keyCountList = await _manager.LoadDayListAsync();
                var keyList = await _manager.LoadKeyListAsync();

                keyCountList.BindToSource(sourceKeyCount);
                keyList.BindToSource(sourceKeyList);
            }
            catch (Exception ex)
            {
                ex.ShowLogError();
            }
            finally
            {
                Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Occurs when the form was loaded
        /// </summary>
        /// <param name="sender">The <see cref="FormStats"/></param>
        /// <param name="e">The event arguments</param>
        private void FormStats_Load(object sender, EventArgs e)
        {
            LoadShowData();
        }

        /// <summary>
        /// Occurs when the user hits one of the import buttons
        /// </summary>
        /// <param name="sender">The <see cref="buttonKeyCountImport"/> or <see cref="buttonKeyListImport"/></param>
        /// <param name="e">The event arguments</param>
        private async void ButtonImport_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select the file which should be imported",
                Filter = sender == buttonKeyCountImport
                    ? "JSON file (*.json)|*.json"
                    : "CSV file (*.csv)|*.csv"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var importManager = new ImportManager(_manager);

            try
            {
                if (sender == buttonKeyCountImport)
                    await importManager.ImportDayCountsAsync(dialog.FileName);
                else
                    await importManager.ImportKeyListAsync(dialog.FileName);

                // Reload the data
                LoadShowData();
            }
            catch (Exception ex)
            {
                ex.ShowLogError();
            }
        }

        /// <summary>
        /// Occurs when the user hits one of the export buttons
        /// </summary>
        /// <param name="sender">The <see cref="buttonKeyCountExport"/> or <see cref="buttonKeyListExport"/></param>
        /// <param name="e">The event arguments</param>
        private void ButtonExport_Click(object sender, EventArgs e)
        {
            var keyList = sender == buttonKeyListExport;
            var dialog = new SaveFileDialog
            {
                Title = "Select the destination",
                DefaultExt = "*.csv",
                Filter = "CSV file (*.csv)|*.csv",
                FileName = keyList ? "KeyCount_KeyList" : "KeyCount_CountList"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                switch (keyList)
                {
                    case true when sourceKeyList.DataSource is SortableBindingList<KeyListEntry> keyListValues:
                        keyListValues.SaveTable(dialog.FileName, OutputType.Csv);
                        break;
                    case false when sourceKeyCount.DataSource is SortableBindingList<DayKeyCount> dayListValues:
                        dayListValues.SaveTable(dialog.FileName, OutputType.Csv);
                        break;
                }
            }
            catch (Exception ex)
            {
                ex.ShowLogError();
            }
        }
    }
}
