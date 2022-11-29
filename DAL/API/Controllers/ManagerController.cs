using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using BLL;

namespace API.Controllers
{

    [Route("api/Manager/")]
    [ApiController]
    public class ManagerController : Controller
    {
        IBllManager bllManager;
        public ManagerController(IBllManager bllManager)
        {
            this.bllManager = bllManager;
        }

        [HttpGet("GetAllManager")]
        public ActionResult GetAllManager()
        {
            return Ok(bllManager.GetAllManager());
        }

        [HttpGet("GetManagerById/{id}")]
        public ActionResult GetManagerById(int id)
        {
            return Ok(bllManager.GetManagerById(id));
        }

        [HttpGet("GetManagerByNameAndPassword/{name}/{password}")]
        public ActionResult GetManagerByNameAndPassword(string name, string password)
        {
            return Ok(bllManager.GetManagerByNameAndPassword(name, password));
        }

        [HttpGet("GetManagerByMail/{mail}")]
        public ActionResult GetManagerByMail(string mail)
        {
            return Ok(bllManager.GetManagerByMail(mail));
        }

        [HttpGet("GetManagerByPhone/{phone}")]
        public ActionResult GetManagerByPhone(string phone)
        {
            return Ok(bllManager.GetManagerByPhone(phone));
        }
    }
}
