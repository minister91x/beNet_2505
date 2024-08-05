using BE_2505.DataAccess.Netcore.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC_NetCore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (ModelState.IsValid)
            {
            }
                return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginRequestData requestData)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }

        public async Task<ActionResult> Account_Login(AccountLoginRequestData requestData)
        {
            var returnData = new AccountLoginResponseData();
            try
            {

                if (ModelState.IsValid)
                {
                    returnData.ResponseCode = -1;
                    returnData.ResponseMessenger = "Dữ liệu không hợp lệ";
                    var rs = await new BE_2505.DataAccess.Netcore.DALImpl.AccountDAOImpl().Login(requestData);

                    returnData.ResponseMessenger = rs.ResponseMessenger;
                }

               
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }
    }
}
