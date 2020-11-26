using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Persistence
{
    public class Entity
    {
        public int Id { get; set; }
    }

    public static class DbSetExtensions
    {
        public static async Task<EntityEntry<T>> AddIfNotExistsAsync<T>(
            this DbSet<T> dbSet, T entity,
            Expression<Func<T, bool>> predicate = null,
                CancellationToken cancellationToken = default) where T : class, new()
        {
            var exists = predicate != null ?
                                    await dbSet.AnyAsync(predicate, cancellationToken: cancellationToken)
                                    : await dbSet.AnyAsync(cancellationToken: cancellationToken);

            if (exists) throw new EntityException($"the {nameof(entity)} already exist");

            return await dbSet.AddAsync(entity, cancellationToken);
        }
    }
}