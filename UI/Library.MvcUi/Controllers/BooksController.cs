using Library.MvcUi.ApiServices;
using Library.MvcUi.Models.Book;
using Library.MvcUi.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;

namespace Library.MvcUi.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookApiService _bookApiService;
        private readonly WriterApiService _writerApiService;
        private readonly CategoryApiService _categoryApiService;

        public BooksController(CategoryApiService categoryApiService, WriterApiService writerApiService, BookApiService bookApiService)
        {
            _categoryApiService = categoryApiService;
            _writerApiService = writerApiService;
            _bookApiService = bookApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString("token");

            var books = await _bookApiService.GetAllAsync(token);

            var bookVM = new BookViewModel
            {
                BookModels = books,
                CategoryModels = await _categoryApiService.GetAllAsync(token),
                WriterModels = await _writerApiService.GetByIdsAsync(books.Select(x => x.WriterId).ToList(), token)
            };
            return View(bookVM);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string token = HttpContext.Session.GetString("token");

            var bookVM = new BookViewModel
            {
                CategoryModels = await _categoryApiService.GetAllAsync(token),
                WriterModels = await _writerApiService.GetAllAsync(token)
            };

            return View(bookVM);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookInput addBookInput)
        {
            string token = HttpContext.Session.GetString("token");

            await _bookApiService.AddAsync(token, addBookInput);

            return RedirectToAction("Index");
        }
    }
}
