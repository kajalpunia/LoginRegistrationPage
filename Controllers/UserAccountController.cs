using System.Security.Claims;
using Azure.Identity;
using Login_registration_page.Entities;
using Login_registration_page.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Login_registration_page.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly AppDbContext _context;
        public UserAccountController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserAccount account = new UserAccount();
                account.email= model.email;
                account.password= model.password;
                account.firstName= model.firstName;
                account.lastName= model.lastName;
                account.userName= model.userName;
                try
                {
                    _context.Users.Add(account);
                    _context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = $"{account.firstName} {account.lastName} registered successfully. Please login to continue.";
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "This email already exists, either login to proceed or use another email to register.");
                    return View(model);
                }
                return View();
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user= _context.Users.Where(x => (x.userName == model.userNameorEmail || x.email == model.userNameorEmail) && x.password==model.password).FirstOrDefault();
                if (user != null)
                {
                    //Login successfull.
                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.email),
                        new Claim("Name", user.firstName + " " + user.lastName),
                        new Claim(ClaimTypes.Role, "User"),
                    };
                    var claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("SecurePage");
                }
                else 
                {
                    ModelState.AddModelError("","Invalid credentials.");
                }
                return View();
            }
            return View(model);
        }
        public IActionResult Logout() 
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult SecurePage()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
    }
}
