using Library.MvcUi.ApiServices;
using Library.MvcUi.Models.Order;
using Library.MvcUi.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.MvcUi.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly UserApiService _userApiService;
        private readonly BookApiService _bookApiService;
        private readonly OrderApiService _orderApiService;

        public OrdersController(UserApiService userApiService, BookApiService bookApiService, OrderApiService orderApiService)
        {
            _userApiService = userApiService;
            _bookApiService = bookApiService;
            _orderApiService = orderApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            string token = HttpContext.Session.GetString("token");

            var book = await _bookApiService.GetByIdAsync(id, token);
            ViewBag.book = new List<SelectListItem> { new SelectListItem() { Value = book.Id.ToString(), Text = book.Name } };

            var orderVM = new OrderViewModel
            {
                UserModels = await _userApiService.GetAllAsync(token)
            };

            return View(orderVM);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddOrderInput addOrderInput)
        {
            string token = HttpContext.Session.GetString("token");

            if (!ModelState.IsValid)
            {
                var book = await _bookApiService.GetByIdAsync(addOrderInput.BookId, token);
                ViewBag.book = new List<SelectListItem> { new SelectListItem() { Value = book.Id.ToString(), Text = book.Name } };

                var orderVM = new OrderViewModel
                {
                    UserModels = await _userApiService.GetAllAsync(token)
                };
                return View(orderVM);
            }

            await _orderApiService.AddAsync(token, addOrderInput);

            return RedirectToAction("Index", "Books");
        }
    }
}
