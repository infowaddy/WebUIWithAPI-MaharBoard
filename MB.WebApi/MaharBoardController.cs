using MB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MB.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaharBoardController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Mahaboard mahaboard)
        {
            DateOnly birthdate = mahaboard.BirthDate;
            int day = (int)birthdate.DayOfWeek;

            return Ok();
        }
    }
}
