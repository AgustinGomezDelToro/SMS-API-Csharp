using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        var apiKey = "VOTRE_CLÉ_API";
        var uri = new Uri($"https://api.smspartner.fr/v1/stop-sms/list?apiKey={apiKey}");

        HttpResponseMessage response = await client.GetAsync(uri);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("La requête GET a échoué avec le code de statut: " + response.StatusCode);
        }
    }
}
