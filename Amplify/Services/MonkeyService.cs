

namespace MonkeyFinderHybrid.Services;
using MonkeyFinderHybrid.Model;
using System.Net.Http.Json;

public class MonkeyService
{
    private List<Monkey> monkeysList = new();
    private readonly HttpClient httpClient;

    public MonkeyService() {
        httpClient = new HttpClient();
    }

    public async Task<List<Monkey>> GetMonkeys() {
        //small cacheing
        if (monkeysList.Count > 0) {
            return monkeysList;
        }

        var response = await httpClient.GetAsync("https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/monkeydata.json");

        if (response.IsSuccessStatusCode) {
            var monkeysResult = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);

            if (monkeysResult is not null) {
                monkeysList = monkeysResult;
            }
        }

        return monkeysList;
    }
}