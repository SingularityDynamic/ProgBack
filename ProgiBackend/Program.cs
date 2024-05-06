using ProgiBackend.Controllers;
using ProgiBackend.Controllers.Interfaces;
using ProgiBackend.Resources;
using ProgiBackend.Resources.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog configuration
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "Logs", $"Log_{DateTime.Today:yyyyMMdd}.txt"))
    .CreateLogger();

// Enable CORS for local use
builder.Services.AddCors(options =>
{
    options.AddPolicy("localhost", policy =>
    {
        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddSerilog();
builder.Services.AddSingleton<IProcessReturn, ProcessReturn>();
builder.Services.AddSingleton<ISaleCalculation, SaleCalculation>();
builder.Services.AddSingleton<IPricingController, PricingController>();
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

app.UseCors("localhost");
app.UseAuthorization();

app.MapControllers();

app.Run();
