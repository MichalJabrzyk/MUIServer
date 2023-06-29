using Microsoft.AspNetCore.Mvc;
using System.Globalization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MUIServer.Controllers
{
    [Route("mainserverinfo")]
    [ApiController]
    public class MainServerInfo : ControllerBase
    {
        [HttpGet("serverid")]
        public int GetMainServerId(int serverid) 
        {
            return serverid;
        }

        [HttpPost("serverid")]
        public int PastMainServerId(int serverid) 
        { 
            return serverid; 
        }

        [HttpGet("servername")]
        public string GetMainServerName(string serverName)
        {
            return serverName;
        }

        [HttpPost("servername")]
        public string SetMainServerName(string serverName) 
        { 
            return serverName; 
        }

        [HttpGet("serverversion")]
        public string GetMainServerVersion(string serverVersion)
        {
            return serverVersion;
        }

        [HttpPost("serverversion")]
        public string SetMainServerVersion(string serverVersion)
        {
            return serverVersion;
        }

        [HttpGet("serverip")]
        public string GetMainServerIp(string serverIp)
        {
            return serverIp;
        }

        [HttpPost("serverip")]
        public string SetMainServerIp(string serverIp)
        {
            return serverIp;
        }

        [HttpGet("serverport")]
        public string GetMainServerPort(string serverPort)
        {
            return serverPort;
        }

        [HttpPost("serverport")]
        public string SetMainServerPort(string serverPort)
        {
            return serverPort;
        }

        [HttpGet("serverurl")]
        public string GetMainServerUrl(string serverUrl)
        {
            return serverUrl;
        }

        [HttpPost("serverurl")]
        public string SetMainServerUrl(string serverUrl)
        {
            return serverUrl;
        }

        [HttpGet("serverstarttime")]
        public DateTime GetServerStartLiveTime(DateTime startTime)
        {
            startTime = MainServerProgram.startTime;
            Console.WriteLine(" Server start time = " + startTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));
            return startTime;
        }

        [HttpPost("serverstarttime")]
        public DateTime SetServerStartLiveTime(DateTime startTime)
        {
            startTime = MainServerProgram.startTime;
            Console.WriteLine(" Server start time = " + startTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));
            return startTime;
        }

        [HttpGet("servercurrenttime")]
        public DateTime GetServerTime()
        {
            var serverTime = new DateTime();
            serverTime = DateTime.Now;
            Console.WriteLine(" Server current time = " + serverTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));
            return serverTime;
        }

        [HttpPost("servercurrenttime")]
        public DateTime SetServerTime()
        {
            var serverTime = new DateTime();
            serverTime = DateTime.Now;
            Console.WriteLine(" Server current time = " + serverTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));
            return serverTime;
        }

        [HttpGet("serverlivetime")]
        public TimeSpan GetServerLiveTime(DateTime startTime, DateTime currentTime)
        {
            startTime = MainServerProgram.startTime;
            currentTime = DateTime.Now;
            TimeSpan serverLiveTime = currentTime - startTime;
            Console.WriteLine(" Server livetime = " + serverLiveTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));
            return serverLiveTime;
        }

        [HttpPost("serverlivetime")]
        public TimeSpan SetServerLiveTime(DateTime startTime, DateTime currentTime)
        {
            startTime = MainServerProgram.startTime;
            currentTime = DateTime.Now;
            TimeSpan serverLiveTime = currentTime - startTime;
            Console.WriteLine(" Server livetime = " + serverLiveTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));
            return serverLiveTime;
        }

    }
}
