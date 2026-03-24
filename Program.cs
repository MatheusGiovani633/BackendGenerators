using BackendGenerators.Data;
using Microsoft.EntityFrameworkCore;
using BackendGenerators.Services;
using BackendGenerators.Repository;
using BackendGenerators.Interfaces;
using BackendGenerators.Auth;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IProcessService, ProcessService>();
builder.Services.AddScoped<PessoaRepository>();
builder.Services.AddScoped<ProcessRepository>();
builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
builder.Services.AddScoped<IRefreshTokenGenerator, GuidRefreshTokenGenerator>();

var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
