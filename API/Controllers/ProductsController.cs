using Core.Entities;
using Core.Interfaces;
using infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //[ApiController] // This is responsible for mapping the parameters that are passed 
    /// into a method <summary>
        /// into a method
        /// </summary>
    [ApiController]         
    [Route("api/[Controller]")]


    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();

            return Ok(products);

        }


        [HttpGet("{id}")] /// this id is the parameter that will be passed through in the
                          /// method GetProduct(int id) and ApiController will check whether the method
                          /// passed here are integer or not.
        public async Task<ActionResult<Product>> GetProduct(int id)
        {


            return await _repo.GetProductByIdAsync(id);

        }

/// <summary>
/// Error
/// An unhandled exception occurred while processing the request.
// AmbiguousMatchException: The request matched multiple endpoints. Matches:

// API.Controllers.ProductsController.GetProductBrands (API)
// API.Controllers.ProductsController.GetProduct (API)
// API.Controllers.ProductsController.GetProductTypes (API)

/// Microsoft.AspNetCore.Routing.Matching.DefaultEndpointSelector.ReportAmbiguity(CandidateState[] candidateState)
/// Solution [HttpGet("{brands}")] was replace by [HttpGet("brands")] i.e.
/// the (brands) instead of {brands}. It should be first bracket rather than
/// third bracket.
/// </summary>
/// <returns></returns>
        [HttpGet("brands")]

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());

        }


        [HttpGet("types")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());

        }





    }
}