using CongTyBaoVe.Web.Repository;
using CongTyBaoVe.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.Controllers
{

	[Authorize]
	public class NhanVienController : Controller
	{
		NhanVienRepository repository;
		ChucVuRepository chucVuRepository;
		public NhanVienController(NhanVienRepository _repository, ChucVuRepository _chucvu) : base()
		{
			repository = _repository;
			chucVuRepository = _chucvu;
		}
		public IActionResult Index() => View();
		public IActionResult show()
		{
			var data = repository.ToList();
			return new JsonResult(data);
		}	
		
		[HttpPost]
		public async Task<IActionResult> Create(AddEditNhanVIenVM model)
		{
			await repository.AddNhanVien(model);
			return Ok();
		}
		public IActionResult Edit(int id)
		{
			var model = repository.Find(id);
			AddEditNhanVIenVM data = new AddEditNhanVIenVM();
			data.Id = model.Id;
			data.TenNhanVien = model.TenNhanVien;
			data.NamSinh = model.NamSinh;
			data.SDT = model.SDT;
			data.TrangThai = model.TrangThai;
			data.IdChucVu = model.IdChucVu;
			data.DiaChi = model.DiaChi;			
			return PartialView(data);
		}
		[HttpPost]
		public async Task<IActionResult> update(AddEditNhanVIenVM model)
		{			
			await repository.EditNhanVien(model);
			return RedirectToAction("Index", "NhanVien");
		}
		[Authorize(Roles ="Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			repository.Delete(id);
			await repository.Save();
			return RedirectToAction("Index", "NhanVien");
		}
	}
}
