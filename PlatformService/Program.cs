using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseInMemoryDatabase("InMem");
    // .UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn"));
});

builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

PrepDb.PrepPopulation(app, app.Environment.IsProduction());

app.Run();
