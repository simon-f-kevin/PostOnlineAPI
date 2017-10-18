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
    public interface IPostOnlineAPIReciever
    {
        /// <summary>
        /// Method for getting a RecieverDTO object from the PostOnline system. 
        /// </summary>
        /// <param name="recieverID"></param>
        /// <returns></returns>
        Task<RecieverDTO> GetReciever(long recieverID);
        /// <summary>
        /// Method for updating an existing Reciever in the PostOnline system. 
        /// </summary>
        /// <param name="reciever"></param>
        /// <returns></returns>
        Task<bool> UpdateReciever(RecieverDTO reciever);
        /// <summary>
        /// Method for creating a new Reciever in the PostOnline system. 
        /// </summary>
        /// <param name="reciever"></param>
        /// <returns></returns>
        Task<bool> CreateReciever(RecieverDTO reciever);
    }
    public class PostOnlineAPIReciever : IPostOnlineAPIReciever
    {
        public async Task<RecieverDTO> GetReciever(long recieverID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.url + "Recievers/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            RecieverDTO reciever = null;
            HttpResponseMessage response = await client.GetAsync(recieverID.ToString()).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                reciever = JsonConvert.DeserializeObject<RecieverDTO>(responseString);
                return reciever;
            }
            return null;
        }

        public async Task<bool> UpdateReciever(RecieverDTO reciever)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.url + "Recievers/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent httpobject = new StringContent(JsonConvert.SerializeObject(reciever), Encoding.UTF8, "application/json");
            var id = reciever.ReciverID;
            var response = await client.PutAsync(id.ToString(), httpobject).ConfigureAwait(false);
            var expected = (int)HttpStatusCode.NoContent;
            if (expected == (int)response.StatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreateReciever(RecieverDTO reciever)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.url + "Recievers/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent httpobject = new StringContent(JsonConvert.SerializeObject(reciever), Encoding.UTF8, "application/json");
            var id = reciever.ReciverID;
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
