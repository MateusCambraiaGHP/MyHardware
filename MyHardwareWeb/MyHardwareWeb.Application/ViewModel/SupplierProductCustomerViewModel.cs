using MyHardwareWeb.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHardware.ViewModel
{
    public class SupplierProductCustomerViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int CustomerId { get; set; }
        public int PurcashePrice { get; set; }
        public int PurcasheQuantity { get; set; }
        public Supplier supplier { get; set; }
        public Product product { get; set; }
        public Customer customer { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime PurchaseData { get; set; }

    }
}
