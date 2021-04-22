using Marketplace.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Marketplace.Authorization
{
    public class InstructorIsOwnerAuthorizationHandler 
                : AuthorizationHandler<OperationAuthorizationRequirement, BidModel>
    {
        UserManager<IdentityUser> _userManager;

        public InstructorIsOwnerAuthorizationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        } 

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   BidModel resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If not asking for CRUD permission, return.

            if (requirement.Name != "Create" &&
                requirement.Name != "Read"   &&
                requirement.Name != "Update" &&
                requirement.Name != "Delete" )
            {
                return Task.CompletedTask;
            }

            if (resource.InstructorBiddedId == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
