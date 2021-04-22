using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Marketplace.Models;
namespace Marketplace.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.AdministratorRole.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.InstructorRole.ToString()));
        }
    }
    public enum Roles
    {
        AdministratorRole,
        InstructorRole
    }
}