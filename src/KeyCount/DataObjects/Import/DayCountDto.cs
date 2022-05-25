using System;

namespace KeyCount.DataObjects.Import;

/// <summary>
/// Represents a day count dto
/// </summary>
public class DayCountDto
{
    /// <summary>
    /// Gets or sets the date of the entry
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the count of the day
    /// </summary>
    public int Count { get; set; }
}