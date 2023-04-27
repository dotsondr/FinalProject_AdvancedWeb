using Microsoft.AspNetCore.Mvc;
using FinalProject_AdvancedWeb.Models.Entities;
using FinalProject_AdvancedWeb.Models.ViewModels;
namespace FinalProject_AdvancedWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IShelfRepository _shelfRepo;

        public ProductController(IShelfRepository shelfRepo)
        {
            _shelfRepo = shelfRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateAsync([Bind(Prefix = "id")] int shelfId)
        {
            var shelf = await _shelfRepo.ReadAsync(shelfId);
            if (shelf == null)
            {
                RedirectToAction("Index", "shelf");
            }
            ViewData["shelf"] = shelf;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int shelfId, CreateProductVM productVM)
        {
            if (productVM != null)
            {
                var model = productVM.GetProductInstance();
                await _shelfRepo.CreateAuthorAsync(shelfId, model);
                return RedirectToAction("Details", "Shelf", new { id = shelfId });
            }
            var shelf = _shelfRepo.ReadAsync(shelfId);
            ViewData["Shelf"] = shelf;
            return View(productVM);
        }
        public async Task<IActionResult> Edit([Bind(Prefix = "id")] int shelfId, int productId)
        {
            var shelf = await _shelfRepo.ReadAsync(shelfId);
            if (shelf == null)
            {
                return RedirectToAction("Index", "Shelf");
            }
            var product = shelf.Products.FirstOrDefault(a => a.Id == productId);
            if (product == null)
            {
                return RedirectToAction("Details", "Shelf");
            }
            var model = new EditProductVM()
            {
                shelf = shelf,
                id = product.Id,
                ProductName = product.ProductName,
                Quantity = product.Quantity
            };
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int shelfId, EditProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var product = productVM.GetProductInstance();
                await _shelfRepo.UpdateAuthorAsync(shelfId, product);
                return RedirectToAction("Details", "shelf", new { id = shelfId });
            }
            productVM.shelf = await _shelfRepo.ReadAsync(shelfId);
            return View(productVM);
        }
        public async Task<IActionResult> Delete([Bind(Prefix = "id")] int shelfId, int productId)
        {
            var shelf = await _shelfRepo.ReadAsync(shelfId);
            if (shelf == null)
            {
                return RedirectToAction("Index", "Shelf");
            }
            var product = shelf.Authors.FirstOrDefault(a => a.Id == productId);
            if (product == null)
            {
                return RedirectToAction("Details", "Shelf", new { id = shelfId });
            }
            var model = new DeleteProductVM()
            {
                shelf = shelf,
                id = product.Id,
                ProductName = product.ProductName,
                Quantity = product.Quantity
            };
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int shelfId, int productId)
        {
            await _shelfRepo.DeleteAuthorAsync(shelfId, productId);
            return RedirectToAction("Details", "Shelf", new { id = shelfId });
        }
    }
}
