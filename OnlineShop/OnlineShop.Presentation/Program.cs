using OnlineShop.Extensions;

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
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapGet("/", () => "Hello World!");
app.Run();