using application.UseCase;
using infrastructure.data;
using infrastructure.adapters;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppointmentDbContext>(options => options.UseInMemoryDatabase("AppointmentDb"));
builder.Services.AddScoped<domain.repositories.IAppointmentRepository, AppointmentAdapters>();
builder.Services.AddScoped<CreateUseCase>();
builder.Services.AddScoped<GetByIdUseCase>();
builder.Services.AddScoped<GetByPlaqueUseCase>();
builder.Services.AddControllers();

builder.Services.AddOpenApi();
//Cors
builder.Services.AddCors(options =>
{
options.AddPolicy("Angular",builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(); // Add this to enable the visual UI
app.UseAuthorization();
app.UseCors("Angular");
app.MapControllers();

app.Run();