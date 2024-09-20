using App.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;


        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new(){Name="Apple", Price= 56, CreatedTime= DateTime.Now, Stock= 10 },

                new(){Name="Samsung", Price= 33, CreatedTime= DateTime.Now, Stock= 22 },

                new(){Name="Techno", Price= 54, CreatedTime= DateTime.Now, Stock= 23 },

                new(){Name="Nokia", Price= 12, CreatedTime= DateTime.Now, Stock= 65 },

                new(){Name="Hawei", Price= 78, CreatedTime= DateTime.Now, Stock= 34 },


            });
            await _productWriteRepository.SaveAsync();
        }

    }
}
