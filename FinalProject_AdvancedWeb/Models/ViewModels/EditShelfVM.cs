using FinalProject_AdvancedWeb.Models.Entities;
using System.ComponentModel;

namespace FinalProject_AdvancedWeb.Models.ViewModels
{
    public class EditShelfVM
    {
        public Product? product { get; set; }
        public int id { get; set; }
        [DisplayName("ShelfName")]
        public string ShelfName { get; set; }
        public Shelf GetShelfInstance()
        {
            return new Shelf
            {
                Id = this.id,
                ShelfName = this.ShelfName,
            };
        }
    }
}
