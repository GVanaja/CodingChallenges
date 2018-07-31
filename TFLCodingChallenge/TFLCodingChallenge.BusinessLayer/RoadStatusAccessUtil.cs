using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace TFLCodingChallenge.BusinessLayer
{
  public  static class RoadStatusAccessUtil
    {
       public static async Task<RoadDetails> GetRoadDetailsByRoadName(string roadName)
        {

            RoadDetails roadDetails = null;

            using (var client = new System.Net.Http.HttpClient())
            {
                var url = ConfigurationManager.AppSettings["URL"];
                var appId = ConfigurationManager.AppSettings["APPId"];
                var appKey = ConfigurationManager.AppSettings["APPKey"];

                //https://api.tfl.gov.uk/Road/A406?app_id=c83aded3&app_key=a80a94e2b691071eb4294edb861d07c4

                var apiUrl = $"{url}{roadName}?app_id={appId}&app_key={appKey}";

                    HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var data = await responseMessage.Content.ReadAsStringAsync();

                        var roadDetailsColl = JsonConvert.DeserializeObject<System.Collections.Generic.List<RoadDetails>>(data);

                        if (roadDetailsColl.Count >= 1)
                        {
                            roadDetails = roadDetailsColl[0];
                        }
                    }

                return roadDetails;
            }
        }
    }
}
