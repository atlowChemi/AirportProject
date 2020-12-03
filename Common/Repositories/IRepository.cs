using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repositories
{
    /// <summary>
    /// Simple extendable generic repository.
    /// </summary>
    /// <typeparam name="TEntity">Type of Entity to handle</typeparam>
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Get all TEntities from DbContext.
        /// </summary>
        /// <returns>An <see cref="IQueryable{TEntity}"/> representing the DbSet of the <typeparamref name="TEntity"/> type.</returns>
        /// <exception cref="Exception">An unknown issue happend.</exception>
        IQueryable<TEntity> GetAll();
        /// <summary>
        /// Add a new entity to the DB.
        /// </summary>
        /// <param name="entity">Entity that should be added.</param>
        /// <returns>A <see cref="Task{TEntity}"/> representing the addition to the DB.</returns>
        /// <exception cref="DbException">Unhadled DB exception</exception>
        /// <exception cref="Exception">An unknown issue happend.</exception>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Update a item in the DB.
        /// </summary>
        /// <param name="entity">Entity that should be updated.</param>
        /// <returns>A <see cref="Task{TEntity}"/> representing the update in the DB.</returns>
        /// <exception cref="DbException">Unhadled DB exception</exception>
        /// <exception cref="Exception">An unknown issue happend.</exception>
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
