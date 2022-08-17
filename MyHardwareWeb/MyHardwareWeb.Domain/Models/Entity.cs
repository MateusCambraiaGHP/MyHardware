
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHardwareWeb.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }
    }
}
