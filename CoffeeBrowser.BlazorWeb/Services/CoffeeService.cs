using CoffeeBrowser.Library.Models;
using CoffeeBrowser.Library.Services;

namespace CoffeeBrowser.BlazorWeb.Services;

public class CoffeeService : ICoffeeService
{
    private readonly IHttpClientFactory _factory;

    public CoffeeService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<Coffee>?> LoadCoffeesAsync()
    {
        var client = _factory.CreateClient();
        var coffees = await client.GetFromJsonAsync<IEnumerable<Coffee>>(
            "https://www.thomasclaudiushuber.com/pluralsight/coffees.json");

        return coffees;
    }
}