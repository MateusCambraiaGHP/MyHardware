using System.ComponentModel.DataAnnotations.Schema;

namespace MyHardware.Models
{
    public class SupplierProduct
    {
        public int Id { get; set; }
        public int IdSupplier { get; set; }
        public int IdProduct { get; set; }
        public string? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

    }
}
