using System.ComponentModel.DataAnnotations.Schema;

namespace MyHardware.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public int IdSupplier { get; set; }
        public int IdCustomer { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? City { get; set; }
        public int Number { get; set; }
        public string? Active { get; set; }
        public string? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }
    }
}
