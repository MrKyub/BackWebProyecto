using APIRestTraining.Datos.Colegio;
using APIRestTraining.Datos.Colegio.Implementacion;
using APIRestTraining.Model.Conexion;
using APIRestTraining.Negocio.Colegio;
using APIRestTraining.Negocio.Colegio.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ConexionSQL>();
builder.Services.AddScoped<IServicioAlumno, ServicioAlumno>();
builder.Services.AddScoped<IAlumnoDataMapper, AlumnosDataMapper>();

builder.Services.AddScoped<IServicioDocente, ServicioDocente>();
builder.Services.AddScoped<IDocenteDataMapper, DocenteDataMapper>();

builder.Services.AddScoped<IServicioCarrera, ServicioCarrera>();
builder.Services.AddScoped<ICarreraDataMapper, CarreraDataMapper>();


builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("NUeva politica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NUeva politica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
