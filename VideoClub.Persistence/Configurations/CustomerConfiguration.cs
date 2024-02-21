using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Domain.Entities;

namespace VideoClub.Persistence.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            // Configure the Name property
            builder.Property(x => x.Name)
                .IsRequired() // You can modify this based on your requirements
                .HasMaxLength(255); // Adjust the maximum length based on your needs

           
        }
    }
}
