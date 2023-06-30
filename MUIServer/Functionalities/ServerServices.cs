using MUIServer.Controllers;
using System.Net;

namespace MUIServer.Functionalities
{

    public class ServerServices
    {
        public static void ServerName(string serverName) 
        {
            Console.WriteLine(serverName); 
        }
        
        public static void ServerVersion() 
        { 
            string serverVersion = "MUIServer v1.0.0 " + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day;
            Console.WriteLine(serverVersion); 
        }
        
        public static void ServerStartTime(System.DateTime startTime) 
        {
            startTime =  System.DateTime.Now;
            Console.WriteLine("Server start time = " + startTime); 
        }
        
        public static string ServerUrl(string serverUrl) { return serverUrl; }

        public static void ServerIp()
        {
            var hostName = Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
            System.Net.IPAddress[] addresses = hostEntry.AddressList;

            foreach (System.Net.IPAddress address in addresses)
            {
                Console.WriteLine("Adres IP serwera: " + address.ToString());
            }
        }
        
        public static int ServerPort(int serverPort) { return serverPort; }

        public static void AboutAuthor() 
        {
            string author = "Copyrights © 2023 Created by MAD Script Michał Piotr Jabrzyk All Rights Reserved"; 
            Console.WriteLine(author);
        }
    }
}
