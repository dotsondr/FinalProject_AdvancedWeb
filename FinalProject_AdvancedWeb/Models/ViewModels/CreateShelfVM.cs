using FinalProject_AdvancedWeb.Models.Entities;
using System.ComponentModel;

namespace FinalProject_AdvancedWeb.Models.ViewModels
{
    public class CreateShelfVM
    {
        public Shelf? Shelf { get; set; }

        [DisplayName("Shelf Name")]
        public string? ShelfName { get; set; }

        public Shelf GetAuthorInstance()
        {
            return new Shelf
            {
                Id = 0,
                ShelfName = this.ShelfName,
            };

        }
    }
}
