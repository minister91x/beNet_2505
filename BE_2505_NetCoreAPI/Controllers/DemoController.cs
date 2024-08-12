using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_2505_NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IAccountDAO _accountDAO;
        //private readonly IStudentDAL _studentDAL;
        //public DemoController(IAccountDAO accountDAO, IStudentDAL studentDAL)
        //{
        //    _accountDAO = accountDAO;
        //    _studentDAL = studentDAL;
        //}

        public DemoController(IAccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }
        [HttpPost("GetListStudent")]
        public async Task<ActionResult> GetListStudent()
        {
            var list = new List<Student>();
            try
            {
                await Task.Yield();
                for (int i = 0; i < 10; i++)
                {
                    list.Add(new Student
                    {
                        ID = i,
                        Name = "Student " + i
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(list);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(AccountLoginRequestData requestData)
        {
            try
            {
                //var rersult = new BE_2505.DataAccess.Netcore.DALImpl.AccountDAOImpl().Login(requestData);
                var result = await _accountDAO.Login(requestData);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //[HttpPost("GetStudents")]
        //public async Task<ActionResult> GetStudents()
        //{
        //    try
        //    {
        //        //var rersult = new BE_2505.DataAccess.Netcore.DALImpl.AccountDAOImpl().Login(requestData);
        //        var result = await _studentDAL.Baocao();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
    }


}
