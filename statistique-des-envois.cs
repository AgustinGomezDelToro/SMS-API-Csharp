using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        var apiKey = "VOTRE_CLÉ_API";
        var interval = "last_twelve_months"; // Changer à "last_month" pour le dernier mois, "custom" pour un intervalle personnalisé
        var uri = new Uri($"https://api.smspartner.fr/v1/statistics/cost-resume?apiKey={apiKey}&interval={interval}"); // Ajoutez "&from=date&to=date" pour un intervalle personnalisé

        // Envoyer la requête GET
        HttpResponseMessage response = await client.GetAsync(uri);

        if (response.IsSuccessStatusCode)
        {
            // Lire la réponse
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
        else
        {
            // Afficher un message en cas d'échec de la requête GET
            Console.WriteLine("La requête GET a échoué avec le code de statut: " + response.StatusCode);
        }
    }
}
