using PostOnlineAPI.APIControllers;
using PostOnlineAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PostOnlineAPI
{
    public class Program
    {
        public static string url = "http://localhost:63047/api/";
        private static HttpClient client = new HttpClient();
        private static PostOnlineAPIPackage PackageAPI = new PostOnlineAPIPackage();
        private static PostOnlineAPIReciever RecieverAPI = new PostOnlineAPIReciever();
        private static PostOnlineAPIDeliveryRoute DeliveryRouteAPI = new PostOnlineAPIDeliveryRoute();
        private static PostOnlineAPISender SenderAPI = new PostOnlineAPISender();
        private static PostOnlineAPIDriver DriverAPI = new PostOnlineAPIDriver();

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
                Console.WriteLine("10. GetPackageForSenderID");
                Console.WriteLine("11. GetSender");
                Console.WriteLine("12. UpdateSender");
                Console.WriteLine("13. CreateSender");
                Console.WriteLine("14. GetDriver");
                Console.WriteLine("15. UpdateDriver");
                Console.WriteLine("16. CreateDriver");
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
                        case 10:
                            Console.Clear();
                            Console.WriteLine("Pick a sender id");
                            id = Console.ReadLine();
                            RunGetPackageForSenderID(Convert.ToInt64(id)).Wait();
                            break;
                        case 11:
                            Console.Clear();
                            Console.WriteLine("Pick a sender id");
                            id = Console.ReadLine();
                            RunGetSender(Convert.ToInt64(id)).Wait();
                            break;
                        case 12:
                            Console.Clear();
                            Console.WriteLine("Pick a sender id");
                            id = Console.ReadLine();
                            RunUpdateSender(Convert.ToInt64(id)).Wait();
                            break;
                        case 13:
                            Console.Clear();
                            Console.WriteLine("Pick a sender id");
                            id = Console.ReadLine();
                            RunCreateSender(Convert.ToInt64(id)).Wait();
                            break;
                        case 14:
                            Console.Clear();
                            Console.WriteLine("Pick a driver id");
                            id = Console.ReadLine();
                            RunGetDriver(Convert.ToInt64(id)).Wait();
                            break;
                        case 15:
                            Console.Clear();
                            Console.WriteLine("Pick a driver id");
                            id = Console.ReadLine();
                            RunUpdateDriver(Convert.ToInt64(id)).Wait();
                            break;
                        case 16:
                            Console.Clear();
                            Console.WriteLine("Pick a driver id");
                            id = Console.ReadLine();
                            RunCreateDriver(Convert.ToInt64(id)).Wait();
                            break;

                    default:
                        Environment.Exit(0);
                            break;
                    }
            }
            
          

        }
        #region/*Driver*/
        private static async Task RunGetDriver(long id)
        {
            try
            {
                var result = Task.Run(() => DriverAPI.GetDriver(id));
                var driver = result.Result;
                Console.WriteLine(JsonConvert.SerializeObject(driver));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static async Task RunUpdateDriver(long id)
        {
            var driver = new DriverDTO
            {
                DriverID = id,
                FirstName = "Gösta",
                LastName = "Ladugård",
                Latitude = "",
                Longitude = "",
                PhoneNumber = "112"
            };
            try
            {
                var result = Task.Run(() => DriverAPI.UpdateDriver(driver));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press enter..");
            Console.ReadLine();
            RunGetDriver(id).Wait();
        }

        private static async Task RunCreateDriver(long id)
        {
            var driver = new DriverDTO
            {
                DriverID = id,
                FirstName = "Putzor",
                LastName = "Dragonslayer",
                Latitude = "0.0",
                Longitude = "0.0",
                PhoneNumber = "911"
            };
            try
            {
                var result = Task.Run(() => DriverAPI.CreateDriver(driver));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press enter..");
            Console.ReadLine();
            RunGetDriver(id).Wait();
        }
        #endregion
        #region/*Sender*/
        private static async Task RunGetSender(long id)
        {
            try
            {
                var result = Task.Run(() => SenderAPI.GetSender(id));

                var sender = result.Result;

                Console.WriteLine(JsonConvert.SerializeObject(sender));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        private static async Task RunUpdateSender(long id)
        {
            var sender = new SenderDTO
            {
                SenderID = id,
                SenderName = "thepiratebay.com",
                UserName = "updated",
                SenderURL = "updated.se"
            };
            try
            {
                var result = Task.Run(() => SenderAPI.UpdateSender(sender));

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Updated sender");
            Console.WriteLine("Press enter..");
            Console.ReadLine();
            RunGetSender(id).Wait();
        }
        private static async Task RunCreateSender(long id)
        {

            var sender = new SenderDTO
            {
                SenderID = id,
                SenderName = "Björns Trosor",
                UserName = "Björn",
                SenderURL = "thepiratebay.se"
            };

            try
            {
                var result = Task.Run(() => SenderAPI.CreateSender(sender));

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press enter..");
            Console.ReadLine();
            RunGetSender(id).Wait();
        }
        #endregion
        #region/*packages, deliveries and recievers */

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
        private static async Task RunGetPackageForSenderID(long id)
        {
            var list = PackageAPI.GetPackagesForSenderID(id).Result;
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
        #endregion
        #region/*Test method*/
        private static void RunTesting(int id)
        {
            //for(int i = 1; i < 3; i++)
            //{
            //    RunGetSender(i).Wait();
            //}
            //RunGetSender(10).Wait();
            RunCreateDriver(3).Wait();
        }
        #endregion
    }
}
