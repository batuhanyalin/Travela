using Travela.BusinessLayer.Abstract;
using Travela.BusinessLayer.Concrete;
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Context;
using Travela.DataAccessLayer.Entity_Framework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TravelaContext>();
builder.Services.AddScoped<ICategoryDal,EFCategoryDal>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IDestinationDal, EFDestinationDal>();
builder.Services.AddScoped<IDestinationService, DestinationManager>();
builder.Services.AddHttpClient(); //HttpClient constructure metot olarak yazýldýðý için programa tanýtýlýyor.
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
