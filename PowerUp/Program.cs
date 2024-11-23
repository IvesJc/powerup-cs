using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PowerUp.Data;
using PowerUp.Services;
using PowerUp.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
});

// Register the Swagger generator, defining 1 or more Swagger documents  
builder.Services.AddSwaggerGen(c =>  
{  
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PowerUp", Version = "v1" });                  
});  
builder.Services.AddControllers();  

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IAlternativaService, AlternativaServiceImpl>();
builder.Services.AddScoped<IArtigoService, ArtigoServiceImpl>();
builder.Services.AddScoped<IDesafioService, DesafioServiceImpl>();
builder.Services.AddScoped<IEmblemaConfigService, EmblemaConfigServiceImpl>();
builder.Services.AddScoped<IEmblemaService, EmblemaServiceImpl>();
builder.Services.AddScoped<IEmblemaTipoService, EmblemaTipoServiceImpl>();
builder.Services.AddScoped<ILinkService, LinkServiceImpl>();
builder.Services.AddScoped<IMissaoConfigService, MissaoConfigServiceImpl>();
builder.Services.AddScoped<IMissaoService, MissaoServiceImpl>();
builder.Services.AddScoped<IModuloEducativoService, ModuloEducativoServiceImpl>();
builder.Services.AddScoped<IPerguntaService, PerguntaServiceImpl>();
builder.Services.AddScoped<IPermissaoService, PermissaoServiceImpl>();
builder.Services.AddScoped<IQuizService, QuizServiceImpl>();
builder.Services.AddScoped<IRankingService, RankingServiceImpl>();
builder.Services.AddScoped<IRecompensaConfigService, RecompensaConfigServiceImpl>();
builder.Services.AddScoped<IRecompensaService, RecompensaServiceImpl>();
builder.Services.AddScoped<IRecompensaTipoService, RecompensaTipoServiceImpl>();
builder.Services.AddScoped<IUsuarioService, UsuarioServiceImpl>();

var app = builder.Build();


app.UseHttpsRedirection();
// app.UseStaticFiles();

// app.UseRouting();

app.UseAuthorization();



// Enable middleware to serve generated Swagger as a JSON endpoint.  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthorization();

app.MapControllers();
app.Run();
