namespace Domain.Entity
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitValue { get; set; }

        public decimal TotalValue => Quantity * UnitValue;
    }
}
