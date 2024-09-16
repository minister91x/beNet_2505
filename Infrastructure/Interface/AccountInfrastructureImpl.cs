
using Domain;
using Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public class AccountInfrastructureImpl : IAccountInfrastructure
    {
        private CleanCodeDbContext _context;

        public AccountInfrastructureImpl(CleanCodeDbContext context)
        {
            _context = context;
        }

        public async Task<CleanCodeAccountLoginResponseData> Login(CleanCodeAccountLoginRequestData requestData)
        {
            var retunData = new CleanCodeAccountLoginResponseData();
            try
            {
               /// var passwordHash = BE_2505.Common.Netcore.Security.ComputeSha256Hash(requestData.Password);
                var account = _context.account.Where(s => s.UserName == requestData.UserName
                && s.Password == requestData.Password).FirstOrDefault();

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


    }
}
