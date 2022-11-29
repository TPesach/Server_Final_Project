using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;

namespace API.Controllers
{
    [Route("api/Additive/")]
    [ApiController]
    public class AdditiveController : Controller
    {
        IBllAdditive BllAdditive;
        public AdditiveController(IBllAdditive bllAdditive)
        {
            this.BllAdditive = bllAdditive;
        }

        //get

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            return Ok(BllAdditive.GetAllAdditive());
        }

        [HttpGet("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(BllAdditive.GetById(id));
        }
        [HttpGet("GetById/{name}")]
        public ActionResult GetByName(string name)
        {
            return Ok(BllAdditive.GetByName(name));
        }

        //delete


        [HttpDelete("DeleteAdditiveById/{id}")]
        public ActionResult DeleteAdditiveById(int id)
        {
            return Ok(BllAdditive.DeleteAdditiveById(id));
        }
        [HttpDelete("DeleteAdditive")]
        public ActionResult DeleteAdditive(DTOAdditiveGeneral additive)
        {
            return Ok(BllAdditive.DeleteAdditive(additive));
        }

        //update

        [HttpPut("UpdateAdditive/{id}")]
        public ActionResult UpdateAdditive(int id, DTOAdditiveGeneral additive)
        {
            return Ok(BllAdditive.UpdateAdditive(id, additive));
        }

        [HttpPost("AddAdditive")]
        public ActionResult AddAdditive(DTOAdditiveGeneral additive)
        {
            return Ok(BllAdditive.AddAdditive(additive));
        }

    }
}
