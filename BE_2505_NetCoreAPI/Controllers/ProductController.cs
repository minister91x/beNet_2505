using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;
using BE_2505.DataAccess.Netcore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public ProductController(IUnitOfWork_BE_2505 iunitOfWork)
        {
            _iunitOfWork = iunitOfWork;
        }

        [HttpPost("GetProduct")]
        public async Task<ActionResult> GetProduct(ProductGetListRequestData requestData)
        {
            try
            {
                var list = await _iunitOfWork._productGenericRepository.GetAll();
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
