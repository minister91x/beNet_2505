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
            return View();
        }

        public async Task<JsonResult> Account_Login(AccountLoginRequestData requestData)
        {
            var returnData = new AccountLoginResponseData();
            try
            {
                var rs = await new BE_2505.DataAccess.Netcore.DALImpl.AccountDAOImpl().Login(requestData);

                returnData.ResponseMessenger = rs.ResponseMessenger;
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(returnData);
        }
    }
}
