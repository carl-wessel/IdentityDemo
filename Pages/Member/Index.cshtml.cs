using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityDemo.Pages.Member
{
	public class IndexModel(SignInManager<IdentityUser> signInManager) : PageModel
	{
		private readonly SignInManager<IdentityUser> _signInManager = signInManager;

		public async Task<IActionResult> OnPost()
		{
			await _signInManager.SignOutAsync();
			return RedirectToPage("/Index"); // Redirect to home page after sign out
		}
	}
}
