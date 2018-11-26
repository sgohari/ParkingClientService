using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkingClientService
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
           
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://comp306project-test.us-east-1.elasticbeanstalk.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                string json;
                Parking chapter;
                HttpContent content;
                HttpResponseMessage response;

                //get all chapers

                //response = await client.GetAsync("api/parkinglots");

                //if (response.IsSuccessStatusCode)
                //{
                //    json = await response.Content.ReadAsStringAsync();

                //    IEnumerable<Parking> chapters = JsonConvert.DeserializeObject<IEnumerable<Parking>>(json);

                //    foreach (Parking c in chapters)
                //    {
                //        Console.WriteLine(c);
                //    }
                //}

                //Console.WriteLine("Display By ID");
                // string id = "50007";

                //// get all chapers
                // response = await client.GetAsync("/api/parkinglots/" + id);

                // if (response.IsSuccessStatusCode)
                // {
                //     chapter = await response.Content.ReadAsAsync<Parking>();

                //     Console.WriteLine("The return Parking details: " + chapter);
                // }
                // else
                // {
                //     Console.WriteLine("Internal Server Error");
                // }

                //Console.WriteLine("\nAdding a new Data");
                //chapter = new Parking { LotId = "50008", LotName = "GoGo", LotStreetNumber = 555, LotStreetName = "Margerat", LotCity = "Toronto", LotDailyRate = 49, LotHourlyRate = 4, LotWeeklyRate = 20, LotMonthlyRate = 200, LotYearlyRate = 1900 };
                //response = await client.PostAsJsonAsync("/api/parkinglots", chapter);
                //Console.WriteLine("Record Updated");

                //Console.WriteLine("Updating the Existance data");

                //chapter = new Parking
                //{

                //    LotId = "50008",
                //    LotName = "Nasir is Updated",
                //    LotStreetNumber = 000,
                //    LotStreetName = "WHATTTTT",
                //    LotCity = "WHERE",
                //    LotDailyRate = 49,
                //    LotHourlyRate = 4,
                //    LotWeeklyRate = 20,
                //    LotMonthlyRate = 200,
                //    LotYearlyRate = 1900
                //};
                //response =
                //    await client.PutAsJsonAsync("/api/parkinglots/50008", chapter);
                //Console.WriteLine($"status from put{response.StatusCode}");
                //response.EnsureSuccessStatusCode();

                response = await client.DeleteAsync("api/parkinglots/50004");

                Console.WriteLine($"status from Delete {response.StatusCode}");
                response.EnsureSuccessStatusCode();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
