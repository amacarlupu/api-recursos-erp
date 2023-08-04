using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SupportPageApi.Models;
using SupportPageApi.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<SupportDatabaseSettings>(
builder.Configuration.GetSection("SupportDatabase"));

builder.Services.Configure<FlujosNowDatabaseSettings>(
builder.Configuration.GetSection("FlujosNowDatabase"));

builder.Services.Configure<UserDatabaseSettings>(
builder.Configuration.GetSection("UserDatabase"));

builder.Services.Configure<TokenSetting>(
builder.Configuration.GetSection("Jwt"));

builder.Services.Configure<ProductLinesDatabaseSettings>(
builder.Configuration.GetSection("ProductLinesDatabase"));

builder.Services.AddSingleton<SupportService>();
builder.Services.AddSingleton<FlujosNowService>();
builder.Services.AddSingleton<AuthenticateService>();
builder.Services.AddSingleton<TokenService>();
builder.Services.AddSingleton<ProductLinesService>();

builder.Services.AddControllers();

// esquema de autenticación JWT usando el método "AddAuthentication"
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
