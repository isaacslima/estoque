using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Product : BaseEntity
    {
        [Column(TypeName = "text")]
        public string Name { get; set; }

        [Column(TypeName = "integer")]
        public int Quantity { get; set; }

        [Column(TypeName = "real")]
        public double UnitValue { get; set; }
    }
}
