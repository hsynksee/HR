
using AutoMapper;
using HR.Api.Infrastructure.ServiceCollectionExtensions;
using HR.Data;
using HR.Data.Abstractions;
using HR.Service.AppSettings;
using HR.Service.AutoMapper;
using HR.Service.ServiceInterfaces;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SharedKernel.Abstractions;
using SharedKernel.FileUploader.Models;
using SharedKernel.Helpers;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<HumanResourcesContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"),
    b => b.MigrationsAssembly(typeof(HumanResourcesContext).Assembly.FullName)));


builder.Services.AddDependencyInjectionSetup();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins("http://localhost:4200");
        });
});

var provider = builder.Services.BuildServiceProvider();

IHttpContextAccessor _httpContextAccessor = provider.GetService<IHttpContextAccessor>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperService());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddHttpContextAccessor();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Version = "v1",
        Title = "User Management Api",
        Description = "Api for User Management",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Name = "Info",
            Email = "bilgilendirme-it@cesargroup.com.tr",
            Url = new Uri("https://cesargroup.com.tr")
        },
    });
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.BuildAuthentication(builder.Configuration, _httpContextAccessor);

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api For ValeApi v1");
    c.DisplayRequestDuration();
    c.EnableDeepLinking();
    c.EnableValidator();
    c.DocExpansion(DocExpansion.None);
    c.DocumentTitle = "Api For User Management v1";
});

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
