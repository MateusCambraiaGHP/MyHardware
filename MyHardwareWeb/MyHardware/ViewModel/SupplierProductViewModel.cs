using System.ComponentModel.DataAnnotations.Schema;
using static MyHardware.Utility.Constants;

namespace MyHardware.ViewModel
{
    public class SupplierProductViewModel
    {
        public int Id { get; set; }
        public int IdSupplier { get; set; }
        public int IdProduct { get; set; }
        public ProductViewModel product { get; set; }  
        public SupplierViewModel supplier { get; set; }
        public bool? IsNew { get { return Id == 0; } }
        public bool? IsEquals { get; set; }
    }
}
