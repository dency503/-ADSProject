using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

// Agregar servicios a la container.
builder.Services.AddControllers();

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurando inyección de dependencias
builder.Services.AddScoped<IEstudiante, EstudianteRepository>();
builder.Services.AddScoped<ICarrera, CarreraRepository>();
builder.Services.AddScoped<IMateria, MateriaRepository>();
builder.Services.AddScoped<IProfesor, ProfesorRepository>();
builder.Services.AddScoped<IGrupo, GrupoRepository>();
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        configuration =>
        {
            configuration.WithOrigins(builder.Configuration["allowedOrigins"]!)
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
