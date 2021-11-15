using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.ViewModels
{
	public class LoginVM
	{
		[DisplayName("Tên tài khoản")]
		public string UserName { get; set; }
		[DataType(DataType.Password)]
		[DisplayName("Mật khẩu")]
		public string Password { get; set; }
		[DisplayName("Lưu đăng nhập")]
		public bool Remeber { get; set; }
	}
}
