using System.Net;
using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IServicioProductos,ServicioProductos>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<SoftijsDevContext>
(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));


var app = builder.Build();

AppContext.SetSwitch("SqlServer.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c=>{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
