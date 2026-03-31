using System.Collections.Immutable;
using System.Runtime.InteropServices;
using API.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:60781") // Your Angular app URL
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Include if you're using cookies/auth
    });
});
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    
}); 
Builder.Services.Build();
// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Important: Use CORS before MapControllers
app.UseCors("AllowAngularApp");
// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowHeader().AllAnyMethod()
.WithOrigins("http://localhost:60781","https://localhost:60781"));


// Important: Use CORS BEFORE MapControllers
app.UseCors("AllowAll");

// Optional: Use HTTPS redirection
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
