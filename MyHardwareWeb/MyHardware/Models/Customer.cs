using System.ComponentModel.DataAnnotations.Schema;

namespace MyHardware.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? Observation { get; set; }
        public string? Active { get; set; }
        public string? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }
    }
}
