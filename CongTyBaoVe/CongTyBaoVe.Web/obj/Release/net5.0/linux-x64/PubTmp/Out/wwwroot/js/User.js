window.addEventListener("load", () => {
	calldata()
	
	$(document).on("click", ".add", () => {
		let check = true;
		var input = document.querySelectorAll(".input")
		var label = document.querySelectorAll(".label")		
		for (let i = 0; i < input.length; i++) {
			if (input[i].value == "") {
				var data = label[i].innerHTML;
				alert("Dòng " + data + " không được để trống ")
				check = false
			}			
		}
		if (input[1].value != input[2].value) {
			alert("Nhập lại mật khẩu không trùng khớp")
			check = false
		}
		let username = input[0].value;
		$.post(`/user/checkuser`, { username }, (res) => {
			if (res) {
				alert('Tài khoản đã tồn tại!');
				check = false;
				$("#myModalCreate").show()
            }
		})

		console.log(check);
		setTimeout(() => {
			if (check) {
				var data = $("#form-signup").serialize();
				$.post("/user/singup", data, (data, textstatus, jqXHR) => {
					if (data != null) {
						alert("Tạo tài khoản thành công")
						$("#myModalCreate").hide();
						calldata();
					}
					else {
						alert("tạo tài khoản thất bại")
					}
				})
			}
		}, 1000);
		if (check == false) {
			$("#myModalCreate").show()
        }
		
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
	$('.close').click(() => {
		$("#myModalCreate").hide();
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