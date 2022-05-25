using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyCount.DataObjects;
using KeyCount.DataObjects.Import;
using Newtonsoft.Json;

namespace KeyCount.Business;

internal class ImportManager
{
    /// <summary>
    /// The instance of the data manager
    /// </summary>
    private readonly DataManager _dataManager;

    /// <summary>
    /// Creates a new instance of the <see cref="ImportManager"/>
    /// </summary>
    /// <param name="dataManager">The instance of the data manager</param>
    public ImportManager(DataManager dataManager)
    {
        _dataManager = dataManager;
    }

    /// <summary>
    /// Imports the day count list
    /// </summary>
    /// <param name="filepath">The filepath</param>
    /// <returns>The awaitable task</returns>
    /// <exception cref="ArgumentNullException">Will be thrown when the given filepath is null or empty</exception>
    public async Task ImportDayCountsAsync(string filepath)
    {
        if (string.IsNullOrEmpty(filepath))
            throw new ArgumentNullException(nameof(filepath));

        var fileContent = await File.ReadAllTextAsync(filepath, Encoding.UTF8);

        var data = JsonConvert.DeserializeObject<List<DayCountDto>>(fileContent);

        if (data == null)
            return;

        await _dataManager.ImportCountListAsync(data);
    }

    /// <summary>
    /// Imports the key list
    /// </summary>
    /// <param name="filepath">The filepath</param>
    /// <returns>The awaitable task</returns>
    /// <exception cref="ArgumentNullException">Will be thrown when the given filepath is null or empty</exception>
    public async Task ImportKeyListAsync(string filepath)
    {
        if (string.IsNullOrEmpty(filepath))
            throw new ArgumentNullException(nameof(filepath));

        var fileContent = await File.ReadAllLinesAsync(filepath, Encoding.UTF8);

        var data = new List<KeyListEntry>();
        foreach (var line in fileContent)
        {
            if (line.Equals("Key;Count"))
                continue;

            var lineContent = line.Split(';', StringSplitOptions.TrimEntries);
            if (lineContent.Length != 2)
                continue;

            if (!Enum.TryParse(lineContent[0], out Keys keyCode))
                continue;

            data.Add(new KeyListEntry
            {
                Key = lineContent[0],
                KeyCode = (int)keyCode,
                Count = int.TryParse(lineContent[1], out var count) ? count : 0
            });
        }

        await _dataManager.ImportKeyListAsync(data);
    }
}