using Microsoft.EntityFrameworkCore;
using ReenbitTestTask.Data;
using ReenbitTestTask.Repository;
using ReenbitTestTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Azure Repository Service
builder.Services.AddTransient<IAzureStorage, AzureStorage>();

builder.Services.AddCors();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
          //.AllowCredentials()
          );

app.UseAuthorization();

app.MapControllers();

app.Run();
