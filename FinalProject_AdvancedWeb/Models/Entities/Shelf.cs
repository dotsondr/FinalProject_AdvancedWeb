using System.ComponentModel.DataAnnotations;

namespace FinalProject_AdvancedWeb.Models.Entities
{
    public class Shelf
    {
        public int Id { get; set; }
        public string? ShelfName { get; set; }
        [StringLength(128)]

        public int ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
