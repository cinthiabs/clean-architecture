using CleanArchitectureMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureMvc.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private UserManager<ApplicationUser> _userManage;
        private SignInManager<ApplicationUser> _signInManager;
        public AuthenticateService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManage = userManager;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var application = new ApplicationUser
            {
                UserName = email,
                Email = email
            };
            var result = await _userManage.CreateAsync(application, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(application, isPersistent: false);
            }
            return result.Succeeded;
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
