using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models
{
    /// <summary>
    /// Mỗi table cần 1 lớp để thao tác với nó
    /// ví dụ với table Account, cần AccountModel để thao tác qua lại giữa client và server
    /// </summary>
    public class AccountModel
    {
        private OnlineShopDbContext context = null;

        public AccountModel()
        {
            context = new OnlineShopDbContext();
        }

        public bool Login(string userName, string password)
        {
            // Tạo mảng để chứa các tham số được truyền vào Stored Procedure
            object[] sqlParams =
            {
                new SqlParameter("UserName", userName),
                new SqlParameter("Password", password),
            };

            var res = false;
            try
            {
                // - SqlQuery<bool> có thể được sử dụng để trả về các loại dữ liệu khác nhau,
                // tùy vào các Stored Procedure khác nhau
                // - SingleOrDefault để trả về một giá trị duy nhất
                res = context.Database.SqlQuery<bool>("Sp_Account_Login @UserName, @Password", sqlParams).SingleOrDefault();
            }
            catch (Exception e)
            {
                throw;
            }
            return res;
        }
    }
}
