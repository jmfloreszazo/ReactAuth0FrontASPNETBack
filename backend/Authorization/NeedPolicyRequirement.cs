using Microsoft.AspNetCore.Authorization;

namespace Auth0Backend.Authorization
{
    public class NeedPolicyRequirement:IAuthorizationRequirement
    {
        public NeedPolicyRequirement()
        {
        }
    }
}
