using EmployeeServiceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeServiceAPI", Version = "v1" });
});



// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Note: AddOpenApi is not a built-in extension; AddSwaggerGen() above already registers Swagger.
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDb")));
    
builder.Services.AddScoped<IEmployeeDataAccess, EmployeeDataAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeServiceAPI v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


