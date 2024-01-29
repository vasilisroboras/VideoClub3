using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VideoClub.Domain.Entities;

namespace VideoClub.Persistence.Configurations
{
	internal class RentalConfiguration : IEntityTypeConfiguration<MovieRental>
	{
		public void Configure(EntityTypeBuilder<MovieRental> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.RentalDate);

			builder.Property(x => x.CustomerId);


			// TODO: check if this is needed or not (in case we didn't want to have the name as unique)
			//builder.Property(x => x.Name).IsRequired();
		}

		
	}
}
