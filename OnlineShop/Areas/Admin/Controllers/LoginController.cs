using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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


        // - ValidateAntiForgeryToken: check token từ client và server -> tính đồng bộ
        //                             nếu match thì mới xét các bước đăng nhập tiếp theo -> chống việc request liên tục
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountModel().Login(model.UserName, model.Password);
            // Check kết quả trả về từ việc login
            // kiểm trả ModelState được trả về có valid hay không
            if (result && ModelState.IsValid)
            {
                // Nếu thành công, phải set 1 session
                UserSession userSession = new UserSession()
                {
                    UserName = model.UserName
                };
                SessionHelper.SetSession(userSession);
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
    }
}
