window.addEventListener("load", (e) => {
	calldata();
	//thêm nhân viên

	$(document).on("click", ".add", function () {
		var data = $("#form-create").serialize()
		$.post("/NhanVien/Create", data, function (data, textStatus, jqXHR) {
			if (data == false) {
				alert("thêm thành công")
				calldata();
				
			}
			else {
				alert("thêm thất bại")
			}
		})
		var input = document.querySelectorAll("input");
		for (let i = 0; i < input.length; i++) {
			input[i].value = "";
		}
	})
	//xóa nhân viên
	$(document).on("click", ".js-delete", function (ev) {
		ev.preventDefault();
		var id = ev.currentTarget.getAttribute('data-id')
		var url = 'nhanvien/delete/' + id;
		var bla = confirm("xác nhân xóa");
		if (bla == true) {
			$.post(url, function (data, a, b) {
				if (data = true) {
					alert("Xóa thành công")
					calldata()
                }
            })	
        }
					
	});
	// sửa nhân viên
	$(document).on("click", ".js-update", function (ev) {
		var _nv = ev.currentTarget.getAttribute("data-id");	
		$.get("/nhanvien/edit", { id: _nv },
			function (data, textStatus, jqXHR) {				
				$("#update").html(data);

			},
			"html"
		);
		
	})
	$(document).on("click", ".btnEdit", () => {
		var data = $("#form-update").serialize();
		$.post('/nhanvien/update', data,function (data, textStatus, jqXHR) {
			if (data !="") {
				alert("Cập nhật thành công");
				calldata();
			}
			else {
				alert("cập nhật thất bại");
            }
        })
    })
})
// get danh sach nhan viên
var calldata = () => {
	var mybody = document.querySelector("#body")
	mybody.textContent = '';
	$.get("/nhanvien/show", (ev) => {
		for (let i = 0; i < ev.length; i++) {
			var { id, tenNhanVien, namSinh, sdt, chucVu, trangThai, diaChi } = ev[i];
			var html = `
					<tr>
				<td>
					${id}
				</td>
				<td>
					${tenNhanVien}
				</td>
				<td>
					${namSinh}
				</td>
				<td>
					${diaChi}
				</td>
				<td>
					${sdt}
				</td>
				<td>
					${chucVu}
				</td>
				<td>
					${TrangThai(trangThai, chucVu)}
				</td>
				<td>
					<button type="button" class="btn btn-primary js-update" data-id=${id} data-bs-toggle="modal" data-bs-target="#myModalUpdate">
						Sửa
					</button>
					<a  data-id=${id} class="btn btn-danger js-delete">Xóa</a>
				</td>
			</tr>
					`
			mybody.insertAdjacentHTML("beforeend", html);
		}
	})
}
var TrangThai = (trangThai, chucvu) => {
	var html = '';
	if (trangThai && chucvu == "Nhân Viên Bảo Vệ") {
		html = ` 
					Đang thực hiện nhiệm vụ
				`
	}
	else if (trangThai == false && chucvu == "Nhân Viên Bảo Vệ") {
		html = `
					Chưa có nhiệm vụ`
	}
	else {
		html = `
					Đang làm việc
				`
	}
	return html;
}

