using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtFirebase.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TokensController : ControllerBase
    {

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<string> Ping()
        {
            System.Console.WriteLine("Ping request..");

            return Ok("pong");
        }

        [Authorize]
        [HttpGet("protected")]
        public ActionResult ProtectedResource()
        {
            return Ok(new
            {
                Message = "Deluxe and protected Hello World"
            });
        }

    }

}