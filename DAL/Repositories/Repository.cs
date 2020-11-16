using Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly AirportContext AirportContext;

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
