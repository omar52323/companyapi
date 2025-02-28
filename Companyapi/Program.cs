using Companyapi.Domain.Entities;
using Companyapi.Domain.Interfaces.Services;
using Companyapi.Domain.Interfaces.Repositories;
using Companyapi.Core.Services;
using Companyapi.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS for all routes
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var globalSettingsSection = builder.Configuration.GetSection("GlobalSettings");
builder.Services.Configure<GlobalSettings>(globalSettingsSection);
var globalSettings = globalSettingsSection.Get<GlobalSettings>();

if (globalSettings == null)
{
    throw new Exception("GlobalSettings no se pudo cargar desde la configuración.");
}
builder.Services.AddSingleton(globalSettings);

// Register services and repositories
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IDbRepository, DbRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Use CORS
app.UseCors();

app.MapControllers();

app.Run();
