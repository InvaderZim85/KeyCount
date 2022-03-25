using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeyCount.DataObjects
{
    /// <summary>
    /// Represents a day key count entry
    /// </summary>
    [Table("DayKeyCount")]
    internal class DayKeyCount
    {
        /// <summary>
        /// Gets or sets the id of the entry
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the day
        /// </summary>
        public DateTime Day { get; set; } = DateTime.Now.Date;

        /// <summary>
        /// Gets or sets the count of the day
        /// </summary>
        public int Count { get; set; }
    }
}
