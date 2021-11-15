using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.Entites
{
	[Table("NhanVien")]
	public class NhanVien
	{
		[Key]
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
		public string duongdan { get; set; }
		[DisplayName("Chức vụ")]
		public int IdChucVu { get; set; }
		[ForeignKey(nameof(IdChucVu))]
		public ChucVu chucVu { get; set; }
	}
}
