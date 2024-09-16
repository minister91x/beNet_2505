using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IAccountInfrastructure
    {
        Task<CleanCodeAccountLoginResponseData> Login(CleanCodeAccountLoginRequestData requestData);
    }
}
