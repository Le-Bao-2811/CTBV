using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.ViewModels
{
	public class UserVM
	{
		[DisplayName("Tên tài khoản")]
		public string UserName { get; set; }
		[Required(ErrorMessage ="Mật khẩu không được để trống")]
		[DisplayName("Nhập mật khẩu")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Không được để trống")]
		[DisplayName("Nhập lại mật khẩu")]
		[Compare(nameof(Password), ErrorMessage = "Mật khẩu không khớp")]
		public string ComfimlPassword { get; set; }
		[DisplayName("Quyền trên trang")]
		public bool IsAdmin { get; set; }
	}
}
