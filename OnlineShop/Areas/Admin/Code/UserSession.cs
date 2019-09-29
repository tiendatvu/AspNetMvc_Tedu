using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Code
{
    /// <summary>
    /// Để lưu trữ các thông tin về session
    /// [Serializable] dùng để tuần tự hóa thông tin ra nhị phân
    ///                (Tiến trình chuyển một đối tượng thành chuỗi tuần tự các byte để có thể lưu trữ hoặc trao đổ)if
    /// 
    /// </summary>
    [Serializable]
    public class UserSession
    {
        public string UserName { get; set; }
    }
}