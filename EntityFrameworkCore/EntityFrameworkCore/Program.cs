using EFModellayer.Data;
using EFServiceLayer;
using EFServiceLayer.RabitMQ;
using EFServiceLayer.RepositoryModule;
using EFServiceLayer.Service;
using EntityFrameworkCore.FactoryPattern;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "EntityFrameworkCore", Version = "v1" }); });


builder.Services.AddDbContext<CustomerPizzaContext>(options =>
   options
   .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();
builder.Services.AddTransient<IEmployees, EmployeeRepository>();
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
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

if (app.Environment.IsDevelopment()) 
{ 
    app.UseDeveloperExceptionPage(); app.UseSwagger();

    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "EntityFrameworkCore V1");
    }); 
} 
else 
{ 
    app.UseHttpsRedirection(); 
    app.UseAuthorization();
    app.MapControllers();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
