using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.Mappings;
using FootballManager.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AllowNullCollections = true;
}, typeof(PlayersProfile));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ResponseBase<>).Assembly));

builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var connectionString = builder.Configuration.GetConnectionString("FootballManagerDatabaseConnection");
builder.Services.AddDbContext<FootballManagerContext>(opt => opt.UseSqlServer(connectionString));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
