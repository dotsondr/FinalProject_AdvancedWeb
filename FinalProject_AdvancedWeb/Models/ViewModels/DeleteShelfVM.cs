using FinalProject_AdvancedWeb.Models.Entities;
namespace FinalProject_AdvancedWeb.Models.ViewModels
{
    public class DeleteShelfVM
    {
        public Product? Product { get; set; }
        public int id { get; set; }
        public string ShelfName { get; set; }
    }
}
