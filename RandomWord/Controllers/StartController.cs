using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandomWord.Data;
using RandomWord.Models;

namespace RandomWord.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StartController : ControllerBase
    {

        private readonly ILogger<StartController> _logger;

        public StartController(ILogger<StartController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Command Get()
        {
            var rng = new Random();
            Command command = new Command();
            command.commandRunning = true;
            command.currentWord = "Janhvi";
            command.timeRemaining = 30;
            JsonResult jsonResult = new JsonResult(command);
            updateDatabase();
            return command;
        }
      
        public static void updateDatabase()
        {
            using CommandLogContext context = new CommandLogContext();

            CommandLog commandLog = new CommandLog()
            {
                Commands = "Connecting",
                State = "Initial Connection"
            };
            context.commandLogs.Add(commandLog);
            context.SaveChanges();
        }
    }
}
