using Mute.models;
using Microsoft.EntityFrameworkCore;

namespace Mute.repositories.configuration {

    /// <summary>
    /// Database context for Entity Framework.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public class DataContextEF: DbContext {

        private readonly IConfiguration _config;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="configuration">The IConfiguration to use.</param>
        public DataContextEF(IConfiguration configuration) {
            this._config = configuration;
        }

        //We require a DbSet for each entity we want to use.
        public virtual DbSet<User> Users {get; set;}
        public virtual DbSet<Tag> Tags {get; set;}

        /// <summary>
        /// Configures various pieces of the database context.
        /// </summary>
        /// <param name="optionsBuilder">The DbContextOptionsBuilder to use.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder 
                    .UseSqlServer(_config.GetConnectionString("DefaultConnection"), 
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure());

                // Enable EF Core logging (logs the SQL it generates and more)
                optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

            }
        }

        //We need to tell EF where these DB Tables actually are.
        //We need to also map our names of our classes to our tables.
        /// <summary>
        /// Tells EF information about the database tables.
        /// </summary>
        /// <param name="modelBuilder">The ModelBuilder to use.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(u => u.UserID);

            modelBuilder.Entity<Tag>()
                .ToTable("Tags")
                .HasKey(t => t.TagId);
        }
    }

}