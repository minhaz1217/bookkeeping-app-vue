using BookKeeping.API;
using BookKeeping.API.Controllers;
using BookKeeping.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

DependencyRegisterer.Register(builder);

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            "AllowCors",
            builder =>
            {
                builder.AllowAnyOrigin().WithMethods(
                    HttpMethod.Get.Method,
                    HttpMethod.Put.Method,
                    HttpMethod.Post.Method,
                    HttpMethod.Delete.Method).AllowAnyHeader().WithExposedHeaders("CustomHeader");
            });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowCors");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
