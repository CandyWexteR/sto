namespace Application.TimeProvider;

public class TimeProvider : ITimeProvider
{
    public Task<DateTime> GetCurrentDateTimeAsync()
    {
        return Task.FromResult(GetCurrentDateTime());
    }

    public Task<DateTimeOffset> GetCurrentDateTimeOffsetAsync()
    {
        return Task.FromResult(GetCurrentDateTimeOffset());
    }

    public DateTime GetCurrentDateTime()
    {
        return DateTime.Now;
    }

    public DateTimeOffset GetCurrentDateTimeOffset()
    {
        return DateTimeOffset.Now;
    }
}