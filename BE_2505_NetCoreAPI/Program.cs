using Application.IRepository;
using Application.Repository;
using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DALImpl;
using BE_2505.DataAccess.Netcore.Dapper;
using BE_2505.DataAccess.Netcore.DBContext;
using BE_2505.DataAccess.Netcore.DTO;
using BE_2505.DataAccess.Netcore.UnitOfWork;
using BE_2505_NetCoreAPI;
using BE_2505_NetCoreAPI.Logging;
using Infrastructure.DBContext;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
NLog.LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/NLog.config"));
builder.Services.AddDbContext<CleanCodeDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ConnStr")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = false,
        ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
        ValidAudience = builder.Configuration["Jwt:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<IAccountDAO, AccountDAOImpl>();
//builder.Services.AddScoped<IAccountADO_DAL, AccountADO_ImplDAL>();
//builder.Services.AddScoped<IAccountDapper_DAL, AccountDapper_Impl>();
//builder.Services.AddScoped<IStudentDAL, StudentManager>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProductGenericRepository, ProductGenericRepository>();
//builder.Services.AddScoped<IUnitOfWork_BE_2505, UnitOfWork_BE_2505>();
builder.Services.AddScoped<IApplicationDbConnection, ApplicationDbConnection>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddTransient<IAccountApplication, AccountApplication>();
builder.Services.AddTransient<IAccountInfrastructure, AccountInfrastructureImpl>();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = configuration["RedisCacheUrl"]; });

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx => {
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers",
          "Origin, X-Requested-With, Content-Type, Accept");
    },
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Images")),
    RequestPath = "/Images"
});

app.Run();
