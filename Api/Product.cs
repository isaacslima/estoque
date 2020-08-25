namespace Api
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitValue { get; set; }

        public decimal TotalValue => Quantity*UnitValue;
    }
}
