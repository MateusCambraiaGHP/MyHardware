using System.ComponentModel.DataAnnotations.Schema;

namespace MyHardware.Models
{
    public class User
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public int IdSupplier { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string? Email { get; set; } 

        [Column(TypeName = "varchar(15)")]
        public string? Password { get; set; }
        public string? Active { get; set; }
        public string? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

    }
}
