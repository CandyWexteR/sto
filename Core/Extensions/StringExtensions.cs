namespace Core.Extensions;

public static class StringExtensions
{
    public static bool IsEmpty(this string value) => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
}