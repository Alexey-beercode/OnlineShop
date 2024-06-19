using OnlineShop.BLL.Exceptions;

namespace OnlineShop.BLL.Mappers;

public static class StringToGuidMapper
{
    public static Guid ToGuid(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (!Guid.TryParse(value, out var guid))
        {
            throw new MappingException($"The string '{value}' is not a valid Guid.");
        }

        return guid;
    }

    public static string ToString(Guid value)
    {
        return value.ToString();
    }
}