using System.Threading.Tasks;
using Marketplace.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Marketplace.Authorization{
    public class BidManagerAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, BidModel>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   BidModel resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // Managers can approve or reject.
            if (context.User.IsInRole("Lecturer"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
