
using Application.IRepository;
using Domain;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class AccountApplication : IAccountApplication
    {
        private IAccountInfrastructure _infrastructure;

        public AccountApplication(IAccountInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }

        public async Task<CleanCodeAccountLoginResponseData> Login(CleanCodeAccountLoginRequestData requestData)
        {
            var returnData = new CleanCodeAccountLoginResponseData();
            try
            {
                if (requestData == null)
                {
                    returnData.ResponseCode = -1;
                    returnData.ResponseMessenger = "Dữ liệu không hợp";
                    return returnData;
                }

                returnData = await _infrastructure.Login(requestData);
                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }

            return returnData;
        }
    }
}
