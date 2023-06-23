using Library.MvcUi.ApiServices;
using Library.MvcUi.Models.Writer;
using Microsoft.AspNetCore.Mvc;

namespace Library.MvcUi.Controllers
{
    public class WritersController : Controller
    {
        private readonly WriterApiService _writerApiService;

        public WritersController(WriterApiService writerApiService)
        {
            _writerApiService = writerApiService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddWriterInput addWriterInput)
        {
            string token = HttpContext.Session.GetString("token");

            await _writerApiService.AddAsync(token, addWriterInput);

            return RedirectToAction("Index", "Books");
        }
    }
}
