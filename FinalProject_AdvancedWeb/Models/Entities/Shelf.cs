using System.ComponentModel.DataAnnotations;

namespace FinalProject_AdvancedWeb.Models.Entities
{
    public class Shelf
    {
        public int Id { get; set; }
        public string? ShelfName { get; set; }
        [StringLength(128)]

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
