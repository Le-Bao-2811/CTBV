using CongTyBaoVe.Web.Repository;
using CongTyBaoVe.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.Controllers
{
	[Authorize]
	public class ChucVuController : Controller
	{
		ChucVuRepository repository;
		public ChucVuController(ChucVuRepository _repo)
		{
			repository = _repo;
		}	
		public async Task<IActionResult> Index()
		{
			var data = await repository.ToList();
			return View(data);
		}
		public IActionResult Create() => View();
		[HttpPost]
		public async Task<IActionResult>Create(AddEditChucVuVM model)
		{
			await repository.AddChucVu(model);
			return RedirectToAction("Index", "ChucVu");
		}
		public IActionResult Edit(int id)
		{
			var data = repository.Find(id);
			AddEditChucVuVM model = new AddEditChucVuVM();
			model.Id = data.Id;
			model.ChucVuNhanVien = data.ChucVuNhanVien;
			return PartialView(model);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(AddEditChucVuVM model)
		{
			var data = repository.Find(model.Id);
			await repository.Editchucvu(model);
			return RedirectToAction("Index", "ChucVu");
		}
		[Authorize(Roles ="Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			repository.Delete(id);
			await repository.Save();
			return RedirectToAction("Index", "ChucVu");
		}
	}
}
