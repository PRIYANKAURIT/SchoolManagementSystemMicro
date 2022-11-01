using Microsoft.AspNetCore.Mvc;
using StudentAdmissionManagementSystem.Models;
using StudentAdmissionManagementSystem.Repository.Interface;
using System.ComponentModel.Design;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAdmissionManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAdmissionController : ControllerBase
    {
        private readonly ILogger logger;
        public IStudentAdmissionManagement studentAdmissionManagement;

        public StudentAdmissionController(IConfiguration configuartion, ILoggerFactory loggerFactory, IStudentAdmissionManagement studentAdmissionManagement)
        {
            logger = loggerFactory.CreateLogger<StudentAdmissionController>();
            this.studentAdmissionManagement = studentAdmissionManagement;
        }

        // GET: api/<StudentAdmissionController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            BaseResponseStatus baseResponseStatus = new BaseResponseStatus();
            logger.LogDebug(string.Format($"GetCompanyBankAccountDetailsById-GetAll:Calling GetAll."));
            var Samm = await studentAdmissionManagement.GetAll();
            if (Samm.Count == 0)
            {
                baseResponseStatus.StatusCode = StatusCodes.Status404NotFound.ToString();
                baseResponseStatus.StatusMessage = "Data not found";
            }
            else
            {
                baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                baseResponseStatus.StatusMessage = "All Data feached Successfully";
                baseResponseStatus.ResponseData = Samm;
            }
            return Ok(baseResponseStatus);
        }

        // GET api/<StudentAdmissionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            BaseResponseStatus baseResponseStatus = new BaseResponseStatus();
            logger.LogDebug(string.Format($"GetCompanyBankAccountDetailsById-GetById:Calling GetById."));
            var bank = await studentAdmissionManagement.GetById(id);
            if (bank == null)
            {
                baseResponseStatus.StatusCode = StatusCodes.Status404NotFound.ToString();
                baseResponseStatus.StatusMessage = "Data not found";
            }
            else
            {
                baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                baseResponseStatus.StatusMessage = "All Data feached Successfully";
                baseResponseStatus.ResponseData = bank;
            }
            return Ok(baseResponseStatus);
        }

        // POST api/<StudentAdmissionController>
        [HttpPost]
        public async Task<IActionResult> Add(ADDStudentAdmissionDetailsModel studentAdmissionDetails)
        {
            BaseResponseStatus baseResponseStatus = new BaseResponseStatus();
            logger.LogDebug(String.Format($"StudentAdmissionController-Add:Calling By Add action."));
            if (studentAdmissionDetails != null)
            {
                var Execution = await studentAdmissionManagement.Add(studentAdmissionDetails);
                /*if (Execution == -1)
                {
                    var returnmsg = string.Format($"Record Is Already saved With ID{studentAdmissionDetails.StudentID}");
                    logger.LogDebug(returnmsg);
                    baseResponseStatus.StatusCode = StatusCodes.Status409Conflict.ToString();
                    baseResponseStatus.StatusMessage = returnmsg;
                    return Ok(baseResponseStatus);
                }*/
                if (Execution >= 1)
                {
                    var rtnmsg = string.Format("Record added successfully..");
                    logger.LogInformation(rtnmsg);
                    logger.LogDebug(string.Format("StudentAdmissionController-Add:Calling By Add action."));
                    baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                    baseResponseStatus.StatusMessage = rtnmsg;
                    baseResponseStatus.ResponseData = Execution;
                    return Ok(baseResponseStatus);
                }
                else
                {
                    var rtnmsg1 = string.Format("Error while Adding");
                    logger.LogError(rtnmsg1);
                    baseResponseStatus.StatusCode = StatusCodes.Status409Conflict.ToString();
                    baseResponseStatus.StatusMessage = rtnmsg1;
                    return Ok(baseResponseStatus);
                }

            }
            else
            {
                var returnmsg = string.Format("Record added successfully..");
                logger.LogDebug(returnmsg);
                baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                baseResponseStatus.StatusMessage = returnmsg;
                return Ok(baseResponseStatus);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(StudentAdmissionDetailsModel studentAdmissionDetails)
        {
            BaseResponseStatus baseResponseStatus = new BaseResponseStatus();
            logger.LogDebug(String.Format($"StudentAdmissionController-Update:Calling By Update action."));
            if (studentAdmissionDetails != null)
            {
                var Execution = await studentAdmissionManagement.Update(studentAdmissionDetails);
               /* if (Execution == -1)
                {
                    var returnmsg = string.Format($"Record Is Already saved With ID{studentAdmissionDetails.Id}");
                    logger.LogDebug(returnmsg);
                    baseResponseStatus.StatusCode = StatusCodes.Status409Conflict.ToString();
                    baseResponseStatus.StatusMessage = returnmsg;
                    return Ok(baseResponseStatus);
                }*/
                if (Execution >= 1)
                {
                    var rtnmsg = string.Format("Record update successfully..");
                    logger.LogInformation(rtnmsg);
                    logger.LogDebug(string.Format("CompanyBankAccountController-UpdateCompanyBankAccountDetails:Calling By UpdateCompanyBankAccountDetails action."));
                    baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                    baseResponseStatus.StatusMessage = rtnmsg;
                    baseResponseStatus.ResponseData = Execution;
                    return Ok(baseResponseStatus);
                }
                else
                {
                    var rtnmsg1 = string.Format("Error while Adding");
                    logger.LogError(rtnmsg1);
                    baseResponseStatus.StatusCode = StatusCodes.Status409Conflict.ToString();
                    baseResponseStatus.StatusMessage = rtnmsg1;
                    return Ok(baseResponseStatus);
                }

            }
            else
            {
                var returnmsg = string.Format("Record added successfully..");
                logger.LogDebug(returnmsg);
                baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                baseResponseStatus.StatusMessage = returnmsg;
                return Ok(baseResponseStatus);
            }
        }

        // DELETE api/<StudentAdmissionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            BaseResponseStatus baseResponse = new BaseResponseStatus();
            logger.LogDebug(string.Format($"StudentAdmissionController-DeleteById : Calling DeleteById action with Id {id}"));

            var Execution = await studentAdmissionManagement.DeleteById(id);
            if (Execution == 0)
            {
                var retunmsg = string.Format($"Record with Id {id} not found");
                logger.LogDebug(retunmsg);
                baseResponse.StatusCode = StatusCodes.Status404NotFound.ToString();
                baseResponse.StatusMessage = retunmsg;
                return Ok(baseResponse);
            }
            else
            {
                var rtnmsg = string.Format($"Record with Id {id} is deleted!");
                logger.LogDebug(rtnmsg);
                baseResponse.StatusCode = StatusCodes.Status200OK.ToString();
                baseResponse.StatusMessage = rtnmsg;
                baseResponse.ResponseData = Execution;
                return Ok(baseResponse);
            }
        }
    }
}
