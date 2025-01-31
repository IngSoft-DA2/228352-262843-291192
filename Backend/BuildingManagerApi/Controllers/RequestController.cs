using Microsoft.AspNetCore.Mvc;
using BuildingManagerModels.Outer;
using BuildingManagerILogic;
using BuildingManagerModels.Inner;
using BuildingManagerApi.Filters;
using BuildingManagerDomain.Enums;
using BuildingManagerLogic;

namespace BuildingManagerApi.Controllers
{
    [ApiController]
    [Route("api/requests")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestLogic _requestLogic;

        public RequestController(IRequestLogic requestLogic)
        {
            _requestLogic = requestLogic;
        }

        [HttpPost]
        [AuthenticationFilter(RoleType.MANAGER)]
        public IActionResult CreateRequest([FromBody] CreateRequestRequest requestRequest, [FromHeader(Name = "Authorization")] Guid managerSessionToken)
        {
            RequestResponse createRequestResponse = new(_requestLogic.CreateRequest(requestRequest.ToEntity(), managerSessionToken));
            return CreatedAtAction(nameof(CreateRequest), createRequestResponse);
        }

        [HttpPut("{id}")]
        [AuthenticationFilter(RoleType.MANAGER)]
        public IActionResult AssignStaff([FromRoute] Guid id, [FromBody] Guid maintenanceStaffId)
        {
            RequestResponse updateRequestResponse = new(_requestLogic.AssignStaff(id, maintenanceStaffId));
            return Ok(updateRequestResponse);
        }

        [HttpPut("{id}/attendance")]
        [AuthenticationFilter(RoleType.MAINTENANCE)]
        public IActionResult AttendRequest([FromRoute] Guid id, [FromHeader(Name = "Authorization")] Guid managerSessionToken)
        {
            RequestResponse updateRequestResponse = new(_requestLogic.AttendRequest(id, managerSessionToken));
            return Ok(updateRequestResponse);
        }

        [HttpPut("{id}/completed")]
        [AuthenticationFilter(RoleType.MAINTENANCE)]
        public IActionResult CompleteRequest([FromRoute] Guid id, [FromBody] int cost)
        {
            RequestResponse updateRequestResponse = new(_requestLogic.CompleteRequest(id, cost));
            return Ok(updateRequestResponse);
        }

        [HttpGet]
        [Route("assigned")]
        [AuthenticationFilter(RoleType.MAINTENANCE)]
        public IActionResult GetAssignedRequests([FromHeader(Name = "Authorization")] Guid managerSessionToken)
        {
            ListRequestResponse assignedRequests = new(_requestLogic.GetAssignedRequests(managerSessionToken));
            return Ok(assignedRequests);
        }

        [HttpGet]
        [Route("manager")]
        [AuthenticationFilter(RoleType.MANAGER)]
        public IActionResult GetRequestsByManager([FromHeader(Name = "Authorization")] Guid managerSessionToken, [FromQuery] string? category)
        {
            ListRequestResponse requestsByManager = new(_requestLogic.GetRequestsByManager(managerSessionToken, category));
            return Ok(requestsByManager);
        }
    }
}