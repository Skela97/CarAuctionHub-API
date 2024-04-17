using Microsoft.OpenApi.Models;
using SearchService.Application;
using SearchService.Data;
using SearchService.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); 

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarAuctionHub-SearchService", Version = "v1" });
});

builder.Services.AddInfrastructuralDependencies();
builder.Services.AddApplicationDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarAuctionHub-SearchService V1");
    });
}

app.UseAuthorization();
app.MapControllers();

await DBInitializer.InitDb(builder.Configuration.GetConnectionString("MongoDBConnection"));
    
app.Run();