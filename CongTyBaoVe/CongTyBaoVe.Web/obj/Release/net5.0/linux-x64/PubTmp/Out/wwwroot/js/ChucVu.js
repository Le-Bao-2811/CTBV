window.addEventListener("load", () => {
    calldata();
	$(document).on("click", '.add', () => {
		var data = $('#form-create').serialize();
		$.post('/chucvu/create', data, (data, textStatus, jqXHR) => {
			if (data != null) {
				alert("Thêm thành công");
				calldata();
            }
        })
	})

	$(document).on("click", ".js-update", function (ev) {
		var _cv = ev.currentTarget.getAttribute("data-id");
		$.get("/chucvu/edit", { id: _cv },
			function (data, textStatus, jqXHR) {
				$("#update").html(data);

			},
			"html"
		);

	})
	$(document).on("click", ".btnEdit", () => {
		var data = $("#form-update").serialize();
		$.post('/chucvu/edit', data, function (data, textStatus, jqXHR) {
			if (data != "") {
				alert("Cập nhật thành công");
				calldata();
			}
			else {
				alert("cập nhật thất bại");
			}
		})
	})
	$(document).on('click', '.js-delete', (ev) => {
		var id = ev.currentTarget.getAttribute("data-id");
		var comfiml = confirm("Xác nhận xóa chức vụ này");
		if (comfiml == true) {
			$.post("/chucvu/delete/" + id, (data, textStatus, jqXHR) => {
				if (data != null) {
					alert("Xóa thành công");
					calldata();
				}
				else {
					alert("Xóa thất bại");
                }
			})
        }
		
    })
});
var calldata = () => {
    $.get("/chucvu/show", (ev) => {
		var mybody = document.querySelector("#tbody");
		mybody.textContent = "";
        for (let i = 0; i < ev.length; i++) {
            var { chucVuNhanVien, id } = ev[i]
			var html =`<tr>
						<td>
							${id}
						</td>
						<td>
							${chucVuNhanVien}
						</td>
						<td>
							<button type="button" class="btn btn-primary js-update" data-id=${id} data-bs-toggle="modal" data-bs-target="#myModalUpdate">
							Sửa
							</button>
							<a  data-id=${id} class="btn btn-danger js-delete">Xóa</a>
						</td>
					</tr>`
			mybody.insertAdjacentHTML("beforeend", html)
        }
    })
}