using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeyCount.DataObjects
{
    /// <summary>
    /// Represents a key entry
    /// </summary>
    [Table("KeyList")]
    internal class KeyListEntry
    {
        /// <summary>
        /// Gets or sets the id of the entry
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the key code of the key
        /// </summary>
        public int KeyCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the key
        /// </summary>
        public string Key { get; set; } = "";

        /// <summary>
        /// Gets or sets the total counts
        /// </summary>
        public int Count { get; set; }
    }
}
