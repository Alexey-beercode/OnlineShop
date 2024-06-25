using OnlineShop.Extensions;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.AddAuthentication();
        builder.AddDatabase();
        builder.AddMapping();
        builder.AddServices();
        builder.AddValidation();
        builder.AddSwaggerDocumentation();
        
        var app = builder.Build();
        app.AddSwagger();
        app.AddApplicationMiddleware();

        app.Run();
    }
}