using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api.Models;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;


namespace SignalRWebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<SignalR.EntityLayer.Entities.AppUser> _signInManager;

		public LoginController(SignInManager<SignalR.EntityLayer.Entities.AppUser> signInManager)
		{
			_signInManager = signInManager;
		}


		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			if (string.IsNullOrEmpty(loginDto.UserName) || string.IsNullOrEmpty(loginDto.Password))
			{
				ModelState.AddModelError("", "Kullanıcı adı ve şifre boş olamaz.");
				return View(loginDto);
			}

			var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Category");
			}

			ModelState.AddModelError("", "Giriş başarısız. Lütfen bilgilerinizi kontrol edin.");
			return View(loginDto);
		}


	}
}
