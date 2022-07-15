using film_api.data.Models;
using film_api.data.Redis;
using film_api.repository.BaseRepository.Abstract;
using film_api.repository.BaseRepository.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger settings with Authorization
builder.Services.AddSwaggerGen(c =>
{
    // Bearer token authentication
    OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
    {
        Name = "Bearer",
        BearerFormat = "JWT",
        Scheme = "bearer",
        Description = "Specify the authorization token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
    };
    c.AddSecurityDefinition("jwt_auth", securityDefinition);

    // Make sure swagger UI requires a Bearer token specified
    OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference()
        {
            Id = "jwt_auth",
            Type = ReferenceType.SecurityScheme
        }
    };
    OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
{
    {securityScheme, new string[] { }},
};
    c.AddSecurityRequirement(securityRequirements);
});

//DB CONTEXT IMPLEMENTATION
builder.Services.AddDbContext<DatabaseContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("MoviesDB"))
    );

//REDIS IMPLEMENT
builder.Services.AddSingleton<IRedisHelper, RedisHelper>();

//REPOSITORY IMPLEMENT
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

//JWT AUTHENTICATION
var key = Encoding.ASCII.GetBytes(builder.Configuration["Application:JWTSecret"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.Audience = "ARVATO";
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.ClaimsIssuer = "ARVATO.Issuer.Development";
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

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
