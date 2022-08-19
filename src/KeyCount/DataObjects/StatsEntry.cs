namespace KeyCount.DataObjects;

    /// <summary>
    /// Provides some statistics
    /// </summary>
    public class StatsEntry
    {
        /// <summary>
        /// Gets or sets the total key count
        /// </summary>
        public string TotalKeyCount { get; set; } = "";
        
        /// <summary>
        /// Gets or sets the maximal key count
        /// </summary>
        public string MaxKeyCount { get; set; } = "";

        /// <summary>
        /// Gets or sets the average key count
        /// </summary>
        public string AverageKeyCount { get; set; } = "";

        /// <summary>
        /// Gets or sets the most. used key
        /// </summary>
        public string MostUsedKey { get; set; } = "";

        /// <summary>
        /// Gets or sets the least used key
        /// </summary>
        public string LeastUsedKey { get; set; } = "";
}