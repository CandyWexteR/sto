using Core.Models;
using Core.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class JsonbRepository<T> : IRepository<T> where T : IdableEntity
{
    private readonly DatabaseContext _context;

    public JsonbRepository(DatabaseContext context)
    {
        _context = context;
    }

    protected IEnumerable<T> Database => _context.Jsonbs.AsNoTracking().Select(b => b.Deserialize<T>());

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return _context.Jsonbs.AsNoTracking().Where(v => v.Type == typeof(T).Name).Select(v => v.Deserialize<T>());
    }

    public T? GetById(Guid id)
    {
        return Database.FirstOrDefault(b=>b.Id == id);
    }

    public void Update(T model)
    {
        _context.Jsonbs.Update(model.ToJsonb());
        _context.SaveChanges();
    }

    public void Remove(Guid id)
    {
        var item = _context.Jsonbs.FirstOrDefault(v => v.Id == id) ?? throw new Exception("NotFound");
        _context.Jsonbs.Remove(item);
        _context.SaveChanges();
    }

    public void Add(T model)
    {
        _context.Jsonbs.Add(model.ToJsonb());
        _context.SaveChanges();
    }

    public Task<T?> GetByIdAsync(Guid id) => Task.FromResult(Database.FirstOrDefault(v => v.Id == id));

    public Task UpdateAsync(T model)
    {
        _context.Jsonbs.Update(model.ToJsonb());
        return _context.SaveChangesAsync();
    }

    public Task RemoveAsync(Guid id)
    {
        var item = _context.Jsonbs.FirstOrDefault(v => v.Id == id) ?? throw new Exception("NotFound");
        _context.Jsonbs.Remove(item);
        return _context.SaveChangesAsync();
    }

    public Task AddAsync(T model)
    {
        _context.Jsonbs.Add(model.ToJsonb());
        return _context.SaveChangesAsync();
    }

    public Task AddRangeAsync(params T[] items)
    {
        _context.Jsonbs.AddRange(items.Select(v => v.ToJsonb()));
        return _context.SaveChangesAsync();
    }
}