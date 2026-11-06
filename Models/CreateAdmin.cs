using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Models
{
    public class CreateAdmin
    {
        RoleManager<IdentityRole> admin;
        UserManager<ApplicationUser> user;

        public CreateAdmin(RoleManager<IdentityRole> admin,UserManager<ApplicationUser>user)
        {
            this.admin = admin;
            this.user = user;
        }

        public async Task CreateAdmintoapplication(ApplicationUser u, string password)
        {
            var result = await user.CreateAsync(u, password);

            if (result.Succeeded)
            {
                if (!await admin.RoleExistsAsync("Admin"))
                {
                    IdentityRole role = new IdentityRole
                    {
                        Name = "Admin"
                    };

                    await admin.CreateAsync(role);
                }

                await user.AddToRoleAsync(u, "Admin");
            }
        }












    }
}
