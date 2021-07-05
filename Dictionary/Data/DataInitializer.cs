using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Dictionary.Data
{
    public class DataInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeRoles()
        {
            if (await _roleManager.FindByNameAsync(Constants.AdminRoleName) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName));
            }
        }

        public async Task InitializeAdminUser()
        {
            var adminEmail = "admin@gmail.com";
            var password = "_Aa123456789";
            if (await _userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new IdentityUser { Email = adminEmail, UserName = adminEmail };
                var result = await _userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, Constants.AdminRoleName);
                }
            }
        }
    }
}
