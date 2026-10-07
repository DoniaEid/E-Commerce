using E_Commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser>userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

            [HttpGet]
            public IActionResult Login()
            {
                return View(new UserViewLogin());
            }
            [HttpGet]
            public IActionResult Register()
            {
                return View(new UserViewModel());
            }
           [HttpPost]
            public async Task<IActionResult> Register(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser u = new ApplicationUser();
                u.Email = user.Email;
                u.UserName = $"{user.First_Name}_{user.Last_Name}";
                u.PasswordHash = user.password;
                u.PhoneNumber = user.PhoneNumber;
                u.Address = user.Address;
                var s = await userManager.CreateAsync(u, user.password);
                if (s.Succeeded)
                {
                    UserViewLogin loginUser = new UserViewLogin();
                    loginUser.Email = user.Email;
                    loginUser.password = user.password;
                    return View("Login", loginUser);

                }
                else
                {

                    foreach (var error in s.Errors)
                    {
                        if (error.Code.Contains("Password"))
                            ModelState.AddModelError(nameof(user.password), error.Description);

                        else if (error.Code.Contains("Email"))
                            ModelState.AddModelError(nameof(user.Email), error.Description);

                        else if (error.Code.Contains("PhoneNumber"))
                            ModelState.AddModelError(nameof(user.PhoneNumber), error.Description);

                        else if (error.Code.Contains("Address"))
                            ModelState.AddModelError(nameof(user.Address), error.Description);
                        else
                            ModelState.AddModelError("", error.Description);
                    }
                }
                return View("Register", user);

            }
            else
            {
                return View("Register", user);
            }
        
        }

            [HttpPost]
            public async Task<IActionResult> Login(UserViewLogin user)
            {
                ApplicationUser u = new ApplicationUser();

                if (ModelState.IsValid)
                {
                    var userbyemail = await userManager.FindByEmailAsync(user.Email);

                    if (userbyemail != null)
                    {
                        var result = await signInManager.CheckPasswordSignInAsync(
                            userbyemail,
                            user.password,
                            false
                        );

                        if (result.Succeeded)
                        {
                            u = userbyemail;
                          List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim(ClaimTypes.MobilePhone, u.PhoneNumber));
                        Claims.Add(new Claim(ClaimTypes.StreetAddress, u.Address));

                        await signInManager.SignInWithClaimsAsync(u,false,Claims);

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(nameof(user.password), "Wrong password");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email not found");
                    }
                }

                return View("Login", user);
            }

            [HttpGet]
            public async Task<IActionResult> SignOutUser()
            {
                await signInManager.SignOutAsync();

                return RedirectToAction("Index", "Home");
            }

            [HttpGet]
            public  IActionResult ShowProfile()
            {
                return View("Profile");
            }

        [HttpPost]
        public async Task<IActionResult> EditProfileUser(ProfileViewModel user)
        {
            if (ModelState.IsValid)
            {
                var u = await userManager.FindByIdAsync(
                    User.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                        .Value
                );

                u.Address = user.Address;
                u.PhoneNumber = user.PhoneNumber;
                u.Email = user.Email;

                string userName = $"{user.First_Name}_{user.Last_Name}";

                var result = await userManager.SetUserNameAsync(u, userName);

                if (result.Succeeded)
                {
                    await userManager.UpdateAsync(u);

                    await signInManager.RefreshSignInAsync(u);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    if (error.Code.Contains("UserName"))
                        ModelState.AddModelError("", error.Description);

                    else if (error.Code.Contains("Email"))
                        ModelState.AddModelError(nameof(user.Email), error.Description);

                    else
                        ModelState.AddModelError("", error.Description);
                }
            }

            return View("Profile");
        }
    }
}
