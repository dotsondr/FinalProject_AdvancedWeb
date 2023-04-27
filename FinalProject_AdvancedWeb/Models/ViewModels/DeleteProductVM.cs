using FinalProject_AdvancedWeb.Models.Entities;
namespace FinalProject_AdvancedWeb.Models.ViewModels
{
    public class DeleteProductVM
    {
        public Shelf? shelf { get; set; }
        public int id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
