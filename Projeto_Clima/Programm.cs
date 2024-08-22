using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Clima
{
    internal class Programm
    {
        private static readonly HttpClient client = new HttpClient();  
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Digite o nome da cidade desejada: ");
            string city = Console.ReadLine();

            string apiKey = "your_apiKey";
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=pt";

            try
            {
                WeatherResponse weatherResponse = await client.GetFromJsonAsync<WeatherResponse>(url);

                Console.WriteLine($"Clima em {weatherResponse.Name}");
                Console.WriteLine($"Temperatura: {weatherResponse.Main.Temp} graus celsius");
                Console.WriteLine($"Pressão: {weatherResponse.Main.Pressure} hPa");
                Console.WriteLine($"Umidade: {weatherResponse.Main.Pressure}");
                Console.WriteLine($"Velocidade do Vento: {weatherResponse.Wind.Speed} m/s");
            }
            catch( Exception ex )
            {
                Console.WriteLine("Erro ao buscar dados do clima, não foi possivel achar a " +
                    "cidade pois: " + ex.Message);
            }

        }

    }
}
