using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TFLCodingChallenge.BusinessLayer;

namespace TFLCodingChallenge.Tests
{
    [SetUpFixture]
    public class SetUpTest
    {
        public static string url = ConfigurationManager.AppSettings["URL"];
        public  static string appId = ConfigurationManager.AppSettings["APPId"];
        public static string appKey = ConfigurationManager.AppSettings["APPKey"];
    }

    [TestFixture]
    public class RoadStatusTests : SetUpTest
    {

        [Test]
        public async Task A2ShouldBeValidRoad()
        {
            string roadName = "A2";
            var responseMessage = await GetRoadDetailsByRoadName(roadName);
            Assert.That(responseMessage.IsSuccessStatusCode, Is.EqualTo(true));
        }

        [Test]
        public async Task A2RoadShouldHaveValidDisplayName()
        {
            string roadName = "A2";
            var responseMessage = await GetRoadDetailsByRoadName(roadName);
            if(responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();

                var roadDetailsColl = JsonConvert.DeserializeObject<System.Collections.Generic.List<RoadDetails>>(data);
                Assert.That(roadDetailsColl[0].DisplayName, Is.EqualTo("A2"));
            }
        }

        [Test]
        public async Task A2RaodShouldHaveValidStatus()
        {
            string roadName = "A2";
            var responseMessage = await GetRoadDetailsByRoadName(roadName);
            var data = await responseMessage.Content.ReadAsStringAsync();

            var roadDetailsColl = JsonConvert.DeserializeObject<System.Collections.Generic.List<RoadDetails>>(data);

            Assert.That(roadDetailsColl[0].StatusSevirity, !Is.Null);
        }

        [Test]
        public async Task A2RaodShouldHaveValidStatusDescription()
        {
            string roadName = "A2";
            var responseMessage = await GetRoadDetailsByRoadName(roadName);
            var data = await responseMessage.Content.ReadAsStringAsync();

            var roadDetailsColl = JsonConvert.DeserializeObject<System.Collections.Generic.List<RoadDetails>>(data);

            Assert.That(roadDetailsColl[0].StatusSevirityDescription, !Is.Null);
        }

        [Test]
        public async Task A233ShouldBeInValidRoad()
        {
            string roadName = "A233";
            var responseMessage = await GetRoadDetailsByRoadName(roadName);
            Assert.That(responseMessage.IsSuccessStatusCode, Is.EqualTo(false));
        }

        [Test]
        public async Task A233ShouldBeInValidRoadWithStatucCodeNotFound()
        {
            string roadName = "A233";
            var responseMessage = await GetRoadDetailsByRoadName(roadName);
            Assert.That(responseMessage.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task A406ShouldBeValidRoad()
        {
            string roadName = "A406";
            var responseMessage = await GetRoadDetailsByRoadName(roadName);
            Assert.That(responseMessage.IsSuccessStatusCode, Is.EqualTo(true));
        }

        
        private static async Task<HttpResponseMessage> GetRoadDetailsByRoadName(string roadName)
        {
            HttpResponseMessage httpResponse = null;
            using (var client = new System.Net.Http.HttpClient())
            {
                var apiUrl = $"{SetUpTest.url}{roadName}?app_id={SetUpTest.appId}&app_key={SetUpTest.appKey}";

                httpResponse = await client.GetAsync(apiUrl);
            }

            return httpResponse;
        }
    }
}
