using Microsoft.AspNetCore.Mvc;
using FinalProject_AdvancedWeb.Models.Entities;
using FinalProject_AdvancedWeb.Models.ViewModels;
using FinalProject_AdvancedWeb.Services;

namespace FinalProject_AdvancedWeb.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IShelfRepository _shelfRepo;

        public ShelfController(IShelfRepository shelfRepo)
        {
            _shelfRepo = shelfRepo;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
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

                await _shelfRepo.CreateAsync(shelf);

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
