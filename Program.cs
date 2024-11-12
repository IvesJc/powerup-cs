using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona o Swagger ao pipeline de serviços
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PowerUp",
        Version = "v1",
        Description = 
            "Ellie de Oliveira\n" +
            "RM: 552824\n" +
            "Ives Jundi Chiba\n" +
            "RM: 553243\n" +
            "Nathalia Comeron Freire\n" +
            "RM: 553233\n",
        License = new OpenApiLicense
        {
            Name = "PowerUp",
            Url = new Uri("https://www.fiap.com.br/")
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PowerUp API v1");
    });
}

app.UseHttpsRedirection();


app.Run();
