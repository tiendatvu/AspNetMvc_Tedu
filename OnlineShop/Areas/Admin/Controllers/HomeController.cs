using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    // khi đăng nhập acc và pass, nếu trỏ đến view của controller này thì thuộc tính [Authorize] sẽ giúp chương trình tự động authorize
    [Authorize]
    // ctr sẽ cho đăng nhập mà không cần authorize nếu view trong controller này được redirect đến, sau khi đăng nhập [AllowAnonymous]
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
