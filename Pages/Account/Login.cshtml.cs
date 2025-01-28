using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityDemo.Pages.Account
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public string? Username { get; set; }
        public string? Password { get; set; }

        public LoginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {

            IdentityUser userToLogIn = await _userManager.FindByNameAsync(Username);

            if (userToLogIn != null)
            {
                // F�rsta false �r remember me checkbox, "Vill du fortfarande vara inloggad?" Andra false �r lockout
                var signInResult = await _signInManager.PasswordSignInAsync(userToLogIn, Password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToPage("/Member/Index");
                }
            }

            return Page();
        }
    }
}
