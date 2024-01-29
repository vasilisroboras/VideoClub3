using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VideoClub.Domain.Entities;

namespace VideoClub.Persistence.Configurations
{
	internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired(false); // Customize the configuration as needed

            // Assuming you want to map the Title property
            builder.Property(x => x.Title)
                .IsRequired(false);

			// Assuming you want to map the ReleaseDate property
			builder.Property(x => x.ReleaseDate);

            // Assuming you want to map the Stock property
            builder.Property(x => x.Stock)
                .IsRequired();
		}

		
	}
}
