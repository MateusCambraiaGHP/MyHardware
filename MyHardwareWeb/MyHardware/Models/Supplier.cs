using System.ComponentModel.DataAnnotations.Schema;

namespace MyHardware.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string? Name { get; set; } 

        [Column(TypeName = "varchar(130)")]
        public string? Description { get; set; }
        public string? Active { get; set; }
        public string? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

    }
}
