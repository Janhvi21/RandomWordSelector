using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomWord.Data;
using RandomWord.Models;

namespace RandomWord.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebSocketsController : ControllerBase
    {
        [HttpGet("/ws")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                var rng = new Random();
                Command command = new Command();
                command.commandRunning = true;
                command.currentWord = "Janhvi";
                command.timeRemaining = 30;
                JsonResult jsonResult = new JsonResult(command);
                //return command;
                await Echo(webSocket);
                
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }
        private async Task Echo(WebSocket webSocket)
        {
            try
            {
                var buffer = new byte[1024 * 4];
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                var input = Encoding.UTF8.GetString(buffer, 0, result.Count);
                String[] randomWords = getListOfWords(input);
                int i = 0;
                updateDatabase(false, "Command Start", 60);
                DateTime sessionStart = DateTime.Now;
                while (!result.CloseStatus.HasValue)
                {
                    if (i != 0)
                    {
                        await Task.Delay(60000 / randomWords.Length);
                    }
                    Command command = new Command();
                    command.commandRunning = true;
                    command.currentWord = randomWords[i++];
                    command.timeRemaining = 60 - (int)DateTime.Now.Subtract(sessionStart).TotalSeconds;
                    var serverMsg = Encoding.UTF8.GetBytes(command.commandRunning + "," + command.currentWord + "," + command.timeRemaining);
                    await webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
                    updateDatabase(command.commandRunning, $"Current Word Selected: {command.currentWord}", command.timeRemaining);

                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                }
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                updateDatabase(false, "Command Closed", 0);
            }
        }
        public static void updateDatabase(bool commandRunning, string state, int timeRemaining)
        {
            using CommandLogContext context = new CommandLogContext();

            CommandLog commandLog = new CommandLog()
            {
                Commands = commandRunning.ToString(),
                State = state,
                TimeRemaining = timeRemaining
            };
            context.commandLogs.Add(commandLog);
            context.SaveChanges();
        }
        public static String[] getListOfWords(String words)
        {
            String[] wordList = words.Split(",");
            Random random = new Random();
            for (int t = 0; t < wordList.Length; t++)
            {
                string tmp = wordList[t];
                int r = random.Next(wordList.Length);
                wordList[t] = wordList[r];
                wordList[r] = tmp;
            }
            return wordList;

        }
    }
}
