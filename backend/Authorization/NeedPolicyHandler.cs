using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Auth0Backend.Authorization;

public class NeedPolicyHandler : AuthorizationHandler<NeedPolicyRequirement>
{
    public NeedPolicyHandler(IHttpContextAccessor httpContextAccessor)
    {
        _ = httpContextAccessor;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        NeedPolicyRequirement requirement)
    {
        if (context.User.Identity != null && !context.User.Identity.IsAuthenticated)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}