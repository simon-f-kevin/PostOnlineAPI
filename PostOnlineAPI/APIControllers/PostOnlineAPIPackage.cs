using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using PostOnlineAPI.Models;

namespace PostOnlineAPI.APIControllers
{
    public interface IPostOnlineAPIPackage
    {
        Task<PackageDTO> GetPackage(long packageID);
        Task<bool> UpdatePackage(PackageDTO package);
        Task<bool> CreatePackage(PackageDTO package);
        List<PackageDTO> GetPackagesForRecieverID(long recieverID);
        List<PackageDTO> GetPackagesForDeliveryID(long deliveryID);
        Task<List<PackageDTO>> GetPackagesForSenderID(long senderID);
    }

    public class PostOnlineAPIPackage : IPostOnlineAPIPackage
    {
        public async Task<PackageDTO> GetPackage(long packageID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.url + "Packages/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            PackageDTO package = null;
            HttpResponseMessage response = await client.GetAsync(packageID.ToString()).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                package = JsonConvert.DeserializeObject<PackageDTO>(responseString);
                return package;
            }
            return null;
        }


        public async Task<bool> UpdatePackage(PackageDTO package)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.url + "Packages/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent httpobject = new StringContent(JsonConvert.SerializeObject(package), Encoding.UTF8, "application/json");
            var id = package.PackageID;
            var response = await client.PutAsync(id.ToString(), httpobject).ConfigureAwait(false);
            var expected = (int)HttpStatusCode.NoContent;
            if (expected == (int) response.StatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreatePackage(PackageDTO package)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.url + "Packages/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent httpobject = new StringContent(JsonConvert.SerializeObject(package), Encoding.UTF8, "application/json");
            var id = package.PackageID;
            HttpResponseMessage response = await client.PostAsync("", httpobject).ConfigureAwait(false);
            var expected = (int)HttpStatusCode.OK;
            if (expected == (int) response.StatusCode)
            {
                return true;
            }
            return false;
        }

        public List<PackageDTO> GetPackagesForRecieverID(long recieverID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.url + "Recievers/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            PostOnlineAPIReciever recieverAPI = new PostOnlineAPIReciever();
            List<PackageDTO> _listOfPackages = new List<PackageDTO>();
            var reciever = Task.Run(() => recieverAPI.GetReciever(recieverID)).Result;
            if(reciever.PackagesID.Count > 0)
            {
                foreach (var packageID in reciever.PackagesID)
                {
                    var package = Task.Run(() => GetPackage(packageID)).Result;
                    if(package != null) _listOfPackages.Add(package);
                }
                return _listOfPackages;
            }
            return new List<PackageDTO>();
        }

        public List<PackageDTO> GetPackagesForDeliveryID(long deliveryID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.url + "DeliveryRoutes/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            PostOnlineAPIDeliveryRoute deliveryRoute = new PostOnlineAPIDeliveryRoute();
            List<PackageDTO> _listOfPackages = new List<PackageDTO>();
            var route = Task.Run(() => deliveryRoute.GetDeliveryRoute(deliveryID)).Result;
            if (route.PackagesID.Count > 0)
            {
                foreach (var packageID in route.PackagesID)
                {
                    var package = Task.Run(() => GetPackage(packageID)).Result;
                    if (package != null) _listOfPackages.Add(package);
                }
                return _listOfPackages;
            }
            return new List<PackageDTO>();
        }

        public async Task<List<PackageDTO>> GetPackagesForSenderID(long senderID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.url + "Senders/{senderID}/Packages");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<PackageDTO> packages = null;
            HttpResponseMessage response = await client.GetAsync(senderID.ToString()).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                packages = JsonConvert.DeserializeObject<List<PackageDTO>>(responseString);
                return packages;
            }

            return new List<PackageDTO>();
        }
    }
}
