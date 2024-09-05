using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;
using BE_2505.DataAccess.Netcore.UnitOfWork;
using BE_2505_NetCoreAPI.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BE_2505_NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountDAO _accountDAO;
        private IConfiguration _configuration;
        private IUnitOfWork_BE_2505 _unitOfWork;
        public AccountController(IAccountDAO accountDAO, IConfiguration configuration, IUnitOfWork_BE_2505 unitOfWork)
        {
            _accountDAO = accountDAO;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }



        [HttpPost("Login")]
        public async Task<ActionResult> Login(AccountLoginRequestData requestData)
        {
            var returnData = new AccountLoginResponseData();
            try
            {
                // Bước 1: Login

                if (requestData == null
                    || string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.Password))
                {
                    returnData.ResponseCode = -1;
                    returnData.ResponseMessenger = "Dữ liệu đầu vào không hợp lệ!";
                    return Ok(returnData);
                }

                var rs = await _accountDAO.Login(requestData);
                if (rs.ResponseCode <= 0)
                {
                    returnData.ResponseCode = -1;
                    returnData.ResponseMessenger = "UserName hoặc mật khẩu không hợp lệ!";
                    return Ok(returnData);
                }

                var account = rs.account;


                // Bước 2: tạo token và trả về client

                // bước 2.1 tạo list claim đẻ lưu thông tin của account 
                var authClaims = new List<Claim> {
                    new Claim(ClaimTypes.Name, account.UserName),
                    new Claim(ClaimTypes.PrimarySid, account.ID.ToString()) };
                // bước 2.2 : tạo token từ claims 
                var newToken = CreateToken(authClaims);
                // Bước 2.2.1 tạo refeshtoken và lưu db

                var IP = "";
                var remoteIp = HttpContext.Connection.RemoteIpAddress;
                if (remoteIp != null && remoteIp.IsIPv4MappedToIPv6)
                {
                    IP = remoteIp.MapToIPv4().ToString();
                }
                else
                {
                    IP = remoteIp?.ToString();
                }

                /// lưu token vào bảng Session
                var session = new User_Session
                {
                    UserID = account.ID,
                    CreatedTime = DateTime.Now,
                    Token = new JwtSecurityTokenHandler().WriteToken(newToken),
                    IP = IP,
                    DeviceID = "DV"
                };

                _accountDAO.UserSessionInsert(session);

                var RefreshTokenValidityInDays = _configuration["JWT:RefreshTokenValidityInDays"] ?? "";
                var refeshtoken = GenerateRefreshToken();
                var req = new AccountLogin_UpdateRefeshTokenRequestData
                {
                    UseId = account.ID,
                    RefeshToken = refeshtoken,
                    RefeshTokenExpriredTime = DateTime.Now.AddDays(Convert.ToInt32(RefreshTokenValidityInDays))
                };

                var res = _accountDAO.AccountLogin_UpdateRefeshToken(req);

                // bước 2.3 trả về client


                returnData.ResponseCode = 1;
                returnData.ResponseMessenger = "Đăng nhập thành công";
                returnData.token = new JwtSecurityTokenHandler().WriteToken(newToken);
                returnData.refeshtoken = refeshtoken;
                returnData.account = new Account { UserName = account.UserName, ID = account.ID, FullName = account.FullName };
                return Ok(returnData);

            }
            catch (Exception ex)
            {

                throw;
            }
        }



        [HttpPost("Logout")]
        [BE_2505_Authorize("DEFAULT", "VIEW")]
        public async Task<ActionResult> LogOut(AccountLogOutRequestData requestData)
        {
            try
            {
                var IP = "";
                var remoteIp = HttpContext.Connection.RemoteIpAddress;
                if (remoteIp != null && remoteIp.IsIPv4MappedToIPv6)
                {
                    IP = remoteIp.MapToIPv4().ToString();
                }
                else
                {
                    IP = remoteIp?.ToString();
                }

                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var userClaims = identity.Claims;
                var userid = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value);
                var req = new AccountLogOutRequestData
                {
                    IP = IP,
                    token = requestData.token,
                };
                var rs = await _accountDAO.UserSession_Logout(req, userid);

                return Ok(rs);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("GetAccounts")]
        public async Task<ActionResult> GetAccounts(AccountGetListRequestData requestData)
        {
            try
            {
                //var rs = await _unitOfWork._accountADO.GetAccounts(requestData);
                var rs = await _unitOfWork._accountDapper_DAL.GetAccounts(requestData);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Account_Insert")]
        public async Task<ActionResult> Account_Insert(AccountInsertRequestData requestData)
        {
            try
            {
                var rs = await _unitOfWork._accountADO.Account_Insert(requestData);

                return Ok(rs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }


    }
}
