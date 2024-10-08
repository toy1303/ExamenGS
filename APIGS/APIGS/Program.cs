using APIGS.Helpers;
using Oracle.ManagedDataAccess.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("permitirtodo",
        builder =>
        {
            builder.AllowAnyOrigin()   // Permitir cualquier origen
                   .AllowAnyHeader()   // Permitir cualquier encabezado
                   .AllowAnyMethod();  // Permitir cualquier método (GET, POST, PUT, DELETE, etc.)
        });
});

builder.Services.AddScoped<ConectionOracle>();

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
app.UseCors("permitirtodo");
app.UseAuthorization();

app.MapControllers();

app.Run();
