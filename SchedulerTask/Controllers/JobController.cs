using Hangfire;
using Hangfire.Storage;
using Microsoft.AspNetCore.Mvc;
using SchedulerTask.Services;

namespace SchedulerTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        [HttpGet]
        [Route("RunJobApi")]
        public ActionResult RunJobApi()
        {
            return Ok();
        }
    }
}


    
