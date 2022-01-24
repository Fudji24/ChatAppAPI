using ChatAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PusherServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpPost(template: "messages")]
        public async Task<ActionResult> Index(Chat chat)
        {
            var options = new PusherOptions
            {
                Cluster = "eu",
                Encrypted = true
            };

            var pusher = new Pusher(
              "1337121",
              "6805be4fb94b379f8d38",
              "047662fa2c57309a2bed",
              options);

             await pusher.TriggerAsync(
              channelName: "chat",
              eventName: "message",
              new { username = chat.Username,
                  message = chat.Message });

            return Ok(new string[] { });
        }
    }
}
