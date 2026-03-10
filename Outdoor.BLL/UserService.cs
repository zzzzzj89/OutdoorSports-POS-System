using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outdoor.BLL;
using Outdoor.DAL;
using Outdoor.Models;

namespace Outdoor.BLL
{
    public class UserService
    {
        private UserDAL _userDAL = new UserDAL();
        private LogService _logService = new LogService();

        // 登录逻辑：返回 true 表示成功，false 表示失败，message 返回错误信息
        public bool Login(string username, string password, out string message)
        {
            message = "";

            // 1. 检查输入是否为空
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                message = "用户名或密码不能为空！";
                return false;
            }

            // 2. 调用 DAL 查用户
            var user = _userDAL.GetUserByUsername(username);

            // 3. 判断用户是否存在
            if (user == null)
            {
                message = "用户不存在！";
                return false;
            }

            // 4. 判断密码是否正确 (这里暂时用明文比对，毕业设计中后期可以改为 MD5 加密)
            if (user.Password != password)
            {
                message = "密码错误！";
                return false;
            }

            // 5. 判断账号状态
            if (user.Status == 0) // 假设数据库里 0 是禁用
            {
                message = "该账号已被禁用，请联系管理员。";
                return false;
            }

            // 6. 登录成功！保存到全局上下文
            GlobalContext.CurrentUser = user;
            GlobalContext.CurrentStore = _userDAL.GetStoreById(user.StoreId); // 顺便把门店信息也存下来
            _logService.WriteLog("用户登录", $"用户 [{user.RealName}] 登录系统成功，门店ID: {user.StoreId}");

            return true;
        }
    }
}
