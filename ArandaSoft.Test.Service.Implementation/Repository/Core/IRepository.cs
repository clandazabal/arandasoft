namespace ArandaSoft.Test.Service.Implementation.Repository.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        #region Interfaces 

        /// <summary>
        /// Interfaz para la consulta de registros por filtros.
        /// </summary>
        /// <param name="filter">Predicado de la consulta.</param>
        /// <param name="orderBy">Ordenamiento de la cosulta.</param>
        /// <param name="includeProperties">Entidades Relacionadas.</param>
        /// <returns>IEnumerable<EntidadGenerica></returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? page = null, int? pageSize = null, string includeProperties = "");

        /// <summary>
        /// Método genérico para la consulta de un registro por su ID.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Objeto genérico</returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Método genérico para la creación de registros.
        /// </summary>
        /// <param name="entity">objeto genérico</param>
        /// <returns>int</returns>
        Task<int> Create(T entity);

        /// <summary>
        /// Método genérico para la actualización de registros.
        /// </summary>
        /// <param name="entity">objeto genérico</param>
        /// <returns>bool</returns>
        Task<bool> Update(T entity);

        /// <summary>
        /// Método genérico para la eliminación de un registro.
        /// </summary>
        /// <param name="entity">objeto genérico</param>
        /// <returns>Valor booleano</returns>
        Task<bool> Delete(T entity);

        #endregion
    }
}
