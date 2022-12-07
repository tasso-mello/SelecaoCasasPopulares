namespace repository.casa.popular.Infraestructure
{
    using domain.casa.popular.Entities;
    using Microsoft.EntityFrameworkCore;
    using repository.casa.popular.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> Read(int id);
        Task<T> Read(Guid id);
        Task<IEnumerable<T>> Read();
        Task<IEnumerable<T>> Read(List<string>? includes = null);
        Task<IEnumerable<T>> Read(int skip, int take, List<string>? includes = null);
        Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, List<string>? includes = null);
        Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, int skip, int take, List<string>? includes = null);
        Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, int skip, int take, List<string>? includes = null);
        Task<int> Count();
        Task<int> Count(Expression<Func<T, bool>> where);
        Task<bool> Exists(Expression<Func<T, bool>> where);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<T> Delete(Guid id);
        Task<T> Delete(T entity);
        Task RemoveFromDatabase(T entity);
    }

    public class RepositotyBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly CasaPopularDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        protected RepositotyBase(CasaPopularDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<T> Create(T entity)
        {
            var saved = await _dbSet.AddAsync(entity);
            _dbContext.Entry(entity).State = EntityState.Added;
            await OnBeforeSaving();
            return saved.Entity;
        }
        public virtual async Task<T?> Read(int id) => await _dbSet.FindAsync(id);
        public virtual async Task<T?> Read(Guid id) => await _dbSet.FindAsync(id.ToString());
        public virtual async Task<IEnumerable<T>> Read() => await _dbSet.ToListAsync();
        public virtual async Task<IEnumerable<T>> Read(List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> Read(int skip, int take, List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c).Skip((skip - 1) * take).Take(take);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c).Where(where);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, int skip, int take, List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c).Where(where).Skip((skip - 1) * take).Take(take);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, int skip, int take, List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c).Where(where).OrderBy(orderby).Skip((skip - 1) * take).Take(take);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.ToListAsync();
        }
        public virtual async Task<int> Count()
            => await _dbSet.CountAsync();
        public virtual async Task<int> Count(Expression<Func<T, bool>> where)
             => await _dbSet.Where(where).CountAsync();
        public virtual async Task<bool> Exists(Expression<Func<T, bool>> where)
            => await _dbSet.AnyAsync(where);
        public virtual async Task<T> Update(T entity)
        {
            var updated = _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await OnBeforeSaving();
            return updated.Entity;
        }
        public virtual async Task<T> Delete(int id)
        {
            var deleted = _dbSet.Attach(_dbSet.Find(id));
            _dbContext.Entry(deleted).State = EntityState.Modified;
            await OnBeforeSaving(false);
            return deleted.Entity;
        }
        public virtual async Task<T> Delete(Guid id)
        {
            var deleted = _dbSet.Attach(_dbSet.Find(id));
            _dbContext.Entry(deleted).State = EntityState.Modified;
            await OnBeforeSaving(false);
            return deleted.Entity;
        }
        public virtual async Task<T> Delete(T entity)
        {
            var deleted = _dbSet.Attach(entity);
            _dbContext.Entry(deleted).State = EntityState.Modified;
            await OnBeforeSaving(false);
            return deleted.Entity;
        }

        public virtual async Task RemoveFromDatabase(T entity)
        {
            var deleted = _dbSet.Remove(entity);
            _dbContext.Entry(deleted).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        private async Task OnBeforeSaving(bool isActive = true)
        {
            var entries = _dbContext.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if(entry.Entity is Audit trackable)
                {
                    var now = DateTime.Now;
                    switch (entry.State)    
                    {
                        case EntityState.Modified:
                            trackable.UpdateAt = now;
                            trackable.IsActive = isActive;
                            break;
                        case EntityState.Added:
                            trackable.CreateAt = now;
                            trackable.IsActive = isActive;
                            break;
                    }
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}