using Klinik.WebUI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Klinik.Business.Concrate;
using Klinik.DTO.AdminDTOS;

namespace Klinik.WebUI.Controllers
{
	public class AnaSayfaController : Controller
	{
		private readonly AdminMenager _adminMenager;

		public AnaSayfaController(AdminMenager adminMenager)
		{
			this._adminMenager = adminMenager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			if (!HttpContext.User.Identity.IsAuthenticated) return View();
			else return Redirect("/Yonetici/AnaSayfa/Index");
		}
		[HttpPost]
		public async Task<IActionResult> Login(ResultAdminDTO result)
		{

			string nullError = "* Lütfen boþ alan býrakmayýnýz !!!";
			string error = "* Lütfen geçerli bir hesap giriniz !!!";

			if (result.UserName != null && result.Password != null)
			{

				var value = _adminMenager.TGetByFilter(x => x.UserName == result.UserName && x.Password == result.Password);

				if (value is null) { ViewBag.Error = error; return View(); }

				if (value != null)
				{
					List<Claim> claims = new List<Claim>()
				{
					new Claim(ClaimTypes.NameIdentifier,value.UserName),
					new Claim("UserName",value.UserName),
				};
					ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					AuthenticationProperties authentication = new AuthenticationProperties()
					{
						IsPersistent = true,
						AllowRefresh = true,
					};
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authentication);

					return Redirect("/Yonetici/AnaSayfa/Index");
				}
			}
			else
			{
				ViewBag.nullError = nullError;
			}
			return View();
		}


		public IActionResult Cikis()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("AnaSayfa", "AnaSayfa");
		}
	}
}
