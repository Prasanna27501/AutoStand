using Microsoft.AspNetCore.Mvc;
using AutoStandpro.Contracts;
using AutoStandpro.Config;
using AutoStand.Models;

namespace AutoStandpro.Controller
{
    [Route("auto")]
    [ApiController]
    public class autoController : ControllerBase
    {
        private readonly IAutoRepository _autoRepo;
        private object userService;

        public autoController(IAutoRepository autoRepo)
        {
            _autoRepo = autoRepo;
        }

        [HttpGet("getAutoAvailable")]
        public async Task<IActionResult> Getautoavailable()
        {
            try
            {
                var userresults = await _autoRepo.autoavailable();
                return Ok(userresults);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("loginUser")]
        [ProducesResponseType(typeof(Response), 200)]
        public async Task<Response> checkLogin([FromBody] userLogin userlogin)
        {
            Response response = new Response();
            isAvailableResponse isAvailableresponse = new isAvailableResponse();
            /*var userInDatabase = await _context.users.FirstOrDefaultAsync(u => u.mobileNumber == userlogin.Username && u.Password == userlogin.Password);*/
            //var user = _context.FirstOrDefault(u => u.mobileNumber == userlogin.mobileNumber && u.password == userlogin.password);
            //userLoginforQuery selectQuery = new userLoginforQuery();
            var sql = "SELECT * FROM autostand.autodetails WHERE (mobilenumber = '" + userlogin.mobileNumber + "',password = '" + userlogin.password + "')";
            Console.WriteLine(sql);
            if (sql == null)
            {
                response.status = 404;
                response.Message = "Not found";
            }
            else
            {
                isAvailableresponse.mobileNumber = userlogin.mobileNumber;
                isAvailableresponse.isAvailable = "Yes";
                response.status = 200;
                response.Message = "Success";
            }
            _autoRepo.checkin(isAvailableresponse);
            return response;
        }
        [HttpPost("register")]
        public async Task<Response> registerUser([FromBody] autoDetails details)
        {
            autoDetailsResponse response = new autoDetailsResponse();
            Response responseObj = new Response();
            response.autoId = details.autoId;
            response.autoNumber = details.autoNumber;
            response.ownerName = details.ownerName;
            response.mobileNumber = details.mobileNumber;
            response.password = details.password;
            response.ratting = details.ratting;
            response.isAvailable = details.isAvailable;
            _autoRepo.userRegistration(response);
            responseObj.status = 200;
            responseObj.Message = "Success";
            return responseObj;
        }
        [HttpPost("destinationinsert")]
        [ProducesResponseType(typeof(Response), 200)]
        public async Task<Response> destinationinsert([FromBody] DestinationDetail details)
        {
            Response responseobj = new Response();
            DestinationDetailwihtId destinations = new DestinationDetailwihtId();

            destinations.destinationId = details.destinationId;
            destinations.destinationName = details.destinationName;
            destinations.amount = details.amount;
            destinations.kilometre = details.kilometre;
            responseobj.status = 200;
            responseobj.Message = "Success";
            _autoRepo.destinationRegister(destinations);
            return responseobj;
        }
        // [HttpPost("loginUser")]
        // [ProducesResponseType(typeof(Response), 200)]
        // public async Task<Response> checkLogin([FromBody] userLogin userlogin)
        // {
        //     Response response = new Response();
        //     isAvailableResponse isAvailableresponse = new isAvailableResponse();
        //     /*var userInDatabase = await _context.users.FirstOrDefaultAsync(u => u.mobileNumber == userlogin.Username && u.Password == userlogin.Password);*/
        //     //var user = _context.FirstOrDefault(u => u.mobileNumber == userlogin.mobileNumber && u.password == userlogin.password);
        //     //userLoginforQuery selectQuery = new userLoginforQuery();
        //     var sql = "SELECT * FROM auto_stand.auto_details WHERE (mobile_number = '" + userlogin.mobileNumber + "',password = '" + userlogin.password + "')";
        //     Console.WriteLine(sql);
        //     if (sql == null)
        //     {
        //         response.status = 404;
        //         response.Message = "Not found";
        //     }
        //     else
        //     {
        //         isAvailableresponse.mobileNumber = userlogin.mobileNumber;
        //         isAvailableresponse.isAvailable = "Yes";
        //         response.status = 200;
        //         response.Message = "Success";
        //     }
        //     _.checkin(isAvailableresponse);
        //     return response;
        // }
        [HttpGet("getTiming")]
        public async Task<IActionResult> GetautoTiming()
        {
            try
            {
                var autotime = await _autoRepo.GetAutoTimings();
                Console.WriteLine("autotime");
                Console.WriteLine(autotime);
                return Ok(autotime);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("getcurrentstate")]
        public async Task<IActionResult> GetautoCurrent()
        {
            try
            {
                var autocurrent = await _autoRepo.GetCurrentStates();
                return Ok(autocurrent);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("getautoCollection")]
        public async Task<IActionResult> GetautoCollection()
        {
            try
            {
                var autocollection = await _autoRepo.GetRideCollections();
                return Ok(autocollection);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("getrideCount")]
        public async Task<IActionResult> GetRideCount()
        {
            try
            {
                var autocollection = await _autoRepo.GetRideCounts();
                return Ok(autocollection);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("destinationId")]
        public async Task<IActionResult> Getnowavailable()
        {
            try
            {
                var nowavail = await _autoRepo.GetNowisavailable();
                return Ok(nowavail);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

    }
}