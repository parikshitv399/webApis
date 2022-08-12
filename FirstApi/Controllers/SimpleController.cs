using FirstApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        [HttpGet("/Hello")]
        public string Hello()
        {
            return "Welcome to WebApi";
        }
        [HttpGet("/SpecialHello/{pname}")]
        public string SpecialHello([FromRoute] string pname)
        {
            return "Welcome to WebApi " + pname;
        }
        [HttpPost("/login/{username}")]
        public string Login([FromRoute] string username, [FromBody] string password)
        {
            return $"Login Successful for user {username}!";
        }
        [HttpPost("/items")]
        public IActionResult GetItems(string? otp)
        {
            if (otp == null || otp.Trim(' ') == string.Empty)
            {
                return Unauthorized("You are unauthorized to access this resource.");
            }
            return Ok(new string[] { "Apparels", "Grocery", "Mobiles" });
        }

        [HttpGet("/errors/get")]
        public IActionResult DivideOperations(int? n2 = null)
        {
            try
            {
                return Ok(n2);
            }
            catch (NullReferenceException nex)
            {
                return BadRequest(nex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Something has gone wrong, contact helpdesk");
            }
        }
        [HttpGet("/threading")]
        public IActionResult FunWithThreads()
        {
            ThreadStart th1 = new ThreadStart(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Debug.WriteLine($"Thread 1 started..({i}) times");
                }
            });
            ThreadStart th2 = new ThreadStart(() =>
            {
                for (int i = 0; i < 9999; i++)
                {
                    Debug.WriteLine($"Thread 2 started..({i}) times");
                }
            });
            th1.DynamicInvoke();
            th2.DynamicInvoke();
            return Ok("My threads will run successfully");
        }
        [HttpGet("/async")]
        public async Task<IActionResult> FunWithAsync()
        {
            await Task.Run(()=>{ Debug.WriteLine("This is an async method!"); });
            return Ok();
        }
    }
}
