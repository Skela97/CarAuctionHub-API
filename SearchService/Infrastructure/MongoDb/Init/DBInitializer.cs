using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Domain;
using SearchService.Exceptions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SearchService.Data;

public static class DBInitializer
{
    public static async Task InitDb( string connectionString)
    {
        await DB.InitAsync("SearchDb", MongoClientSettings.FromConnectionString(connectionString));

        long count = await DB.CountAsync<Item>();

        if(count == 0)
        {
            await DB.SaveAsync(await GetEntryItems());
        }

        await DB.Index<Item>()
            .Key(x => x.Make, KeyType.Text)
            .Key(x => x.Model, KeyType.Text)
            .Key(x => x.Color, KeyType.Text).CreateAsync();
    }

    private static async Task<IEnumerable<Item>> GetEntryItems()
    {
        string itemData = await File.ReadAllTextAsync("Infrastructure/MongoDb/Auctions.json");
        
        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new JsonStringEnumConverter());
  
        return JsonSerializer.Deserialize<IEnumerable<Item>>(itemData, options) ?? throw new IncorrectInitializationInputException();
    }
}
