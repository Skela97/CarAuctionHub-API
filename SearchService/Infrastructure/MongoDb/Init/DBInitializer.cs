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

        long count = await DB.CountAsync<Auction>();

        if(count == 0)
        {
            await DB.SaveAsync(await GetEntryItems());
        }

        await DB.Index<Auction>()
            .Key(x => x.Make, KeyType.Text)
            .Key(x => x.Model, KeyType.Text)
            .Key(x => x.Color, KeyType.Text).CreateAsync();
    }

    private static async Task<IEnumerable<Auction>> GetEntryItems()
    {
        string itemData = await File.ReadAllTextAsync("Infrastructure/MongoDb/Init/Auctions.json");
        
        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new JsonStringEnumConverter());
  
        return JsonSerializer.Deserialize<IEnumerable<Auction>>(itemData, options) ?? throw new IncorrectInitializationInputException();
    }
}
