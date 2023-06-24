using Library.MvcUi.ApiServices;
using Library.MvcUi.Models.Book;
using Library.MvcUi.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.MvcUi.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookApiService _bookApiService;
        private readonly WriterApiService _writerApiService;
        private readonly CategoryApiService _categoryApiService;
        private readonly OrderApiService _orderApiService;
        private readonly UserApiService _userApiService;

        public BooksController(CategoryApiService categoryApiService, WriterApiService writerApiService, BookApiService bookApiService, OrderApiService orderApiService, UserApiService userApiService)
        {
            _categoryApiService = categoryApiService;
            _writerApiService = writerApiService;
            _bookApiService = bookApiService;
            _orderApiService = orderApiService;
            _userApiService = userApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString("token");
            if(token==null)
                return RedirectToAction("LogOut","Users");


            var books = await _bookApiService.GetAllAsync(token);

            var bookVM = new BookViewModel
            {
                BookModels = books.OrderBy(x => x.Name).ToList(),
                CategoryModels = await _categoryApiService.GetAllAsync(token),
                WriterModels = await _writerApiService.GetAllAsync( token),
                OrderModels = await _orderApiService.GetAllAsync(token),
                UserModels = await _userApiService.GetAllAsync(token)
            };
            return View(bookVM);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddBookInput addBookInput)
        {
            string token = HttpContext.Session.GetString("token");

            await _bookApiService.AddAsync(token, addBookInput);

            return RedirectToAction("Index");
        }
    }
}
