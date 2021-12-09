using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.Entites
{
	[Table("User")]
	public class User
	{
		[Key]
		public int Id{ get; set; }
		[DisplayName("Tài khoản")]
		
		public string UserName { get; set; }
		[DisplayName("Mật khẩu")]
		[DataType(DataType.Password)]
		
		public string PasswordHash { get; set; }
		[DisplayName("Quyền")]
		public bool IsAdmin { get; set; }
	}
}
