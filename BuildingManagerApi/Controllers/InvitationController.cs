using Microsoft.AspNetCore.Mvc;
using BuildingManagerILogic;
using BuildingManagerModels.Inner;
using BuildingManagerModels.Outer;
using BuildingManagerDomain.Enums;
using ECommerceApi.Filters;
using BuildingManagerLogic;

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
            CreateInvitationResponse createInvitationResponse = new (_invitationLogic.CreateInvitation(invitationRequest.ToEntity()));
            return CreatedAtAction(nameof(CreateInvitation), createInvitationResponse);
        }
    }
}