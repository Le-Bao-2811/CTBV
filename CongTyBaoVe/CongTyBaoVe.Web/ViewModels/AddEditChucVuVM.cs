using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.ViewModels
{
	public class AddEditChucVuVM
	{
		public int Id { get; set; }
		[DisplayName("Chức vụ")]
		public string ChucVuNhanVien { get; set; }
	}
}
