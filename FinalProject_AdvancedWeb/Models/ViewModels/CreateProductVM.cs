using System.ComponentModel;
using FinalProject_AdvancedWeb.Models.Entities;

namespace FinalProject_AdvancedWeb.Models.ViewModels
{
    public class CreateProductVM
    {
        public Product? Product { get; set; }
        public string ProductName { get; set; }
        [DisplayName("Publication Year")]
        public int Quantity { get; set; }

        public Product GetProductInstance()
        {
            return new Product
            {
                Id = 0,
                ProductName = this.ProductName,
                Quantity = this.Quantity,
            };

        }
    }
}
