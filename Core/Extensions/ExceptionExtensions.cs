namespace Core.Extensions;

public static class ExceptionExtensions
{
    public static void ThrowIfAny(this List<Exception> list) 
    {
        if (list.Any())
            throw new AggregateException(list);
    }
}