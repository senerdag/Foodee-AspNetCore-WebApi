using Foodee.Application.Interfaces;
using Foodee.Application.Interfaces.CategoryInterfaces;
using Foodee.Application.Interfaces.FoodInterfaces;
using Foodee.Application.Services;
using Foodee.Persistence.Context;
using Foodee.Persistence.Repositories;
using Foodee.Persistence.Repositories.CategoryRepositories;
using Foodee.Persistence.Repositories.FoodRepositories;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddScoped<FoodeeContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepositories));
builder.Services.AddScoped(typeof(IFoodRepository), typeof(FoodRepository));




builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
