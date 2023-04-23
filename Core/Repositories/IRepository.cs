namespace Core.Repositories;

public interface IRepository<T>
{
    public T? GetById(Guid id);
    public void Update(T model);
    public void Remove(Guid id);
    public void Add(T model);
    public Task<T?> GetByIdAsync(Guid id);
    public Task UpdateAsync(T model);
    public Task RemoveAsync(Guid id);
    public Task AddAsync(T model);
    public Task AddRangeAsync(params T[] items);
}