using Microsoft.Extensions.DependencyInjection;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<ICandidateRepository, CandidateRepository>();
builder.Services.AddSingleton<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddSingleton<ICityRepository, CityRepository>();
builder.Services.AddSingleton<ICountryRepository, CountryRepository>();
builder.Services.AddSingleton<ILocationRepository, LocationRepository>();
builder.Services.AddSingleton<IAchievementTypeRepository, AchievementTypeRepository>();
builder.Services.AddSingleton<IUniversityTypeRepository, UniversityTypeRepository>();
builder.Services.AddSingleton<IUniversityRepository, UniversityRepository>();
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

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
