using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBLL;
using LibraryDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpGet("alltickets")]
        public IActionResult GetAllTickets() // A faire
        {
            TicketMethods ticketMethods = new TicketMethods();
            List<TicketDTO> list=ticketMethods.GetAllTicketOfSession(1); 
            return Ok(list);
        }
        [HttpGet("sesstickets/{idSess}")]
        public IActionResult GetSessionTickets(int idSess)
        {
            TicketMethods ticketMethods = new TicketMethods();
            List<TicketDTO> list = ticketMethods.GetAllTicketOfSession(idSess);
            return Ok(list);
        }

        [HttpPost("newticket/{idSess}/{idCat}")]
        public void CreateTicket(int idSess,int idCat)
        {
            TicketMethods ticketMethods = new TicketMethods();
            ticketMethods.CreateTicket(idSess,idCat-1);
            //List<TicketDTO> list = ticketMethods.GetAllTicketOfSession(1);
            //return Ok(list);
        }
    }
}
