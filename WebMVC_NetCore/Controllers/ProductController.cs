using BE_2505.DataAccess.Netcore.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebMVC_NetCore.Controllers
{
    public class ProductController : Controller
    {
        private IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ListProductPartial(ProductGetListRequestData requestData)
        {
            var list = new List<Product>();
            try
            {
                // bước 1: lấy url từ file appsetting.json
                var baseurl = _configuration["API:URL"] ?? "";
                var url = "api/Product/GetProduct";
                // từ object -> json 
                var jsonData = JsonConvert.SerializeObject(requestData);
                // bước 1 gọi httppost để đẩy data từ client lên api
                var jsonResponse = await BE_2505.Common.Netcore.HttpHelper.HttpSenPost(baseurl, url, jsonData);
                // bước 2,3,4,5 trên API xử lý
                //bước 6
                if (!string.IsNullOrEmpty(jsonResponse))
                {
                    // convert từ json sang List<Product>
                    list = JsonConvert.DeserializeObject<List<Product>>(jsonResponse);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return PartialView(list);
        }
    }
}
