#nullable enable
using System;

public static class NullExtensions
{
    public static T EnsureNotNull<T>(this T value, string? message = null)
    {
        if (value == null)
        {
            throw new NullReferenceException(message ?? $"{typeof(T).FullName} is null");
        }

        return value;
    }
}