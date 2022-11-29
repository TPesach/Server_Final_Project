using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO;
using BLL;

namespace API.Controllers
{
    [Route("api/Hirer/")]
    [ApiController]
    public class HirerController : Controller
    {
        IBllHirer BllHirer;
        public HirerController(IBllHirer bllHirer)
        {
            this.BllHirer = bllHirer;
        }

        [HttpGet("GetAllHirers")]

        public ActionResult GetAllHirers()
        {
            return Ok(BllHirer.GetAllHirer());
        }

        [HttpGet("GetHirerById/{id}")]

        public ActionResult GetHirerById(string id)
        {
            return Ok(BllHirer.GetHirerById(id));
        }

        [HttpGet("GetHirerByOfficeId")]

        public ActionResult GetHirerByOffice(string officeId)
        {
            return Ok(BllHirer.GetHirerByOffice(officeId));
        }

        [HttpGet("GetHirerByNameAndPassword/{name}/{password}")]

        public ActionResult GetHirerByNameAndPassword(string name, string password)
        {
            return Ok(BllHirer.GetHirerByNameAndPassword(name, password));
        }

        [HttpGet("GetHirerByMail/{mail}")]

        public ActionResult GetHirerByMail(string mail)
        {
            return Ok(BllHirer.GetHirerByMail(mail));
        }

        [HttpGet("GetHirerByPhone/{phone}")]

        public ActionResult GetHirerByPhone(string phone)
        {
            return Ok(BllHirer.GetHirerByPhone(phone));
        }


        [HttpDelete("DeleteHirerById/{id}")]

        public ActionResult DeleteHirerById(string id)
        {
            return Ok(BllHirer.DeleteHirerById(id));
        }

        [HttpPut("UpdateHirerById/{id}")]

        public ActionResult UpdateHirerById(string id, DTOHirer hirer)
        {
            return Ok(BllHirer.UpdateHirerById(id, hirer));
        }

        [HttpPost("AddHirer")]

        public ActionResult AddHirer(DTOHirer hirer)
        {
            return Ok(BllHirer.AddHirer(hirer));
        }
        [HttpPost("AddOfficeToHirer")]

        public ActionResult AddOfficeToHirer(int hirerId, int officeId)
        {
            return Ok(BllHirer.AddOfficeToHirer(hirerId, officeId));
        }
    }
}
