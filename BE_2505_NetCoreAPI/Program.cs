using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DALImpl;
using BE_2505.DataAccess.Netcore.DBContext;
using BE_2505.DataAccess.Netcore.UnitOfWork;
using BE_2505_NetCoreAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BE_25_05DbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAccountDAO, AccountDAOImpl>();
builder.Services.AddScoped<IStudentDAL, StudentManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork_BE_2505, UnitOfWork_BE_2505>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello world!");
//});
//app.UseMiddleware<MyCustomeMiddleware>();
app.UseCustomMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
