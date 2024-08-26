using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DBContext;
using BE_2505.DataAccess.Netcore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
    public class AccountDAOImpl : IAccountDAO
    {
        private BE_25_05DbContext _context;

        public AccountDAOImpl(BE_25_05DbContext context)
        {
            _context = context;
        }

        public async Task<int> AccountLogin_UpdateRefeshToken(AccountLogin_UpdateRefeshTokenRequestData requestData)
        {
            try
            {
                var user = _context.account.Where(s => s.ID == requestData.UseId).FirstOrDefault();
                if (user == null || user.ID <= 0)
                {
                    return -1;
                }

                user.RefeshToken = requestData.RefeshToken;
                user.RefeshTokenExpriredTime = requestData.RefeshTokenExpriredTime;
                _context.account.Update(user);

                return _context.SaveChanges();

            }
            catch (Exception ex)
            {

                return -969;
                     
            }

            return 1;
        }

        public async Task<Function> Function_GetByCode(string functionCode)
        {
            return _context.function.Where(s => s.FunctionCode == functionCode ).FirstOrDefault();
        }

        public async Task<AccountLoginResponseData> Login(AccountLoginRequestData requestData)
        {
            var retunData = new AccountLoginResponseData();
            try
            {
                var passwordHash = BE_2505.Common.Netcore.Security.ComputeSha256Hash(requestData.Password);
                var account = _context.account.Where(s => s.UserName == requestData.UserName
                && s.Password == passwordHash).FirstOrDefault();

                if (account == null || account.ID <= 0)
                {
                    retunData.ResponseCode = -1;
                    retunData.ResponseMessenger = "UserName hoặc mật khẩu không hợp lệ!";
                    return retunData;
                }


                retunData.ResponseCode = 1;
                retunData.ResponseMessenger = "Đăng nhập thành công!";
                retunData.account = account;
                return retunData;

            }
            catch (Exception ex)
            {

                throw;
            }

            return retunData;
        }

        public async Task<Permission> Permisson_GetByUserID(int UserID, int functionID)
        {
            return _context.permission.Where(s => s.FuntionID == functionID && s.UserID == UserID).FirstOrDefault();
        }
    }
}
