namespace Application.IdGenerator;

public class IdGenerator : IIdGenerator
{
    public Guid GenerateGuid()
    {
        return Guid.NewGuid();
    }

    public Task<Guid> GenerateGuidAsync()
    {
        return Task.FromResult(GenerateGuid());
    }
}