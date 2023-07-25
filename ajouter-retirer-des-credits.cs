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
            apiKey = "YOUR API KEY",
            credit = "100",
            tokenSubaccount = "Subaccount ID"
        };

        string jsonString = JsonConvert.SerializeObject(data);

        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://api.smspartner.fr/v1/subaccount/credit/add", content);

        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("POST request failed with status code: " + response.StatusCode);
        }
    }
}
