using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TFLCodingChallenge.BusinessLayer;

namespace TFLCodingChallenge
{
    class Program
    {
        static string url = ConfigurationManager.AppSettings["URL"];
        static string appId = ConfigurationManager.AppSettings["APPId"];
        static string appKey = ConfigurationManager.AppSettings["APPKey"];

        static void Main(string[] args)
        {
            if (args ?.Length > 0)
                GetRoadDetailsByRoadName(args[0]).Wait();

            Console.ReadLine();
        }

        static async Task GetRoadDetailsByRoadName(string roadName)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var apiUrl = $"{url}{roadName}?app_id={appId}&app_key={appKey}";

                HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var data = await responseMessage.Content.ReadAsStringAsync();

                    var roadDetailsColl = JsonConvert.DeserializeObject<System.Collections.Generic.List<RoadDetails>>(data);

                    if (roadDetailsColl.Count >= 1)
                    {
                        var roadDetails = roadDetailsColl[0];
                        Console.WriteLine($"The status of the {roadDetails.DisplayName} is as follows");
                        Console.WriteLine($"Road Status is {roadDetails.StatusSevirity}");
                        Console.WriteLine($"Road Status Description is {roadDetails.StatusSevirityDescription}");
                    }
                }
                else
                {
                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                        Console.WriteLine($"{roadName} is not a valid road.");
                }
            }
        }
    }
}
