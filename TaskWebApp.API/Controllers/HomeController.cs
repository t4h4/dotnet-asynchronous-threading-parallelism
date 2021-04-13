using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        // IActionResult interface'si sayesinde ok, not found, bad request class'lar donebilme imkanimiz olur.
        // Bu class'lar IActionResult interface'i implemente eder.
        [HttpGet]
        public async Task<IActionResult> GetContentAsync(CancellationToken token)
        {
            try
            {
                _logger.LogInformation("istek basladi");

                await Task.Delay(5000, token);

                var mytask = new HttpClient().GetStringAsync("https://www.google.com");
                //
                var data = await mytask;

                _logger.LogInformation("istek bitti");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("istek iptal edildi" + ex.Message);
                return BadRequest();
            }

           
        }
    }
}
