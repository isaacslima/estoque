using DapperExtensions.Mapper;
using Domain.Entity;

namespace Infra.Mapping
{
    public class ProductMapper : ClassMapper<Product>
    {
        public ProductMapper()
        {
            Table(nameof(Product));

            Map(p => p.Id).Key(KeyType.Identity).Column("Id");
            Map(p => p.Name).Column("Name");
            Map(p => p.Quantity).Column("Quantity");
            Map(p => p.UnitValue).Column("UnitValue");

            AutoMap();
        }
    }
}
