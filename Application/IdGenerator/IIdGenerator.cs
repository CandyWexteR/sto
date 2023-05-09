namespace Application.IdGenerator;

public interface IIdGenerator
{
    public Guid GenerateGuid();
    public Task<Guid> GenerateGuidAsync();
}