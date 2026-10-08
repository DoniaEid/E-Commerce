using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.DbContext.Configurations
{
    public class ProductVarientConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {

            builder.HasOne(p=>p.product)
                   .WithMany(x => x.ProductVariants)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.size)
                   .WithMany(x => x.productVariant)
                   .HasForeignKey(x => x.SizeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c=>c.color)
              .WithMany(x => x.productVariant)
              .HasForeignKey(x => x.ColorId)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
