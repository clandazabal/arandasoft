namespace ArandaSoft.Test.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using ArandaSoft.Test.Service.Contract;
    using ArandaSoft.Test.Shared.DTO;
    using ArandaSoft.Test.Shared.Parameter;

    public class ProductController : ApiController
    {
        #region Propiedades

        private readonly IProductService _productService;

        #endregion

        #region Constructor

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Get products.
        /// </summary>
        /// <returns>IEnumerable<ProductDTO></returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProductDTO>))]
        public IHttpActionResult Get(string name = null, string description = null, int? idCategory = null, string orderBy = null, string orderType = null, int? page = null, int? pageSize = null)        
        {
            ProductGetParameter parameter = new ProductGetParameter
            {
                Name = name,
                Description = description,
                CategoryId = idCategory
            };

            if (!string.IsNullOrEmpty(orderBy))
            {
                string oBy = orderBy.ToLower();
                if (oBy.ToLower().Equals("name") || oBy.ToLower().Equals("category"))
                {
                    parameter.OrderBy = oBy;
                    if (!string.IsNullOrEmpty(orderType))
                    {
                        string oType = orderType.ToLower();
                        if ((oType.Equals("asc") || oType.ToLower().Equals("desc")))
                        {
                            parameter.OrderType = oType;
                        }
                        else
                        {
                            return BadRequest("El parámetro OrderType no es válido. Los valores permitidos son: 'asc' o 'desc'.");
                        }
                    }
                }
                else
                {
                    return BadRequest("El parámetro OrderBy no es válido. Los valores permitidos son: 'name' o 'category'.");
                }
            }

            if (page != null && pageSize != null)
            {
                parameter.Page = page;
                parameter.PageSize = pageSize;
            }
            
            IEnumerable<ProductDTO> result = _productService.Get(parameter);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="parameter">ProductCreateParameter</param>
        /// <returns>Result</returns>
        [ResponseType(typeof(Result))]
        [HttpPost]
        public async Task<IHttpActionResult> Post(ProductCreateParameter parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productService.Create(parameter);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Actualiza un producto.
        /// </summary>
        /// <param name="parameter">ProductUpdateParameter</param>
        /// <returns>Result</returns>
        [ResponseType(typeof(Result))]
        [HttpPut]
        public async Task<IHttpActionResult> Put(ProductUpdateParameter parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productService.Update(parameter);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Actualiza un producto.
        /// </summary>
        /// <param name="parameter">ProductUpdateParameter</param>
        /// <returns>Result</returns>
        [ResponseType(typeof(Result))]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productService.Delete(id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
