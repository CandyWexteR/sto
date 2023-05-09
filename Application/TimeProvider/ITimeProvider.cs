namespace Application.TimeProvider;

public interface ITimeProvider
{
    public Task<DateTime> GetCurrentDateTimeAsync();
    public Task<DateTimeOffset> GetCurrentDateTimeOffsetAsync();
    public DateTime GetCurrentDateTime();
    public DateTimeOffset GetCurrentDateTimeOffset();
}