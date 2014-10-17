using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AsrkRf.Rpl.TransportService
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:25107");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/subdivision/263000199");
                if (response.IsSuccessStatusCode)
                {
                    var s = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(s);
                    var post = await client.PostAsJsonAsync("api/subdivision", s);
                    if (post.IsSuccessStatusCode)
                    {
                        Console.WriteLine(post.Headers.Location);
                    }
                    Console.ReadKey();
                }
            }   
        }
    }
}
