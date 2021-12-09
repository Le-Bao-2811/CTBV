window.addEventListener("load", () => {
	calldata()
	$(document).on("click", ".add", () => {
		var data = $("#form-signup").serialize();
		$.post("/user/singup", data, (data, textstatus, jqXHR) => {
			if (data != null) {
				alert("Tạo tài khoản thành công")
				calldata();
			}
			else {
				alert("tạo tài khoản thất bại")
            }
		})
	})
	$(document).on("click", ".js-delete", (ev) => {
		var id = ev.currentTarget.getAttribute("data-id")
		var confilm = confirm("Bạn có muốn xóa tài khoản này");
		if (confilm) {
			$.post("/user/delete/" + id, (data, a, b) => {
				if (data != null) {
					alert("Xóa thành công")
					calldata();
				}
				else {
					alert("Xóa thất bại")
                }
			})
        }
		
	})
})
var calldata = () => {
    var mybody = document.querySelector("#tbody")
    mybody.textContent = ''
    $.get("/user/show", (ev) => {
		for (let i = 0; i < ev.length; i++) {
			var { id, userName, isAdmin } = ev[i];
			var html =`<tr>
						<td>
							${id}
						</td>
						<td>
							${userName}
						</td>
						<td>
							${Check(isAdmin)}
						</td>
						<td>
							<a class="btn btn-danger js-delete" data-id=${id}>Xóa</a>
						</td>
					</tr>`
			mybody.insertAdjacentHTML("beforeend", html)
        }
    })
}
var Check = (isadmin) => {
	var html = "";
	if (isadmin) {
		html = "Admin";
	}
	else {
		html = "Member";
	}
	return html;
}