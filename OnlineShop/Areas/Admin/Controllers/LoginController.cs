using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Models;
using OnlineShop.Areas.Admin.Code;
using OnlineShop.Areas.Admin.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// - ValidateAntiForgeryToken: check token từ client và server -> tính đồng bộ
        ///                             nếu match thì mới xét các bước đăng nhập tiếp theo -> chống việc request liên tục
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Index(LoginModel model)
        {
            // Check kết quả trả về từ việc login
            // kiểm trả ModelState được trả về có valid hay không
            if (Membership.ValidateUser(model.UserName, model.Password) &&
                ModelState.IsValid)
            {
                // Nếu thành công, phải set 1 session
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                // Redirect về trang chủ Home/Index phía ngoài Admin, sau khi đăng nhập thành công
                return RedirectToAction("Index", 
                                        "Home");
            }
            else
            {
                // ModelState ngoài việc lưu trữ tên và giá trị của từng trường,
                // nó cũng theo dõi các lỗi xác thực liên quan
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}
