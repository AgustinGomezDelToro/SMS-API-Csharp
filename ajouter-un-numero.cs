using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        var data = new
        {
            apiKey = "YOUR_API_KEY",
            phoneNumber = "+336xxxxxxxx"
        };

        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://api.smspartner.fr/v1/stop-sms/add", content);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("La requête POST a échoué avec le code de statut: " + response.StatusCode);
        }
    }
}
