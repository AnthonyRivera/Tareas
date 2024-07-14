using Books.Api.Profile;
using Books.Application.Interfaces;
using Books.Application.Services;
using Books.Infraestructure.Repositories;
using Books.Persistence.Context;
using Books.Web.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IBookService, BookService>();
//builder.Services.AddTransient<IRentedService, RentedService>();
builder.Services.AddTransient<IBookRepository, BookEfRepository>();

builder.Services.AddTransient<BookEfRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

//var fronUrl = builder.Configuration["ApplicationConfiguration:FrontUrl"].ToString();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:7135") // Cambia esta URL por la de tu aplicación web
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});
var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

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
