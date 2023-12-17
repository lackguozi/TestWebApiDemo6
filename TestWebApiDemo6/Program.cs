using TestWebApiDemo6.Extension;
using TestWebApiDemo6.Interface;
using TestWebApiDemo6.Resposity;
using TestWebApiDemo6.UnitofWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlSugarSetup(builder.Configuration);
builder.Services.AddSingleton<IUnitOfWorkManger,UnitOfWorkManager>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
