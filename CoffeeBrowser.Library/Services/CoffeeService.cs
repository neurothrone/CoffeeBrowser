using System.Net.Http.Json;
using CoffeeBrowser.Library.Models;

namespace CoffeeBrowser.Library.Services;

public class CoffeeService : ICoffeeService
{
    private readonly HttpClient _client = new();

    public async Task<IEnumerable<Coffee>?> LoadCoffeesAsync()
    {
        var coffees = await _client.GetFromJsonAsync<IEnumerable<Coffee>>(
            "https://www.thomasclaudiushuber.com/pluralsight/coffees.json");

        return coffees;
    }
}