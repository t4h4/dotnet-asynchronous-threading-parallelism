using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        // IActionResult interface'si sayesinde ok, not found, bad request class'lar donebilme imkanimiz olur.
        // Bu class'lar IActionResult interface'i implemente eder.
        [HttpGet]
        public async Task<IActionResult> GetContentAsync()
        {
            var mytask = new HttpClient().GetStringAsync("https://www.google.com");
            //
            var data = await mytask;

            return Ok(data);
        }
    }
}
