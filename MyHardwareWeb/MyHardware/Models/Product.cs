using System.ComponentModel.DataAnnotations.Schema;

namespace MyHardware.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(130)")]
        public string? ProductType { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(30,2)")]
        public double Price { get; set; }
        public string? Active { get; set; }
        public string? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

    }
}
