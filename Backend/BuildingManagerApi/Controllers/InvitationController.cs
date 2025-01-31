using Microsoft.AspNetCore.Mvc;
using BuildingManagerILogic;
using BuildingManagerModels.Inner;
using BuildingManagerModels.Outer;
using BuildingManagerDomain.Enums;
using BuildingManagerApi.Filters;

namespace BuildingManagerApi.Controllers
{
    [ApiController]
    [Route("api/invitations")]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationLogic _invitationLogic;

        public InvitationController(IInvitationLogic invitationLogic)
        {
            _invitationLogic = invitationLogic;
        }

        [HttpPost]
        [AuthenticationFilter(RoleType.ADMIN)]
        public IActionResult CreateInvitation([FromBody] CreateInvitationRequest invitationRequest)
        {
            InvitationResponse createInvitationResponse = new(_invitationLogic.CreateInvitation(invitationRequest.ToEntity()));
            return CreatedAtAction(nameof(CreateInvitation), createInvitationResponse);
        }

        [HttpDelete("{id}")]
        [AuthenticationFilter(RoleType.ADMIN)]
        public IActionResult DeleteInvitation([FromRoute] Guid id)
        {
            InvitationResponse deleteInvitationResponse = new(_invitationLogic.DeleteInvitation(id));
            return Ok(deleteInvitationResponse);
        }

        [HttpPut("{id}")]
        [AuthenticationFilter(RoleType.ADMIN)]
        public IActionResult ModifyInvitation([FromRoute] Guid id, [FromBody] ModifyInvitationRequest invitationRequest)
        {
            InvitationResponse modifyInvitationResponse = new(_invitationLogic.ModifyInvitation(id, invitationRequest.NewDeadline));
            return Ok(modifyInvitationResponse);
        }

        [HttpGet]
        public IActionResult GetAllInvitations([FromQuery] string? email, [FromQuery] bool? expiredOrNear, [FromQuery] int? status)
        {
            ListInvitationsResponse listInvitationsResponse = new(_invitationLogic.GetAllInvitations(email, expiredOrNear, status));
            return Ok(listInvitationsResponse);
        }

        [HttpPost("{id}/response")]
        public IActionResult RespondInvitation([FromRoute] Guid id, [FromBody] RespondInvitationRequest respondInvitationRequest)
        {
            RespondInvitationResponse acceptInvitationResponse = new RespondInvitationResponse(_invitationLogic.RespondInvitation(respondInvitationRequest.ToEntity(id)));
            return Ok(acceptInvitationResponse);
        }
    }
}