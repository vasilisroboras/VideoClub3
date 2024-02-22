using Microsoft.EntityFrameworkCore;
using VideoClub.Domain.Entities;

namespace VideoClub.Persistence
{
	public class VideoClubDbContext : DbContext
{
	 public VideoClubDbContext()
    {
    }
    public VideoClubDbContext(DbContextOptions<VideoClubDbContext> options) : base(options)
		{
		}

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<MovieRental> Rentals { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Rating> Ratings { get; set; }

		
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlServer("Server=DESKTOP-BUB5REL;Database=VideoClubNew;Trusted_Connection=True;");
        }
    }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(VideoClubDbContext).Assembly);

			//modelBuilder.Entity<Movie>()
			//	.HasKey(m => m.Id);

			//modelBuilder.Entity<Movie>()
			//	.Property(m => m.Title)
			//	.HasMaxLength(100);

			//modelBuilder.Entity<MovieGenre>()
			//	.HasKey(mg => new { mg.MovieId, mg.GenreId });

			//modelBuilder.Entity<MovieGenre>()
			//	.HasOne(mg => mg.Movie)
			//	.WithMany(m => m.MovieGenres)
			//	.HasForeignKey(mg => mg.MovieId);

			//modelBuilder.Entity<MovieGenre>()
			//	.HasOne(mg => mg.Genre)
			//	.WithMany(g => g.MovieGenres)
			//	.HasForeignKey(mg => mg.GenreId);

			//modelBuilder.Entity<Rental>()
			//	.HasOne(r => r.Movie)
			//	.WithMany(m => m.Rentals)
			//	.HasForeignKey(r => r.MovieId);

			//modelBuilder.Entity<Customer>()
			//	.HasKey(c => c.Id);

			//modelBuilder.Entity<Rental>()
			//	.HasOne(r => r.Customer)
			//	.WithMany(c => c.Rentals)
			//	.HasForeignKey(r => r.CustomerId);

			// modelBuilder.Entity<MovieRental>()
			// .HasOne<Customer>()
			// .WithMany(x => x.Rentals)
			// .HasForeignKey("CustomerId");

			base.OnModelCreating(modelBuilder);
		}
	}
}