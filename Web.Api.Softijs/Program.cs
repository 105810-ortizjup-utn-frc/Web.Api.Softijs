using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RazorLight;
using System.Reflection;
using System.Text;
using Web.Api.Softijs.Comun.PDF;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Services;
using Web.Api.Softijs.Services.Comunes;
using Web.Api.Softijs.Services.Pagos;
using Web.Api.Softijs.Services.Security;
using Web.Api.Softijs.Services.Ventas;
using Web.Api.Softijs.Services.Reportes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var processSufix = "32bit";
if (Environment.Is64BitProcess && IntPtr.Size == 8)
{
    processSufix = "64bit";
}
var context = new CustomAssemblyLoadContext();
context.LoadUnmanagedLibrary($"{Directory.GetCurrentDirectory()}\\Comun\\PDF\\PDFNative\\{processSufix}\\libwkhtmltox");

builder.Services.AddScoped<IRazorLightEngine>(sp =>
{
    var engine = new RazorLightEngineBuilder()
        .UseFileSystemProject(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
        .UseMemoryCachingProvider()
        .Build();
    return engine;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IServicioProductos, ServicioProductos>();
builder.Services.AddScoped<IServicioGustos, ServicioGustos>();
builder.Services.AddScoped<IServicioMarcas, ServicioMarcas>();
builder.Services.AddScoped<IServicioCategoria, ServicioCategoria>();
builder.Services.AddScoped<IServicioUnidadesMedidas, ServicioUnidadesMedida>();
builder.Services.AddScoped<IServicioProveedores, ServicioProveedores>();
builder.Services.AddScoped<IServicioPedidos, ServicioPedidos>();
builder.Services.AddScoped<IServicioClientes, ServicioClientes>();
builder.Services.AddScoped<IServicioFormasPagos, ServicioFormasPagos>();
builder.Services.AddScoped<IServicioUsuarios, ServicioUsuarios>();
builder.Services.AddScoped<IServicioEstadosPedidos, ServicioEstadosPedidos>();
builder.Services.AddScoped<IServicioLogin, ServicioLogin>();
builder.Services.AddScoped<IServicioRegister, ServicioRegister>();
builder.Services.AddScoped<IServicioPagos, ServicioPagos>();
builder.Services.AddScoped<IServicioEstadoOP, ServicioEstado>();
builder.Services.AddScoped<IServicioTipoFidelizacion, ServicioTipoFidelizacion>();
builder.Services.AddScoped<IServicioBarrios, ServicioBarrios>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IServicioFacturas, ServicioFacturas>();
builder.Services.AddScoped<IServicioReportes, ServicioReporte>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<SoftijsDevContext>(options => options
.UseSqlServer("Persist Security Info=False;Data Source=2022-softijs-sql-server-dev.database.windows.net;User ID=softijs-web-api;Password=MeGustaElIceCream2022;Initial Catalog=2022-softijs-sql-db-dev"));

var app = builder.Build();

AppContext.SetSwitch("SqlServer.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
