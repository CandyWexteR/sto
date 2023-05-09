namespace Core.Extensions;

public static class ExceptionExtensions
{
    public static void ThrowIfAny(this List<Exception> list) 
    {
        if (list.Any())
            throw new AggregateException(list);
    }

    public static void ThrowIfNull(this object? value, string message = "Значение не может null")
    {
        if (value == null)
            throw new Exception(message);
    }
    public static void ThrowIfNotNull(this object? value, string message = "Значение должно быть null")
    {
        if (value != null)
            throw new Exception(message);
    }
}