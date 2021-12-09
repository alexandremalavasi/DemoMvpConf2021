using System.Collections.Generic;
using System.Linq;
using MVPConfDemo.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazoredRepairs.Server.Controllers
{
    [ApiController, Route("api")]
    public class ParticipantController : Controller
    {
        private static List<ParticipantModel> _participants = new List<ParticipantModel>
        {
            new ParticipantModel{
                Name = "Alexandre Malavasi",
                JobTitle = "Senior Developer",
                Email = "alexandremalavasi@hotmail.com",
                PaymentConfirmed = false
            },
             new ParticipantModel{
                Name = "Bruno Brito",
                JobTitle = "Senior Developer",
                Email = "brunobrito@teste.com",
                PaymentConfirmed = false
            },
            new ParticipantModel{
                Name = "Renato Grofe",
                JobTitle = "Senior Developer",
                Email = "renato.grofe@teste.com",
                PaymentConfirmed = true
            }
        };

        [HttpGet("participants")]
        public IActionResult GetParticipants()
        {
            return Ok(_participants);
        }

        [HttpPost("participants")]
        public IActionResult AddParticipant(ParticipantModel participant)
        {
            _participants.Add(participant);
            return Ok();
        }
    }
}