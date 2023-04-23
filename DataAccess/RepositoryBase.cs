using Core.Models;
using Core.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class RepositoryBase<T> : IRepository<T> where T: class, IdableEntity 
{
    private readonly DatabaseContext _context;
    private readonly DbSet<T> _dbSet;

    public RepositoryBase(DatabaseContext context, DbSet<T> dbSet)
    {
        _context = context;
        _dbSet = dbSet;
    }

    public T? GetById(Guid id)
    {
        return _dbSet.AsNoTracking().FirstOrDefault(v => v.Id == id);
    }

    public void Update(T model)
    {
        _dbSet.Update(model);
        _context.SaveChanges();
    }

    public void Remove(Guid id)
    {
        var entity = _dbSet.FirstOrDefault(v => v.Id == id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
        _context.SaveChanges();
    }

    public void Add(T model)
    {
        _dbSet.Add(model);
        _context.SaveChanges();
    }

    public Task<T?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_dbSet.FirstOrDefault(v => v.Id == id));
    }

    public Task UpdateAsync(T model)
    {
        _dbSet.Update(model);
        return _context.SaveChangesAsync();
    }

    public Task RemoveAsync(Guid id)
    {
        var entity = _dbSet.FirstOrDefault(v => v.Id == id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }

        return _context.SaveChangesAsync();
    }

    public Task AddAsync(T model)
    {
        _dbSet.Add(model);
        return _context.SaveChangesAsync();
    }

    public Task AddRangeAsync(params T[] items)
    {
        _dbSet.AddRange(items);
        return _context.SaveChangesAsync();
    }
}