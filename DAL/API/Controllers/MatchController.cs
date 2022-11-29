using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using BLL;

namespace API.Controllers
{
    [Route("api/Match/")]
    [ApiController]
    public class MatchController : Controller
    {
        IBllMatch bllMatch;

        public MatchController(IBllMatch bllMatch)
        {
            this.bllMatch = bllMatch;
        }
        [HttpPost("MatchOfficeToRenter")]
        public ActionResult MatchOfficeToRenter(DTORenter renter)
        {
            return Ok(bllMatch.matchingOfficeToRenter(renter));
        }
    }
}
