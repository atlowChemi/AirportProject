using Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    /// <summary>
    /// Simple extendable generic repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity the repository should handle.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// The context of the the DB.
        /// </summary>
        protected readonly AirportContext AirportContext;

        /// <summary>
        /// Create new reposirty.
        /// </summary>
        /// <param name="airportContext">Airport context object.</param>
        public Repository(AirportContext airportContext)
        {
            AirportContext = airportContext;
        }

        
        public virtual IQueryable<TEntity> GetAll()
        {
            try
            {
                return AirportContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            try
            {
                EntityEntry<TEntity> entry = await AirportContext.AddAsync(entity);
                await AirportContext.SaveChangesAsync();
                return entry.Entity;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Issue while saving to DB: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            try
            {
                AirportContext.Update(entity);
                await AirportContext.SaveChangesAsync();
                return entity;
            }

            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Issue while saving to DB: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    } 
}
