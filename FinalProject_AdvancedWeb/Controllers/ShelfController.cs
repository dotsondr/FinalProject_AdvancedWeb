using Microsoft.AspNetCore.Mvc;
using FinalProject_AdvancedWeb.Models.Entities;
using FinalProject_AdvancedWeb.Models.ViewModels;
namespace FinalProject_AdvancedWeb.Controllers
{
    public class ShelfController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var allShelves = await _shelfRepo.ReadAllAsync();
            var model = allShelves.Select(b =>
               new ShelfDetailsVM
               {
                   Id = b.Id,
                   ShelfName = b.ShelfName,
                   
               });
            return View(model);

        }
        private readonly IShelfRepository _shelfRepo;

        public ShelfController(IShelfRepository bookRepo)
        {
            _shelfRepo = shelfRepo;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int shelfId, CreateShelfVM shelfVM)
        {
            if (ModelState.IsValid)
            {
                var shelf = shelfVM.GetShelfInstance();

                await _shelfRepo.CreateAsync(Shelf);

                return RedirectToAction("Index", "Shelf");
            }
            shelfVM.Shelf = await _shelfRepo.ReadAsync(shelfId);
            return View(shelfId);
        }
        public async Task<IActionResult> Details(int id)
        {
            var shelf = await _shelfRepo.ReadAsync(id);
            if (shelf == null)
            {
                return RedirectToAction("Index");
            }
            var x = new ShelfDetailsVM
            {

                Id = shelf.Id,
                ShelfName = shelf.ShelfName,
                Products = shelf.Products
            };
            return View(x);

        }
    }
}
