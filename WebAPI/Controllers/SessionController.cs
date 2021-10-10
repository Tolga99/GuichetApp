using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBLL;
using LibraryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        [HttpGet("numcat/{idSess}")]
        public IActionResult GetNumberCategories(int idSess) // A faire
        {
            SessionMethods sessionMethods = new SessionMethods();
            int num=sessionMethods.GetNbCategoriesOfSessionById(idSess);
            return Ok(num);
        }
        [HttpGet("numcat/{nameSess}")]
        public IActionResult GetNumberCategories(String nameSess) // A faire
        {
            SessionMethods sessionMethods = new SessionMethods();
            int num = sessionMethods.GetNbCategoriesOfSessionByName(nameSess);
            return Ok(num);
        }
        [HttpGet("sessions")]
        public IActionResult GetAllSessions() // Rajouter l'user apres
        {
            SessionMethods sessionMethods = new SessionMethods();
            ICollection<SessionDTO> sess = sessionMethods.GetAllFullSessions();
            return Ok(sess);
        }

        [HttpPost("newsession/{nameSess}")]
        public IActionResult CreateSession(String nameSess)
        {
            SessionMethods sessionMethods = new SessionMethods();
            sessionMethods.CreateSession("admin", nameSess);
            return Ok();
        }
    }
}
