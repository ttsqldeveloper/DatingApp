using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite("Data source=datingapp.db"));

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ CORRECT CORS CONFIGURATION - MUST BE BEFORE builder.Build()
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins(
            "http://localhost:4200",      // Angular default
            "http://localhost:60781",      // Keep existing if needed
            "https://localhost:4200"       // HTTPS version if used
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();               // If using authentication
    });
});

// Build the app - ONLY ONCE
var app = builder.Build();

// Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Use CORS middleware - AFTER builder.Build()
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();
app.UseAuthorization();

// Map endpoints
app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();