using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;
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
        public AccountController(IAccountDAO accountDAO, IConfiguration configuration)
        {
            _accountDAO = accountDAO;
            _configuration = configuration;
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
                account.Password = string.Empty;

                // Bước 2: tạo token và trả về client

                // bước 2.1 tạo list claim đẻ lưu thông tin của account 
                var authClaims = new List<Claim> {
                    new Claim(ClaimTypes.Name, account.UserName),
                    new Claim(ClaimTypes.PrimarySid, account.ID.ToString()) };
                // bước 2.2 : tạo token từ claims 
                var newToken = CreateToken(authClaims);
                // Bước 2.2.1 tạo refeshtoken và lưu db

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
                returnData.account = account;
                return Ok(returnData);

            }
            catch (Exception ex)
            {

                throw;
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
