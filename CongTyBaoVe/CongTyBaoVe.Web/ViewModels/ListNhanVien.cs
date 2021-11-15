using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.ViewModels
{
	public class ListNhanVien
	{
		public int Id { get; set; }
		[DisplayName("Tên nhân viên")]
		public string TenNhanVien { get; set; }
		[DisplayName("Năm sinh")]
		public DateTime NamSinh { get; set; }
		[DisplayName("Địa chỉ")]
		public string DiaChi { get; set; }
		[DisplayName("Số điện thoại")]
		public string SDT { get; set; }
		[DisplayName("Trạng thái")]
		public bool TrangThai { get; set; }
		[DisplayName("Chức vụ")]
		public string ChucVu { get; set; }
	}
}
