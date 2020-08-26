using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Config
{
    public class ProductConfig : BaseConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.Property(d => d.Name).HasMaxLength(100);
            builder.Property(d => d.Quantity).IsUnicode(false);
            builder.Property(d => d.UnitValue).IsUnicode(false);
            base.Configure(builder);
        }
    }
}
