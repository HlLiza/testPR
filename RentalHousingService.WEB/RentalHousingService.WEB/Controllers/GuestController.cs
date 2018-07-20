using AutoMapper;
using RentalHousingService.BLL.DTO;
using RentalHousingService.BLL.Interfaces;
using RentalHousingService.BLL.Services;
using RentalHousingService.WEB.Helpers;
using RentalHousingService.WEB.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace RentalHousingService.WEB.Controllers
{
    public class GuestController : Controller
    {
        private IUserService _userService;

        public GuestController(UserService userService)
        {
            _userService = userService;
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = await _userService.FindUserByLogin(model.Name);
                if (user == null && model.Password == model.ConfirmPassword)
                {

                    //create new entity
                    UserDTO entity = Mapper.Map<RegisterViewModel, UserDTO>(model);

                    entity.Salt = Guid.NewGuid().ToString();
                    entity.PasswordHash = UserHelper.CreatePasswordHash(model.Password, entity.Salt, Properties.Settings.Default.StaticSalt);

                    int? res = await _userService.Add(entity);
                    if (res > 0)
                    {
                        user = await _userService.FindUserByLogin(entity.Login);
                        if (user != null)
                        {
                            FormsAuthentication.SetAuthCookie(model.Name, true);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User with such login already exists");
            }
            return View(model);
        }


        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.FindUserByLogin(model.Email);
                if (user == null )
                {
                    return View("ForgotPasswordConfirmation");
                }
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account",
                    new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Сброс пароля",
                    "Для сброса пароля, перейдите по ссылке <a href=\"" + callbackUrl + "\">сбросить</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }
            return View(model);
        }


    }
}