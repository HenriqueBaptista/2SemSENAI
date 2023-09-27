using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servi�o de controllers
builder.Services.AddControllers();


// Adiciona servi�o de autentica��o JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

// Define os par�metros de valida��o do Token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Valida quem est� solicitando
        ValidateIssuer = true,

        // Valida quem est� recebendo
        ValidateAudience = true,

        // Define se o tempo de expira��o do Token ser� validado
        ValidateLifetime = true,

        // Forma de criptografia e ainda valida��o da chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("login-chave-autenticacao-webapi-dev")),

        // Valida o tempo de expira��o do Token
        ClockSkew = TimeSpan.FromMinutes(5),

        // De onde est� vindo (issuer)
        ValidIssuer = "healthclinic_api_tarde_2",

        // Para onde est� indo (audience)
        ValidAudience = "healthclinic_api_tarde_2"
    };
});

// Adiciona o gerador do Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Health Clinic",
        Description = "API para gerenciamento da cl�nica Health - Sprint 2 - Backend API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Henrique Bap",
            Url = new Uri("https://github.com/HookCreeping")
        }
    });


    // Configure o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    // Usando a autentica��o no swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Habilita o middleware para atender ao documento JSON gerado e � interface do usu�rio Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Para atender � interface do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Usar autentica��o
app.UseAuthentication();

// Usar autoriza��o
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();

app.Run();
