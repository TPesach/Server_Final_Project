using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using BLL;

namespace API.Controllers
{
    [Route("api/Renter/")]
    [ApiController]
    public class RenterController : Controller
    {
        IBllRenter BllRenter;

        public RenterController(IBllRenter bllRenter)
        {
            this.BllRenter = bllRenter;
        }
        #region functionToUser
        [HttpGet("GetAllRenters")]
        public ActionResult GetAllRenters()
        {
            return Ok(BllRenter.GetAllRenters());
        }
        [HttpGet("GetRenterById/{id}")]
        public ActionResult GetRenterById(int id)
        {
            return Ok(BllRenter.GetRenterById(id));
        }
        [HttpGet("GetRentersByOfficeId/{Officeid}")]
        public ActionResult GetRentersByOfficeId(string Officeid)
        {
            return Ok(BllRenter.GetRentersByOfficeId(Officeid));
        }
        [HttpGet("GetRenterByNameAndPassword/{name}/{password}")]
        public ActionResult GetRenterByNameAndPassword(string name, string password)
        {
            return Ok(BllRenter.GetRenterByNameAndPassword(name, password));
        }
        [HttpGet("GetRenterByMail/{mail}")]
        public ActionResult GetRenterByMail(string mail)
        {
            return Ok(BllRenter.GetRenterByMail(mail));
        }
        [HttpGet("GetRenterByPhone/{phone}")]
        public ActionResult GetRenterByPhone(string phone)
        {
            return Ok(BllRenter.GetRenterByPhone(phone));
        }
        //delete
        [HttpGet("DeleteRenterById/{renterId}")]
        public ActionResult DeleteRenterById(int renterId)
        {
            return Ok(BllRenter.DeleteRenterById(renterId));
        }


        //update
        [HttpPost("UpdateRenterById/{renterId}")]
        public ActionResult UpdateRenterById(int renterId, DTORenter Renter)
        {
            return Ok(BllRenter.UpdateRenterById(renterId, Renter));
        }


        //add
        [HttpPost("AddRenter")]
        public ActionResult AddRenter(DTORenter Renter)
        {
            return Ok(BllRenter.AddRenter(Renter));
        }


        #endregion

        #region functionToadditiveDetails
        //get
        [HttpGet("GetAllAdditiveByRenter/{RenterId}")]
        public ActionResult GetAllAdditiveByRenter(int RenterId)
        {
            return Ok(BllRenter.GetAllAdditiveByRenter(RenterId));
        }
        [HttpGet("GetAdditiveDetailsById/{RenterId}/{additiveDetailsId}")]
        public ActionResult GetAdditiveDetailsById(int RenterId, int additiveDetailsId)
        {
            return Ok(BllRenter.GetAdditiveDetailsById(RenterId, additiveDetailsId));
        }
        [HttpGet("GetAdditiveDetailsByName/{RenterId}/{additiveDetailsId}")]
        public ActionResult GetAdditiveDetailsByName(int RenterId, string additiveDetailsName)
        {
            return Ok(BllRenter.GetAdditiveDetailsByName(RenterId, additiveDetailsName));
        }

        //delete
        [HttpDelete("DeleteAdditiveDetails/{RenterId}")]
        public ActionResult DeleteAdditiveDetails(int RenterId, DTOAdditiveForRenter additiveDetails)
        {
            return Ok(BllRenter.DeleteAdditiveDetails(RenterId, additiveDetails));
        }


        //update
        [HttpPost("UpdateAdditiveDetails/{RenterId}/{additiveDetailsId}")]
        public ActionResult UpdateAdditiveDetails(int RenterId, int additiveDetailsId, DTOAdditiveForRenter additiveDetails)
        {
            return Ok(BllRenter.UpdateAdditiveDetails(RenterId, additiveDetailsId, additiveDetails));
        }


        //add
        [HttpPut("AddAdditiveDetails/{RenterId}")]
        public ActionResult AddAdditiveDetails(int RenterId, DTOAdditiveForRenter additiveDetails)
        {
            return Ok(BllRenter.AddAdditiveDetails(RenterId, additiveDetails));
        }
        #endregion
    }
}
