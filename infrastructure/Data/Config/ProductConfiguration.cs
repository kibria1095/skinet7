using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Id).IsRequired();
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.Description).IsRequired().HasMaxLength(180);
            builder.Property(p=>p.Price).HasColumnType("Decimal(18,2)");
            builder.Property(p=>p.PictureUrl).IsRequired();
            builder.HasOne(b=>b.ProductBrand).WithMany()
                .HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(t=>t.ProductType).WithMany()
                .HasForeignKey(p=>p.ProductTypeId);

///builder.HasOne(t=>t.ProductBrand).WithMany()
                ///.HasForeignKey(p=>p.ProductTypeId); This line creates the following error. Here t=>t.ProductBrand should be t=>t.ProductType 
                ///The foreign key property 'Product.ProductTypeId1' was created in shadow state because a conflicting property with the simple name 'ProductTypeId' exists in the entity type, but is either not mapped, is already used for another relationship, or is incompatible with the associated primary key type. See https://aka.ms/efcore-relationships for information on mapping relationships in EF Core.
        }
    }
}