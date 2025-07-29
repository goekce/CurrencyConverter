using System.Text.Json;

var client = new HttpClient();
string json = await client.GetStringAsync("https://api.frankfurter.dev/v1/latest?base=DKK");
var dkk_in_eur = JsonDocument.Parse(json)
    .RootElement
    .GetProperty("rates")
    .GetProperty("EUR")
    .GetDouble();

Console.WriteLine($"1 DKK = {dkk_in_eur} EUR");
Console.Write("Enter amount in DKK: ");
var dkk_amount = Convert.ToDouble(Console.ReadLine());
var eur_amount = dkk_amount * dkk_in_eur;
Console.WriteLine($"{dkk_amount} DKK = {eur_amount:F2} EUR");