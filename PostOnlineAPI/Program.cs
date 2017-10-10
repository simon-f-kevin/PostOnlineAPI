using APITester.APIControllers;
using APITester.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APITester
{
    public class Program
    {
        public static string url = "http://localhost:63047/api/";
        private static HttpClient client = new HttpClient();
        private static PostOnlineAPIPackage PackageAPI = new PostOnlineAPIPackage();
        private static PostOnlineAPIReciever RecieverAPI = new PostOnlineAPIReciever();
        private static PostOnlineAPIDeliveryRoute DeliveryRouteAPI = new PostOnlineAPIDeliveryRoute();

        

        static void Main(string[] args)
        {
            RunProgram();
            
        }

        private static void RunProgram()
        {
            int choice = 0;
            string id;
            Console.WriteLine("PostOnline API tester");
            Console.WriteLine("Choose a function to test");

            
            while (true)
            { 
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. GetPackage");
                Console.WriteLine("2. UpdatePackage");
                Console.WriteLine("3. CreatePackage");
                Console.WriteLine("4. GetReciever");
                Console.WriteLine("5. UpdateReciever");
                Console.WriteLine("6. CreateReciever");
                Console.WriteLine("7. GetDeliveryRoute");
                Console.WriteLine("8. GetPackageForReciever");
                Console.WriteLine("9. GetPackageForDeliveryRoute");
                Console.WriteLine("0. to exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Pick a package id");
                            id = Console.ReadLine();
                            RunGetPackage(Convert.ToInt64(id)).Wait();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Pick a package id");
                            id = Console.ReadLine();
                            RunUpdatePackage(Convert.ToInt64(id)).Wait();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Pick a package id");
                            id = Console.ReadLine();
                            RunCreatePackage(Convert.ToInt64(id)).Wait();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Pick a reciever id");
                            id = Console.ReadLine();
                            RunGetReciever(Convert.ToInt64(id)).Wait();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Pick a reciever id");
                            id = Console.ReadLine();
                            RunUpdateReciever(Convert.ToInt64(id)).Wait();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Pick a reciever id");
                            id = Console.ReadLine();
                            RunCreateReciever(Convert.ToInt64(id)).Wait();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Pick an id");
                            id = Console.ReadLine();
                            RunGetDeliveryRoute(Convert.ToInt64(id)).Wait();
                            break;
                        case 8:
                            Console.Clear();
                            Console.WriteLine("Pick an id");
                            id = Console.ReadLine();
                            RunGetPackageForReciever(Convert.ToInt64(id)).Wait();
                            break;
                        case 9:
                            Console.Clear();
                            Console.WriteLine("Pick an id");
                            id = Console.ReadLine();
                            RunGetPackageForDeliveryRoute(Convert.ToInt64(id)).Wait();
                            break;
                        default:
                        Environment.Exit(0);
                            break;
                    }
            }
            
          

        }

        private static async Task RunGetPackage(long id)
        {
            try
            {
                var result = Task.Run(() => PackageAPI.GetPackage(id));

                var package = result.Result;

                Console.WriteLine(JsonConvert.SerializeObject(package));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static async Task RunUpdatePackage(long id)
        {
            client.BaseAddress = new Uri("http://localhost:63047/api/Packages/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var hej = new PackageDTO
            {
                PackageID = id,
                ReciverID = 1,
                DeliveryID = 3,
                SenderID = 1,
                DeliveryStreetAdress = "Sagagatan 2",
                DeliveryCity = "Borås",
                DeliveryPostalCode = "12345",
                PickUpStreetAdress = "Kungsgatan 3",
                PickUpCity = "Göteborg",
                PickUpPostalCode = "12346",
                EarliestDeliveryDay = DateTime.Now,
                CheckedInDate = DateTime.Now,
                Message = "björn är cool",
                SenderName = "Tradera.se",
                Priority = 1,
                Delivered = false
            };
            try
            {
                var result = Task.Run(() => PackageAPI.UpdatePackage(hej));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            RunGetPackage(id).Wait();
        }

        private static async Task RunCreatePackage(long id)
        {
            var hej = new PackageDTO
            {
                PackageID = id,
                ReciverID = 1,
                DeliveryID = 3,
                SenderID = 1,
                DeliveryStreetAdress = "hejpådig 2",
                DeliveryCity = "Åmål",
                DeliveryPostalCode = "12345",
                PickUpStreetAdress = "Kungsgatan 3",
                PickUpCity = "Åmål",
                PickUpPostalCode = "12346",
                EarliestDeliveryDay = DateTime.Now,
                CheckedInDate = DateTime.Now,
                Message = "björn är cool",
                SenderName = "Tradera.se",
                Priority = 1,
                Delivered = false
            };
            try
            {
                var result = Task.Run(() => PackageAPI.CreatePackage(hej));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static async Task RunUpdateReciever(long id)
        {
            var reciever = new RecieverDTO
            {
                ReciverID = id,
                FirstName = "Fille",
                LastName = "Man",
                PackagesID = new List<long>()
            };
            try
            {
                var result = Task.Run(() => RecieverAPI.UpdateReciever(reciever));

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Console.ReadLine();
            RunGetReciever(id).Wait();
        }

        private static async Task RunCreateReciever(long id)
        {
            var reciever = new RecieverDTO
            {
                ReciverID = id,
                FirstName = "Putzor",
                LastName = "Dragonslayer",
                PackagesID = new List<long>()
            };
            try
            {
                var result = Task.Run(() => RecieverAPI.CreateReciever(reciever));
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Console.ReadLine();
            RunGetReciever(id).Wait();
        }

        private static async Task RunGetPackageForReciever(long id)
        {
            

            List<PackageDTO> list = PackageAPI.GetPackagesForRecieverID(1);
            foreach(var package in list)
            {
                Console.WriteLine(JsonConvert.SerializeObject(package));
                Console.WriteLine("\n\n");
            }
            Console.ReadLine();
        }
        private static async Task RunGetPackageForDeliveryRoute(long id)
        {

            List<PackageDTO> list = PackageAPI.GetPackagesForDeliveryID(id);
            foreach (var package in list)
            {
                Console.WriteLine(JsonConvert.SerializeObject(package));
                Console.WriteLine("\n\n");
            }
            Console.ReadLine();
        }

        private static async Task RunGetReciever(long id)
        {
            try
            {
                var result = Task.Run(() => RecieverAPI.GetReciever(id));

                var reciever = result.Result;

                Console.WriteLine(JsonConvert.SerializeObject(reciever));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static async Task RunGetDeliveryRoute(long id)
        {
            try
            {
                var result = Task.Run(() => DeliveryRouteAPI.GetDeliveryRoute(id));

                var deliveryRoute = result.Result;

                Console.WriteLine(JsonConvert.SerializeObject(deliveryRoute));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
