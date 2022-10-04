namespace ArandaSoft.Test.Service.Implementation.Repository.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using ArandaSoft.Test.Model.Context;
    using ArandaSoft.Test.Service.Implementation.Repository.Core;

    public class Repository<T> : IRepository<T> where T : class
    {
        #region Propiedades

        private readonly ArandaSoftTestContext _context;
        private readonly DbSet<T> _dbSet;

        #endregion

        #region Constructor

        public Repository(ArandaSoftTestContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método genérico para la consulta de un registro por su ID.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Objeto genérico</returns>
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Método genérico para la creación de un nuevo registro.
        /// </summary>
        /// <param name="entity">objeto genérico</param>
        /// <returns>int</returns>
        public async Task<int> Create(T entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Método genérico para la actualización de un registro.
        /// </summary>
        /// <param name="entity">objeto genérico</param>
        /// <returns>Valor booleano</returns>
        public async Task<bool> Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Método genérico para la eliminación de un registro.
        /// </summary>
        /// <param name="entity">objeto genérico</param>
        /// <returns>Valor booleano</returns>
        public async Task<bool> Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Método para la consulta de registros por filtros.
        /// </summary>
        /// <param name="filter">Predicado de la consulta.</param>
        /// <param name="orderBy">Ordenamiento de la cosulta.</param>
        /// <param name="includeProperties">Entidades Relacionadas.</param>
        /// <returns>IEnumerable<EntidadGenerica></returns>
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? page = null, int? pageSize = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (orderBy != null) query = orderBy(query);

            if (filter != null)
            {
                if (page != null && pageSize != null)
                {
                    query = query.Where(filter).Skip(((int)page - 1) * (int)pageSize).Take((int)pageSize);
                }
                else
                {
                    query = query.Where(filter);
                }
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        #endregion
    }
}
