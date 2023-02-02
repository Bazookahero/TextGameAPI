using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TextGameAPI.Models.ViewModels;
using TextGameAPI.Data;
using TextGameAPI.Models;
using Microsoft.AspNetCore.Authorization;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TextGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly TextGameDbContext _textGameDbContext;

        public AccountController(
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        TextGameDbContext textGameDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _textGameDbContext = textGameDbContext;
        }

        [HttpGet]
        [EnableCors("AllowAll")]
        public IEnumerable<AppUser> Get()
        {
            return _textGameDbContext.Users.ToList();
        }


        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task Post(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid && viewModel.Password == viewModel.ConfirmPassword)
            {
                AppUser newUser = new AppUser
                {
                    BirthDate = viewModel.BirthDate,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    UserName = viewModel.UserName,
                    NormalizedUserName = viewModel.UserName.ToUpper(),
                    PasswordHash = viewModel.Password,
                };
                IdentityResult result = await _userManager.CreateAsync(newUser, newUser.PasswordHash);
                IdentityResult roleResult = await _userManager.AddToRoleAsync(newUser, "Member");
                if (result.Succeeded)
                    Console.WriteLine("success!");
            }

        }
        [HttpGet("{Logout}")]
        [EnableCors("AllowAll")]
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        [HttpPost("{Login}")]
        [EnableCors("AllowAll")]
        public async Task Login(LoginViewModel Login)
        {
            SignInResult signIn = await _signInManager.PasswordSignInAsync(Login.UserName, Login.Password, false, false);
            if (signIn.Succeeded)
            {
                Console.WriteLine(signIn.Succeeded.ToString());
            }
            else
            {
                Console.WriteLine("Login failed");
            }

        }
    }
}
