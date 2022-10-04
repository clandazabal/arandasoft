namespace ArandaSoft.Test.Service.Implementation.Service
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArandaSoft.Test.Model.Entity;
    using ArandaSoft.Test.Service.Contract;
    using ArandaSoft.Test.Service.Implementation.AppService;
    using ArandaSoft.Test.Service.Implementation.Repository.Persistence;
    using ArandaSoft.Test.Shared.DTO;
    using ArandaSoft.Test.Shared.Parameter;
    using System.Linq.Expressions;

    public class ProductService : IProductService
    {
        #region Propiedades

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Obtiene el listado de productos de acuerdo a la consulta realizada.
        /// </summary>
        /// <param name="parameter">Parámetros de la consulta</param>
        /// <returns>IEnumerable<ProductDTO></returns>
        public IEnumerable<ProductDTO> Get(ProductGetParameter parameter)
        {
            Result result = new Result();

            try
            {
                var query = _productRepository.Get(SetPredicate(parameter), SetOrder(parameter), parameter.Page, parameter.PageSize, "ProductCategory");
                return AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(query);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return null;            
        }

        /// <summary>
        /// Creación de un producto.
        /// </summary>
        /// <param name="parameter">Parámetros de la creación de un producto.</param>
        /// <returns>Result</returns>
        public async Task<Result> Create(ProductCreateParameter parameter)
        {
            Result result = new Result();

            try
            {
                Product product = new Product
                {
                    CategoryId = parameter.CategoryId,
                    Name = parameter.Name,
                    Description = parameter.Description,
                    Image = parameter.Image
                };

                var query = await _productRepository.Create(product);

                if (query > 0)
                {
                    result.Success = true;
                    result.Message = $"El producto [{product.Name}] se ha creado exitosamente.";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Actualización de un producto. 
        /// </summary>
        /// <param name="parameter">Parámetros de la actualización de un producto.</param>
        /// <returns>Result</returns>
        public async Task<Result> Update(ProductUpdateParameter parameter)
        {
            Result result = new Result();

            try
            {
                var product = await _productRepository.GetById(parameter.ID);

                if (product != null)
                {
                    if (parameter.CategoryId != null && parameter.CategoryId != product.CategoryId) product.CategoryId = (int)parameter.CategoryId;
                    if (!string.IsNullOrEmpty(parameter.Name) && parameter.Name != product.Name) product.Name = parameter.Name;
                    if (!string.IsNullOrEmpty(parameter.Description) && parameter.Description != product.Description) product.Description = parameter.Description;
                    if (parameter.Image != null && parameter.Image != product.Image) product.Image = parameter.Image;

                    var query = await _productRepository.Update(product);

                    if (query)
                    {
                        result.Success = true;
                        result.Message = $"El producto [{product.Name}] se ha actualizado exitosamente.";
                    }
                    else
                    {
                        result.Message = $"El producto no existe. Intente nuevamente.";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Eliminación de un producto. 
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <returns>Result</returns>
        public async Task<Result> Delete(int id)
        {
            Result result = new Result();

            try
            {
                var product = await _productRepository.GetById(id);

                if (product != null)
                {
                    var query = await _productRepository.Delete(product);

                    if (query)
                    {
                        result.Success = true;
                        result.Message = $"El producto [{product.Name}] se ha eliminado exitosamente.";
                    }
                }
                else
                {
                    result.Message = $"El producto no existe. Intente nuevamente.";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Generación de ordenamiento dinámico
        /// </summary>
        /// <param name="parameter">ProductGetParameter</param>
        /// <returns>Func<IQueryable<Product>, IOrderedQueryable<Product>></returns>
        private Func<IQueryable<Product>, IOrderedQueryable<Product>> SetOrder(ProductGetParameter parameter)
        {
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderExpression = null;
            bool shortDefault = false;

            if (!string.IsNullOrEmpty(parameter.OrderBy))
            {
                if (!string.IsNullOrEmpty(parameter.OrderType))
                {
                    if (parameter.OrderType.Equals("desc"))
                    {
                        switch (parameter.OrderBy)
                        {
                            case "name":
                                orderExpression = o => o.OrderByDescending(p => p.Name);
                                break;
                            case "category":
                                orderExpression = o => o.OrderByDescending(p => p.ProductCategory.Name);
                                break;
                            default:
                                orderExpression = null;
                                break;
                        }
                    }
                    else
                    {
                        shortDefault = true;
                    }
                }
                else
                {
                    shortDefault = true;
                }
            }
            else
            {
                orderExpression = o => o.OrderBy(p => p.Id);
            }

            if (shortDefault)
            {
                switch (parameter.OrderBy)
                {
                    case "name":
                        orderExpression = o => o.OrderBy(p => p.Name);
                        break;
                    case "category":
                        orderExpression = o => o.OrderBy(p => p.ProductCategory.Name);
                        break;
                    default:
                        orderExpression = null;
                        break;
                }
            }

            return orderExpression;
        }

        /// <summary>
        /// Generación de consulta dinámica.
        /// </summary>
        /// <param name="parameter">ProductGetParameter</param>
        /// <returns>Expression<Func<Product, bool>></returns>
        private Expression<Func<Product, bool>> SetPredicate(ProductGetParameter parameter)
        {
            var predicate = PredicateBuilder.True<Product>();

            if (!string.IsNullOrEmpty(parameter.Name)) predicate = predicate.And(x => x.Name.Equals(parameter.Name));
            if (!string.IsNullOrEmpty(parameter.Description)) predicate = predicate.And(x => x.Description.Equals(parameter.Description));
            if (parameter.CategoryId != null && parameter.CategoryId > 0) predicate = predicate.And(x => x.CategoryId == parameter.CategoryId);

            return predicate;
        }

        #endregion
    }
}
