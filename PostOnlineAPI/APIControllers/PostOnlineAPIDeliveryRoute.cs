using PostOnlineAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PostOnlineAPI.APIControllers
{
    interface IPostOnlineAPIDeliveryRoute
    {
        Task<DeliveryRouteDTO> GetDeliveryRoute(long deliveryID);
    }

    class PostOnlineAPIDeliveryRoute : IPostOnlineAPIDeliveryRoute
    {
        public async Task<DeliveryRouteDTO> GetDeliveryRoute(long deliveryID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.url + "DeliveryRoutes/");
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
