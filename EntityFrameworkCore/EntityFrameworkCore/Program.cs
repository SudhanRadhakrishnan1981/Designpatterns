using EFModellayer.Data;
using EFServiceLayer;
using EFServiceLayer.Service;
using EntityFrameworkCore.FactoryPattern;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CustomerPizzaContext>(options =>
   options
   .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// : 
/*
 builder.Services.AddDbContext<CustomerPizzaContext>(options =>
   options
   .UseLazyLoadingProxies()
   .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
 
 */
//services.AddSingleton<MasterDataService>();

builder.Services.AddScoped<IGet, clsSecond>();
builder.Services.AddScoped<IGet, clsFirst>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
