using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IServicioProductos, ServicioProductos>();
builder.Services.AddScoped<IServicioGustos, ServicioGustos>();
builder.Services.AddScoped<IServicioMarcas, ServicioMarcas>();
builder.Services.AddScoped<IServicioCategoria, ServicioCategoria>();
builder.Services.AddScoped<IServicioUnidadesMedidas, ServicioUnidadesMedida>();
builder.Services.AddScoped<IServicioProveedores, ServicioProveedores>();
builder.Services.AddScoped<IServicioRegister, ServicioRegister>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<SoftijsDevContext>(options => options.UseSqlServer("Persist Security Info=False;Data Source=2022-softijs-sql-server-dev.database.windows.net;User ID=softijs-web-api;Password=MeGustaElIceCream2022;Initial Catalog=2022-softijs-sql-db-dev"));


var app = builder.Build();

AppContext.SetSwitch("SqlServer.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
