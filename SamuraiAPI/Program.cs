using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var services= builder.Services;

services.AddDbContextFactory<SamuraiContext>(opt=>
opt.UseSqlServer(builder.Configuration.GetConnectionString("SamuraiConnex"),
b=>b.MigrationsAssembly("SamuraiAPI"))
.EnableSensitiveDataLogging()
.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

//services.AddDbContext<SamuraiContext>(opt=>
//opt.UseSqlServer(builder.Configuration.GetConnectionString("SamuraiConnex"),
//b=>b.MigrationsAssembly("SamuraiAPI"))
//.EnableSensitiveDataLogging()
//.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
