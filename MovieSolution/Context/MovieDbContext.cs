using Microsoft.EntityFrameworkCore;

namespace MovieSolution.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("movieConnStr");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                { 
                    Id = 1, IdImbd = "tt6146586", Name = "John Wick",
                    Description = "John Wick is on the run after killing a member of the international assassins",
                    ReleaseDate = "2019-05-17", Genre = "Action",
                    Watched = false, UserScore = "8.9",
                    Ratings = "Internet Movie Database 7.4 / 10 Rotten Tomatoes 89% Metacritic 73/100",
                    MetaScore = "87%"
                },

                new Movie()
                {
                    Id = 2, IdImbd = "tt4154796", Name = "Avengers: Endgame",
                    Description = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins",
                    ReleaseDate = "2019-04-26", Genre = "Action",
                    Watched = false, UserScore = "8.4",
                    Ratings = "Internet Movie Database 7.8 / 10 Rotten Tomatoes 83%",
                    MetaScore = "91%"
                },

                new Movie()
                { 
                    Id = 3, IdImbd = "tt5113044", Name = "Minions: The Rise of Gru",
                    Description = "The untold story of one twelve-year-old's dream to become the world's greatest supervillain",
                    ReleaseDate = "2022-07-01", Genre = "Comedy",
                    Watched = false, UserScore = "6.9",
                    Ratings = "Internet Movie Database 6.5 / 10 Rotten Tomatoes 80% Metacritic 70/100",
                    MetaScore = "77%"
                });
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
