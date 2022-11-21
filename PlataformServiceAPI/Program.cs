using Microsoft.EntityFrameworkCore;
using PlataformServiceAPI.Data;
using PlataformServiceAPI.Repositories;
using PlataformServiceAPI.SyncDateService.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
Console.WriteLine($"--> CommandService Endpoint {builder.Configuration["CommandService"]}");

#region Scope
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
#endregion

#region ImMemoryDb
//var connection = builder.Configuration.GetConnectionString();
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("ImMem"));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

PrepDb.PrepPopulation(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
