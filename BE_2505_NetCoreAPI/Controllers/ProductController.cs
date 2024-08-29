using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;
using BE_2505.DataAccess.Netcore.UnitOfWork;
using BE_2505_NetCoreAPI.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace BE_2505_NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private IProductRepository _productRepository;

        //public ProductController(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        private IUnitOfWork_BE_2505 _iunitOfWork;
        private readonly IDistributedCache _cache;

        public ProductController(IUnitOfWork_BE_2505 iunitOfWork, IDistributedCache cache)
        {
            _iunitOfWork = iunitOfWork;
            _cache = cache;
        }

        [HttpPost("GetProduct")]
        // [BE_2505_Authorize("PRODUCT_GETLIST", "VIEW")]
        public async Task<ActionResult> GetProduct(ProductGetListRequestData requestData)
        {
            var list = new List<Product>();
            try
            {
                var cacheKey = "GetProduct_Caching";

                // Trying to get data from the Redis cache
                byte[] cachedData = await _cache.GetAsync(cacheKey);

                if (cachedData != null)
                {
                    // Trong cache có dữ liệu thì lấy luôn từ cache và trả về client
                    var cachedDataString = Encoding.UTF8.GetString(cachedData);
                    list = JsonConvert.DeserializeObject<List<Product>>(cachedDataString);
                }
                else
                {
                    // Nếu không có dữ liệu trong cache thì vào DB lấy và lưu lại vào cache

                    list = await _iunitOfWork._productGenericRepository.GetAll();

                    var cachedDataString = JsonConvert.SerializeObject(list);
                    var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

                    DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                    await _cache.SetAsync(cacheKey, dataToCache, options);
                }
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("ProductInsertUpdate")]
        public async Task<ActionResult> GetProduct(Product requestData)
        {
            try
            {
                var list = await _iunitOfWork._productRepository.ProductInsertUpdate(requestData, 1);
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
