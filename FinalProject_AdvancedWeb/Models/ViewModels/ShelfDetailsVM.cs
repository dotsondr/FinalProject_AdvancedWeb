using System.ComponentModel;
using FinalProject_AdvancedWeb.Models.Entities;
namespace FinalProject_AdvancedWeb.Models.ViewModels
{
    public class ShelfDetailsVM
    {
        public int Id { get; set; }

        [DisplayName("Shelf Name")]
        public string ShelfName { get; set; }
        
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
