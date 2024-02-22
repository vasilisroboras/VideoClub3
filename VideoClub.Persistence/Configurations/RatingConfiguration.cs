using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VideoClub.Domain.Entities;

namespace VideoClub.Persistence.Configurations
{
	internal class RatingConfiguration : IEntityTypeConfiguration<Rating>
	{
		public void Configure(EntityTypeBuilder<Rating> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.CustomerId)
				.IsRequired();

			builder.Property(x => x.MovieId)
				.IsRequired();

			builder.Property(x => x.Rate).IsRequired();		

			builder.Property(x => x.RatingDate).IsRequired();		
		}
	}

}
