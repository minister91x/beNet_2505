using BE_2505.DataAccess.Netcore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_2505_NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
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
    }
}
