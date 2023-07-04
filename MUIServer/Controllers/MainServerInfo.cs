using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MUIServer.Entities;
using System.Globalization;

namespace MUIServer.Controllers
{
    [Route("api/mainserverinfo")]
    [ApiController]
    [Authorize(Roles = "Administrator, Developer")]
    public class MainServerInfo : ControllerBase
    {
        private readonly MainServerDbContext mainServerDbContext;

        public MainServerInfo(MainServerDbContext dbContext)
        {
            mainServerDbContext = dbContext;
        }

        [HttpGet("serverid")]
        public ActionResult <MainServer> GetMainServerId()
        {
            MainServer mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            var serverId = mainServer.MainServerID;
            Console.WriteLine(" 'GET serverid' Server id = " + serverId);

            return Ok(mainServer.MainServerID);
        }

        [HttpPost("serverid")]
        public ActionResult SetMainServerId(int serverId)
        {
            var mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            mainServer.MainServerID = serverId;
            Console.WriteLine(" 'POST serverid' Server id = " + serverId);

            try
            {
                mainServerDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(mainServer.MainServerID);
        }

        [HttpGet("servername")]
        public ActionResult<MainServer> GetMainServerName()
        {
            MainServer mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            var serverName = mainServer.MainServerName;
            Console.WriteLine(" 'GET servername' Server name = " + serverName);

            return Ok(mainServer.MainServerName);
        }

        [HttpPost("servername")]
        public ActionResult SetMainServerName(string serverName)
        {
            var server_Name = mainServerDbContext.MainServer.FirstOrDefault();

            if (server_Name is null)
            {
                return NotFound();
            }

            server_Name.MainServerName = serverName;
            Console.WriteLine(" 'POST servername' Server name = " + serverName);

            try
            {
                mainServerDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(server_Name.MainServerName);
        }

        [HttpGet("serverversion")]
        public ActionResult<MainServer> GetMainServerVersion()
        {
            MainServer mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            var serverVersion = mainServer.MainServerVersion;
            Console.WriteLine(" 'GET serverversion' Server version = " + serverVersion);

            return Ok(mainServer.MainServerVersion);
        }

        [HttpPost("serverversion")]
        public ActionResult SetMainServerVersion(string serverVersion)
        {
            var mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            mainServer.MainServerName = serverVersion;
            Console.WriteLine(" 'POST serverversion' Server version = " + serverVersion);

            try
            {
                mainServerDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(mainServer.MainServerVersion);
        }

        [HttpGet("serverip")]
        public ActionResult<MainServer> GetMainServerIp()
        {
            MainServer mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            var serverIp = mainServer.MainServerIP;
            Console.WriteLine(" 'GET serverip' Server ip = " + serverIp);

            return Ok(mainServer.MainServerIP);
        }

        [HttpPost("serverip")]
        public ActionResult SetMainServerIp(string serverIp)
        {
            var mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            mainServer.MainServerIP = serverIp;
            Console.WriteLine(" 'POST serverip' Server ip = " + serverIp);

            try
            {
                mainServerDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(mainServer.MainServerIP);
        }

        [HttpGet("serverport")]
        public ActionResult<MainServer> GetMainServerPort()
        {
            MainServer mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            var serverPort = mainServer.MainServerPort;
            Console.WriteLine(" 'GET serverport' Server port = " + serverPort);

            return Ok(mainServer.MainServerPort);
        }

        [HttpPost("serverport")]
        public ActionResult SetMainServerPort(int serverPort)
        {
            var mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            mainServer.MainServerPort = serverPort;
            Console.WriteLine(" 'POST serverport' Server port = " + serverPort);

            try
            {
                mainServerDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(mainServer.MainServerPort);
        }

        [HttpGet("serverurl")]
        public ActionResult<MainServer> GetMainServerUrl()
        {
            MainServer mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            var serverUrl = mainServer.MainServerURL;
            Console.WriteLine(" 'GET serverurl' Server url = " + serverUrl);

            return Ok(mainServer.MainServerURL);
        }

        [HttpPost("serverurl")]
        public ActionResult SetMainServerUrl(string serverUrl)
        {
            var mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            mainServer.MainServerURL = serverUrl;
            Console.WriteLine(" 'POST serverurl' Server url = " + serverUrl);

            try
            {
                mainServerDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(mainServer.MainServerURL);
        }

        [HttpGet("serverstarttime")]
        public ActionResult<MainServer> GetServerStartTime()
        {
            MainServer mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            var serverStartTime = mainServer.MainServerTimeStart;
            Console.WriteLine(" 'GET serverstarttime' Server start time = " + serverStartTime);

            return Ok(mainServer.MainServerTimeStart);
        }

        [HttpPost("serverstarttime")]
        public ActionResult SetServerStartTime(DateTime serverStartTime)
        {
            var mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            serverStartTime = MainServerProgram.startTime;
            mainServer.MainServerTimeStart = serverStartTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl"));
            Console.WriteLine(" 'POST serverstarttime' Server start time = " + serverStartTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));

            try
            {
                mainServerDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(mainServer.MainServerTimeStart);
        }

        [HttpGet("servercurrenttime")]
        public ActionResult<MainServer> GetServerCurrentTime(DateTime serverCurrentTime)
        {
            MainServer mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            serverCurrentTime = DateTime.Now;
            Console.WriteLine(" 'GET servercurrenttime' Server current time = " + serverCurrentTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));
            return Ok(serverCurrentTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));
        }

        [HttpGet("serverlivetime")]
        public ActionResult<MainServer> GetServerLivetime()
        {
            MainServer mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            var serverStartTime = MainServerProgram.startTime;
            var serverCurrentTime = DateTime.Now;
            TimeSpan serverLiveTime = serverCurrentTime - serverStartTime;
            Console.WriteLine(" 'GET serverlivetime' Server livetime = " + serverLiveTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));
            mainServer.MainServerLivetime = serverLiveTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl"));

            return Ok(mainServer.MainServerLivetime);
        }

        [HttpPost("serverlivettime")]
        public ActionResult SetServerLivetime(DateTime serverLivetime)
        {
            var mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            var serverStartTime = MainServerProgram.startTime;
            var serverCurrentTime = DateTime.Now;
            TimeSpan serverLiveTime = serverCurrentTime - serverStartTime;
            Console.WriteLine(" 'POST serverlivetime' Server livetime = " + serverLiveTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));
            mainServer.MainServerLivetime = serverLiveTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl"));

            try
            {
                mainServerDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(mainServer.MainServerLivetime);
        }

        [HttpGet("serverendtime")]
        public ActionResult<MainServer> GetServerEndTime()
        {
            MainServer mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            var serverEndTime = mainServer.MainServerTimeEnd;
            Console.WriteLine(" 'GET serverlivetime' Server livetime = " + serverEndTime);
           
            return Ok(mainServer.MainServerTimeEnd);

        }

        [HttpPost("serverendtime")]
        public ActionResult SetServerEndTime(DateTime serverEndTime)
        {
            var mainServer = mainServerDbContext.MainServer.FirstOrDefault();

            if (mainServer is null)
            {
                return NotFound();
            }

            serverEndTime = MainServerProgram.endTime;
            Console.WriteLine(" 'POST serverendtime' Server endtime = " + serverEndTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl")));
            mainServer.MainServerTimeEnd = serverEndTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl"));

            try
            {
                mainServerDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(mainServer.MainServerTimeEnd);
        }


    }
}