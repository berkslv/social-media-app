using System.Net;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core.Extensions
{
    public class ControllerExtension : Controller
    {
        [NonAction]
        public IActionResult ReturnFactory(HttpStatusCode statuscode, IResult result)
        {
            switch (statuscode)
            {
                case HttpStatusCode.OK:
                    return Ok(result);
                case HttpStatusCode.BadRequest:
                    return BadRequest(result);
                case HttpStatusCode.NoContent:
                    return NoContent();
                case HttpStatusCode.UnprocessableEntity:
                    return UnprocessableEntity(result);
                default:
                    return StatusCode((int)result.StatusCode, result);
            }
        }
    }
}