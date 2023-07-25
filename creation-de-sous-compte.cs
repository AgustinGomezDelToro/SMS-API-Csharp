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
        var fields = new
        {
            apiKey = "VOTRE_CLÉ_API",
            type = "advanced",
            parameters = new 
            {
                email = "aaaa@bbb.ccc",
                creditToAttribute = 10,
                isBuyer = 0,
                firstname = "prenom",
                lastname = "nom"
            }
        };

        var json = JsonConvert.SerializeObject(fields);

        var uri = new Uri("https://api.smspartner.fr/v1/subaccount/create");
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync(uri, content);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("La requête POST a échoué avec le code d'état : " + response.StatusCode);
        }
    }
}
