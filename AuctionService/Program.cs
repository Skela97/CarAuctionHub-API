using System.Text.Json.Serialization;
using AuctionService.Application;
using AuctionService.Infrastructure;
using AuctionService.Infrastructure.EntityFramework;
using AuctionService.Infrastructure.EntityFramework.Initializer;
using AuctionService.Presentation.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["IdentityServiceUrl"];
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters.ValidateAudience = false;
        options.TokenValidationParameters.NameClaimType = "username";
    });

builder.Services.AddValidatorsFromAssemblyContaining<CreateAuctionValidator>();

builder.Services.AddDbContext<AuctionDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Add application logic dependencies.
builder.Services.AddApplicationDependencies();
//Add infrastructural dependencies.
builder.Services.AddInfrastructuralDependencies();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = " CarAuctionHub-AuctionService", Version = "v1" });
});

WebApplication app = builder.Build();

// Configure the HTTP request middlewares
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),specifying the Swagger JSON endpoint
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarAuctionHub-AuctionService V1");
});

//Running the migrations and populating the data.

DbInitializer.InitDb(app);

app.Run();