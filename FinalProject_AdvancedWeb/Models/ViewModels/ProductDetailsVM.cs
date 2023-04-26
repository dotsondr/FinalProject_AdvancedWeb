using System.ComponentModel;
using FinalProject_AdvancedWeb.Models.Entities;
namespace FinalProject_AdvancedWeb.Models.ViewModels
{
    public class ProductDetailsVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        [DisplayName("Publication Year")]
        public int Quantity { get; set; }
        [DisplayName("Number of Authors")]
        public ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();

    }
}
