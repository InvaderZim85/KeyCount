using System.IO;
using KeyCount.DataObjects;
using KeyCount.Global;
using Microsoft.EntityFrameworkCore;

namespace KeyCount.Data
{
    /// <summary>
    /// Provides the database context for the application
    /// </summary>
    internal class AppDbContext : DbContext
    {
        /// <summary>
        /// Contains the connection string
        /// </summary>
        private readonly string _conString;

        /// <summary>
        /// Gets or sets the day counts
        /// </summary>
        public DbSet<DayKeyCount> DayCounts => Set<DayKeyCount>();

        /// <summary>
        /// Gets or sets the key list
        /// </summary>
        public DbSet<KeyListEntry> KeyList => Set<KeyListEntry>();

        /// <summary>
        /// Creates a new instance of the <see cref="AppDbContext"/>
        /// </summary>
        public AppDbContext()
        {
            _conString = $"Data Source = {Path.Combine(Helper.GetBaseDirPath(), "KeyCountDatabase.db")}";
        }

        /// <summary>
        /// Occurs when the context is configured
        /// </summary>
        /// <param name="optionsBuilder">The options builder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_conString);
        }

        /// <summary>
        /// Occurs when the context models are created
        /// </summary>
        /// <param name="modelBuilder">The model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DayKeyCount>().HasIndex(x => x.Day).IsUnique();
            modelBuilder.Entity<KeyListEntry>().HasIndex(x => x.KeyCode).IsUnique();
        }
    }
}
