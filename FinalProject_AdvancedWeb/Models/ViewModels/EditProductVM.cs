using FinalProject_AdvancedWeb.Models.Entities;
using System.ComponentModel;

namespace FinalProject_AdvancedWeb.Models.ViewModels
{
    public class EditProductVM
    {
        public Shelf? shelf { get; set; }
        public int id { get; set; }
        [DisplayName("ShelfName")]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Product GetProductInstance()
        {
            return new Product
            {
                Id = this.id,
                ProductName = this.ProductName,
                Quantity = this.Quantity,
            };
        }
    }
}
