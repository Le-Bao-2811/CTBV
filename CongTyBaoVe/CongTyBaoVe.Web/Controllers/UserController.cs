using CongTyBaoVe.Web.Repository;
using CongTyBaoVe.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.Controllers
{
	public class UserController : Controller
	{
		private readonly LoginRepository repository;

		public UserController(LoginRepository _repository)
		{
			repository = _repository;
		}
		[Authorize]
		public async Task<IActionResult> Index()
		{
			var id = User.FindFirst(ClaimTypes.NameIdentifier);
			var data = Convert.ToInt32(id.Value);
			return View( await repository.ToList(data));
		}
		public IActionResult SingUp() => View();
		[HttpPost]
		public async Task<IActionResult> SingUp(UserVM userVM)
		{
			await repository.SignUp(userVM);
			await repository.Save();
			return RedirectToAction("Index","User");
		}
		public IActionResult Login() => View();
		[HttpPost]
		public async Task<IActionResult> Login(LoginVM model)
		{
			if (ModelState.IsValid)
			{
				model.UserName = model.UserName.Replace(" ", "").ToLower();
				var user = repository.ASno(model);
				if (user == null )
				{
					TempData["Mesg"] = "Tài khoản của bạn không hợp lệ";
				}
				else
				{
					MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
					var encryptPassword = repository.MD5Hasher(model.UserName, model.Password);
					if (encryptPassword.SequenceEqual(user.PasswordHash))
					{
						var claims = new List<Claim> {
							new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
							new Claim(ClaimTypes.Name, user.UserName),
							new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "Member")
						};
						var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
						var principal = new ClaimsPrincipal(claimsIdentity);
						var authenPropeties = new AuthenticationProperties()
						{
							ExpiresUtc = DateTime.UtcNow.AddHours(6),
							IsPersistent = model.Remeber
						};
						await HttpContext.SignInAsync("Cookies", principal, authenPropeties);
						return RedirectToAction("Index", "Home");
					}
					else
					{
						TempData["Mesg"] = "Tên đăng nhập hoặc mật khẩu không chính xác";
					}
				}
			}
			else
			{
				TempData["Mesg"] = "Lỗi không xác định!";
			}
			return RedirectToAction(nameof(Login));
		}
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync("Cookies");
			return RedirectToAction("Index","Home");
		}	
		public IActionResult Delete(int id)
		{
			repository.Delete(id);
			return RedirectToAction("Index", "User");
		}
	}
}
