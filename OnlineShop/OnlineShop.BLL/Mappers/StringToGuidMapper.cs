using OnlineShop.BLL.Services.Exceptions;

namespace OnlineShop.BLL.Validators;

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
            throw new ConvertationException($"The string '{value}' is not a valid Guid.");
        }

        return guid;
    }
}