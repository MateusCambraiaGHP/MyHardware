using System.ComponentModel.DataAnnotations.Schema;
using static MyHardware.Utility.Constants;

namespace MyHardware.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string? Active { get; set; }
        public bool? IsActive { get { return Active == StatusActive.Active; } }
        public bool? IsNew { get { return Id == 0; } }
        public bool? IsEquals { get; set; }
    }
}
