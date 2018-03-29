// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using DevOps.Code.DataAccess.Services.DataRepository;
using DevOps.Code.Entities.Interfaces.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DevOps.Code.DataAccess.Services.CachedDataRepository
{
    /// <summary>Represents a generic data-access repository with caching</summary>
    public class CachedRepository<TDbContext, TEntity, TKey> : Repository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        /// <summary>Represents a data-repository cache</summary>
        private readonly ICacheService<TEntity> _cache;

        /// <summary>Constructs a repository instance using the given cache and database context</summary>
        public CachedRepository(ICacheService<TEntity> cache, TDbContext context, ILogger<Repository<TDbContext, TEntity, TKey>> logger) : base(context, logger)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        /// <summary>Adds the entity to the data repository</summary>
        public override async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null) return null;
            _logger.LogInformation("Adding entity to database");
            entity = await base.AddAsync(entity);
            await SaveCacheEntry(entity);
            return entity;
        }

        /// <summary>Finds an entity with the given key</summary>
        public override async Task<TEntity> FindAsync(TKey key)
        {
            _logger.LogInformation("Finding entity in cache");
            var cached = await _cache.FindAsync(key.ToString());
            if (cached != null) return cached;
            _logger.LogInformation("Finding record in database");
            var entity = await base.FindAsync(key);
            if (entity != null) await SaveCacheEntry(entity);
            return entity;
        }

        /// <summary>Removes the entity from the data repository</summary>
        public override async Task RemoveAsync(TKey key)
        {
            _logger.LogInformation("Removing entity from cache");
            await _cache.RemoveAsync($"{typeof(TEntity).FullName}:{key.ToString()}");
            _logger.LogInformation("Removing record from database");
            await base.RemoveAsync(key);
        }

        /// <summary>Replaces an entity in the data repository</summary>
        public override async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null) return null;
            _logger.LogInformation("Updating entity in database");
            entity = await base.UpdateAsync(entity);
            _logger.LogInformation("Updating entity in cache");
            await _cache.SaveAsync(GetCacheKey(entity), entity);
            return entity;
        }

        /// <summary>Gets the string key used to identity the given object in the cache</summary>
        private static string GetCacheKey(TEntity entity) => $"{typeof(TEntity).FullName}:{entity.GetKey()}";

        /// <summary>Saves the given entity object to the cache</summary>
        private async Task SaveCacheEntry()
        {
            _logger.LogInformation("Saving cache entry");
            await _cache.SaveAsync(GetCacheKey(entity), entity);
        }
    }
}
