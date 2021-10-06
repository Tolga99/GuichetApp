using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost("new/{nameSess}")]
        public IActionResult CreateCategories(String nameSess, [FromQuery] String[] names) // A faire
    {
            CategoryMethods categoryMethods = new CategoryMethods();
            categoryMethods.CreateCategories(nameSess, names);
            return Ok();
    }
}
}
