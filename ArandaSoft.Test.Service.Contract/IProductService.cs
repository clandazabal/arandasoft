namespace ArandaSoft.Test.Service.Contract
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArandaSoft.Test.Shared.DTO;
    using ArandaSoft.Test.Shared.Parameter;

    public interface IProductService
    {
        #region Interfaces

        /// <summary>
        /// Creación de un producto. 
        /// </summary>
        /// <param name="parameter">ProductCreateParameter</param>
        /// <returns>Result</returns>
        Task<Result> Create(ProductCreateParameter parameter);

        /// <summary>
        /// Actualización de un producto.
        /// </summary>
        /// <param name="parameter">ProductUpdateParameter</param>
        /// <returns>Result</returns>
        Task<Result> Update(ProductUpdateParameter parameter);

        /// <summary>
        /// Eliminación de un producto. 
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <returns>Result</returns>
        Task<Result> Delete(int id);

        /// <summary>
        /// Obtiene el listado de productos de acuerdo a la consulta realizada.
        /// </summary>
        /// <param name="parameter">Parámetros de la consulta</param>
        /// <returns>IEnumerable<ProductDTO></returns>>
        IEnumerable<ProductDTO> Get(ProductGetParameter parameter);

        #endregion
    }
}
