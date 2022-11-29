using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using BLL;

namespace API.Controllers
{

    [Route("api/Office/")]
    [ApiController]
    public class OfficeController : Controller
    {
        IBllOffice BllOffice;

        public OfficeController(IBllOffice bllOffice)
        {
            this.BllOffice = bllOffice;
        }

        [HttpGet("GetAllOffices")]
        public ActionResult GetAllOffices()
        {
            return Ok(BllOffice.GetAllOffices());
        }

        [HttpGet("GetOfficeById/{id}")]
        public ActionResult GetOfficeById(Int32 id)
        {
            return Ok(BllOffice.GetOfficeById(id));
        }

        [HttpGet("GetOfficeByCity/{city}")]
        public ActionResult GetOfficesByCity(string city)
        {
            return Ok(BllOffice.GetOfficesByCity(city));
        }

        [HttpPut("GetOfficesByHirer")]
        public ActionResult GetOfficesByHirer(DTOHirer hirer)
        {
            return Ok(BllOffice.GetOfficesByHirer(hirer));
        }

        [HttpGet("GetOfficesByRenter")]
        public ActionResult GetOfficesByRenter(DTORenter renter)
        {
            return Ok(BllOffice.GetOfficesByRenter(renter));
        }

        [HttpDelete("DeleteOfficeById{id}")]
        public ActionResult DeleteOfficeById(Int32 id)
        {
            return Ok(BllOffice.DeleteOfficeById(id));
        }

        [HttpPut("UpdateOffice{id}")]
        public ActionResult UpdateOffice(Int32 id, DTOOffice office)
        {
            return Ok(BllOffice.UpdateOffice(id, office));
        }

        [HttpPost("AddOffice")]
        public ActionResult AddOffice(DTOOffice office)
        {
            return Ok(BllOffice.AddOffice(office));
        }


        #region functionTOSchedule

        [HttpGet("GetSchedulesByOfficeId/{officeId}")]
        public ActionResult GetSchedulesByOfficeId(Int32 officeId)
        {
            return Ok(BllOffice.GetSchedulesByOfficeId(officeId));
        }
        [HttpPost("AddSchedule/officeId")]
        public ActionResult AddSchedule(Int32 officeId, DTOSchedule schedule)
        {
            return Ok(BllOffice.AddSchedule(officeId, schedule));
        }
        ////get
        [HttpPut("UpdateSchedule/officeId/scheduleId")]
        public ActionResult UpdateSchedule(Int32 officeId, string scheduleId, DTOSchedule schedule)
        {
            return Ok(BllOffice.UpdateSchedule(officeId, schedule, scheduleId));
        }





        #endregion
    }
}
