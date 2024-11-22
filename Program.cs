using Microsoft.EntityFrameworkCore;
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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
