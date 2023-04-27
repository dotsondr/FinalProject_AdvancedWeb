using System.ComponentModel.DataAnnotations;

namespace FinalProject_AdvancedWeb.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        [StringLength(256)]
        public int Quantity { get; set; }
        public int ShelfID { get; set; }
        public Shelf? Shelf { get; set; }
    }
}
