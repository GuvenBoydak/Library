using Library.MvcUi.ApiServices;
using Library.MvcUi.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace Library.MvcUi.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryApiService _categoryApiService;

        public CategoriesController(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryInput addCategoryInput)
        {
            string token = HttpContext.Session.GetString("token");

            await _categoryApiService.AddAsync(token, addCategoryInput);

            return RedirectToAction("Index", "Books");
        }
    }
}
