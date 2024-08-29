using BE_2505.DataAccess.Netcore.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Security.Claims;

namespace BE_2505_NetCoreAPI.Filter
{
    public class BE_2505_AuthorizeAttribute : TypeFilterAttribute
    {
        public BE_2505_AuthorizeAttribute(string functionCode = "DEFAULT", string permission = "VIEW")
            : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { functionCode, permission };
        }
    }

    public class AuthorizeActionFilter : IAsyncAuthorizationFilter
    {
        public string _functionCode;
        public string _permission;
        private IAccountDAO _accountDAO;
        public AuthorizeActionFilter(string functionCode, string permission, IAccountDAO accountDAO)
        {
            _functionCode = functionCode;
            _permission = permission;
            _accountDAO = accountDAO;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new
                {
                    Code = System.Net.HttpStatusCode.Unauthorized,
                    Message = "Vui lòng đăng nhập để thực hiện chức năng này "
                });
                return;
            }

            var userClaims = identity.Claims;
            var userid = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value);

            if (userid <= 0)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new
                {
                    Code = System.Net.HttpStatusCode.Unauthorized,
                    Message = "Vui lòng đăng nhập để thực hiện chức năng này "
                });
                return;
            }

            if (_functionCode != "DEFAULT")
            {

                // lấy functionID Theo function code 
                var function = await _accountDAO.Function_GetByCode(_functionCode);
                if (function == null || function.FunctionID <= 0)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        Code = System.Net.HttpStatusCode.Unauthorized,
                        Message = "Không tồn tại chưc năng"
                    });
                    return;
                }
                // lấy permisson
                var per = await _accountDAO.Permisson_GetByUserID(userid, function.FunctionID);
                if (per == null || per.PermissionID <= 0)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        Code = System.Net.HttpStatusCode.Unauthorized,
                        Message = "Không tồn tại QUYÊN"
                    });
                    return;
                }

                switch (_permission)
                {
                    case "VIEW":
                        if (per.IsView == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                Code = System.Net.HttpStatusCode.Unauthorized,
                                Message = "Bạn không có quyền"
                            });
                            return;
                        }
                        break;

                    case "INSERT":

                        break;

                    case "UPDATE":

                        break;
                }
            }

        }
    }
}
