using Newtonsoft.Json;
using PostOnlineAPIReferenceLibrary.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PostOnlineAPIReferenceLibrary.APIControllers
{
    public interface IPostOnlineAPIDriver
    {
        Task<DriverDTO> GetDriver(long driverID);
        Task<bool> UpdateDriver(DriverDTO driver);
        Task<bool> CreateDriver(DriverDTO driver);

    }

    public class PostOnlineAPIDriver : IPostOnlineAPIDriver
    {
        public async Task<DriverDTO> GetDriver(long driverID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.url + "Drivers/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            DriverDTO driver = null;
            HttpResponseMessage response = await client.GetAsync(driverID.ToString()).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                driver = JsonConvert.DeserializeObject<DriverDTO>(responseString);
                return driver;
            }
            return null;
        }

        public async Task<bool> UpdateDriver(DriverDTO driver)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.url + "Drivers/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent httpobject = new StringContent(JsonConvert.SerializeObject(driver), Encoding.UTF8, "application/json");
            var id = driver.DriverID;
            var response = await client.PutAsync(id.ToString(), httpobject).ConfigureAwait(false);
            var expected = (int)HttpStatusCode.NoContent;
            if (expected == (int)response.StatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreateDriver(DriverDTO driver)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.url + "Drivers/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent httpobject = new StringContent(JsonConvert.SerializeObject(driver), Encoding.UTF8, "application/json");
            var id = driver.DriverID;
            HttpResponseMessage response = await client.PostAsync("", httpobject).ConfigureAwait(false);
            var expected = (int)HttpStatusCode.OK;
            if (expected == (int)response.StatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
