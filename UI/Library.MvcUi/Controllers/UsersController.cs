using Library.MvcUi.ApiServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using Library.MvcUi.Models.User;
using Library.MvcUi.Models;
using Library.MvcUi.ViewModels.User;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Library.MvcUi.Controllers;

public class UsersController : Controller
{
    private readonly UserApiService _userApiService;
    private readonly OrderApiService _orderApiService;
    private readonly BookApiService _bookApiService;

    public UsersController(UserApiService userApiService, OrderApiService orderApiService, BookApiService bookApiService)
    {
        _userApiService = userApiService;
        _orderApiService = orderApiService;
        _bookApiService = bookApiService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        string token = HttpContext.Session.GetString("token");
        string email = HttpContext.Session.GetString("User");

        var user = await _userApiService.GetByEmailAsync(token, email);
        var orders = await _orderApiService.GetOrdersByUserIdAsync(user.Id, token);

        var userVM = new UserViewModel
        {
            UserModel = user,
            OrderModels = orders,
            BookModels = await _bookApiService.GetByIdsAsync(orders.Select(x => x.BookId).ToList(), token)
        };

        return View(userVM);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        HttpResponseMessage result = await _userApiService.RegisterAsync(model);

        var response = await DeserialezeToken(result);

        if (response.StatusCode != 200)
        {
            ViewBag.FailRegister = response.Errors.FirstOrDefault();
            return View();
        }

        return RedirectToAction("Login");
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var result = await _userApiService.LoginAsync(model);

        var response = await DeserialezeToken(result);

        var user = await _userApiService.GetByEmailAsync(response.Data.AccessToken, model.Email);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email,user.Email)
        };

        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        HttpContext.Session.SetString("token", response.Data.AccessToken);
        HttpContext.Session.SetString("User", user.Email);

        ViewBag.Name = $"{user.FirstName} {user.LastName}";

        return RedirectToAction("Index");
    }

    [NonAction]
    private async Task<ResponseDto<Token>> DeserialezeToken(HttpResponseMessage json)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        string jsonResult = await json.Content.ReadAsStringAsync();

        var result = System.Text.Json.JsonSerializer.Deserialize<ResponseDto<Token>>(jsonResult, options);
        result.StatusCode = (int)json.StatusCode;

        return result;
    }

    [HttpGet]
    public IActionResult LogOut()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }
}