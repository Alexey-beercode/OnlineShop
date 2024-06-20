using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.BLL.Entities.Validators;
using OnlineShop.BLL.Services.Implementations;
using OnlineShop.BLL.Services.Interfaces;
using OnlineShop.DAL.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
//idk how do it in right way (first theoreticaly not working)
//builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
//builder.Services.AddValidatorsFromAssembly(typeof(OrderItemValidator).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<OrderItemValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresDatabase")));

builder.Services.AddSwaggerGen();

//TODO: need to learn how it works
TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
builder.Services.AddMapster();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();