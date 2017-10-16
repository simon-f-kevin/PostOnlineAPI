using Newtonsoft.Json;
using PostOnlineAPIReferenceLibrary.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PostOnlineAPIReferenceLibrary.APIControllers
{
    public interface IPostOnlineAPIDeliveryRoute
    {
        Task<DeliveryRouteDTO> GetDeliveryRoute(long deliveryID);
    }

    public class PostOnlineAPIDeliveryRoute : IPostOnlineAPIDeliveryRoute
    {
        public async Task<DeliveryRouteDTO> GetDeliveryRoute(long deliveryID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.url + "DeliveryRoutes/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            DeliveryRouteDTO deliveryRoute = null;
            HttpResponseMessage response = await client.GetAsync(deliveryID.ToString()).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                deliveryRoute = JsonConvert.DeserializeObject<DeliveryRouteDTO>(responseString);
                return deliveryRoute;
            }
            return null;
        }
    }
}
