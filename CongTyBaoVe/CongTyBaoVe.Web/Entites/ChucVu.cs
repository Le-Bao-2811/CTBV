using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.Entites
{
	[Table("ChucVu")]
	public class ChucVu
	{
		public ChucVu(){
			nhanViens = new HashSet<NhanVien>();
		}
		[Key]
		public int Id { get; set; }
		[DisplayName("Chức vụ")]
		public string ChucVuNhanVien { get; set; }
		public ICollection<NhanVien> nhanViens { get; set; }
	}
}
