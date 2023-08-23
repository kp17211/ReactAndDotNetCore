using DotNetDemo.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class LogicController : ControllerBase
    {

        [HttpPost("add")]
        public ActionResult CalculateSum(RequestModel request)
        {
            ResponseModel res = new ResponseModel();
            if (request != null)
            {
                res.Sum = request.Number1 + request.Number2;
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}