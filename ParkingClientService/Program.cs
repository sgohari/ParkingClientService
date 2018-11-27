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
                
                string ans="yes";
                do
                {
                    
                    Console.WriteLine("***********************************");
                    Console.WriteLine("*\t1-Display All Records");
                    Console.WriteLine("*\t2-Display Records by ID");
                    Console.WriteLine("*\t3-Add new Records ");
                    Console.WriteLine("*\t4-Update an Existance Record ");
                    Console.WriteLine("*\t5-Delete a Record ");
                    Console.WriteLine("*\t6-Exit the API ");
                    Console.WriteLine("***********************************");
                    Console.Write("Please select from the menue: ");
                    int selection = Convert.ToInt32(Console.ReadLine());

                    switch (selection)
                    {
                        case 1:
                            response = await client.GetAsync("api/parkinglots");

                            if (response.IsSuccessStatusCode)
                            {
                                json = await response.Content.ReadAsStringAsync();

                                IEnumerable<Parking> chapters = JsonConvert.DeserializeObject<IEnumerable<Parking>>(json);

                                foreach (Parking c in chapters)
                                {
                                    Console.WriteLine(c);
                                }
                            }

                            break;
                        case 2:
                            Console.WriteLine("Display By ID");
                            string id = "50007";

                            // get all chapers
                            response = await client.GetAsync("/api/parkinglots/" + id);

                            if (response.IsSuccessStatusCode)
                            {
                                chapter = await response.Content.ReadAsAsync<Parking>();

                                Console.WriteLine("The return Parking details: " + chapter);
                            }
                            else
                            {
                                Console.WriteLine("Internal Server Error");
                            }
                            break;
                        case 3:
                            chapter = new Parking { LotId = "50009", LotName = "Centennial", LotStreetNumber = 555, LotStreetName = "Margerat", LotCity = "Toronto", LotDailyRate = 49, LotHourlyRate = 4, LotWeeklyRate = 20, LotMonthlyRate = 200, LotYearlyRate = 1900 };
                            response = await client.PostAsJsonAsync("/api/parkinglots", chapter);
                            Console.WriteLine("Record is added");
                            break;
                        case 4:
                            chapter = new Parking
                            {
                                LotId = "50009",
                                LotName = "Nasir is Updated",
                                LotStreetNumber = 000,
                                LotStreetName = "WHATTTTT",
                                LotCity = "WHERE",
                                LotDailyRate = 49,
                                LotHourlyRate = 4,
                                LotWeeklyRate = 20,
                                LotMonthlyRate = 200,
                                LotYearlyRate = 1900
                            };
                            response =
                                await client.PutAsJsonAsync("/api/parkinglots/50009", chapter);
                            Console.WriteLine($"status from put{response.StatusCode}");
                            response.EnsureSuccessStatusCode();
                            Console.WriteLine("Record is updated");
                            break;
                        case 5:
                            response = await client.DeleteAsync("api/parkinglots/50009");
                            Console.WriteLine($"status from Delete {response.StatusCode}");
                            response.EnsureSuccessStatusCode();
                            break;
                        case 6:
                            Console.WriteLine("Thanks you for using our API");
                            Console.ReadLine();
                            return;
                        default:
                            Console.WriteLine("Unknown value");
                            break;
                    }
                } while (ans == "yes");
                Console.WriteLine("Do you want to Continue using API ");
                ans=Console.ReadLine();
                
            }
                
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
