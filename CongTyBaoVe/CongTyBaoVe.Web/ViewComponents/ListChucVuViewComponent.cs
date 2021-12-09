using CongTyBaoVe.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.ViewComponents
{
    public class ListChucVuViewComponent: ViewComponent
    {
        readonly ChucVuRepository rp;
        public ListChucVuViewComponent(ChucVuRepository _rp)
        {
            rp = _rp;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? seletetedId)
        {
            var data = await rp.ToList();         
            ViewBag.SelectedId = seletetedId;
            return View(data);
        }
    }
}
