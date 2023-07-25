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
        var request = new
        {
            apiKey = "YOUR_API_KEY",
            sender = "mycompany",
            scheduledDeliveryDate = "21/10/2014",
            time = 9,
            minute = 0,
            SMSList = new[]
            {
                new
                {
                    phoneNumber = "06xxxxxxx1",
                    message = "msg 0"
                },
                new
                {
                    phoneNumber = "06xxxxxxx2",
                    message = "msg 1"
                }
            }
        };

        var content = new StringContent(
            JsonConvert.SerializeObject(request),
            Encoding.UTF8,
            "application/json");

        HttpResponseMessage response = await client.PostAsync("https://api.smspartner.fr/v1/bulk-send", content);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("POST request failed with status code: " + response.StatusCode);
        }
    }
}
