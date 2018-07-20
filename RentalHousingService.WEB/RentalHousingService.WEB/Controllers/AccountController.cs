using RentalHousingService.BLL.DTO;
using RentalHousingService.BLL.Interfaces;
using RentalHousingService.BLL.Services;
using RentalHousingService.WEB.Helpers;
using RentalHousingService.WEB.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace RentalHousingService.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = await _userService.FindUserByLogin(model.Name);

                if (user != null && user.PasswordHash == UserHelper.CreatePasswordHash(model.Password, user.Salt, Properties.Settings.Default.StaticSalt))
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User with such login and password is not present");
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}