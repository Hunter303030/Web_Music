using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Security.Claims;
using Web_Music_v3.Data;
using Web_Music_v3.Models;
using Web_Music_v3.Models.Helper;
using Web_Music_v3.Services;

namespace Web_Music_v3.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _context;       

        public UserController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Auth()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Auth");
        }

        public IActionResult Select(User user)
        {
            if (user.Password != null || user.Login != null)
            {
                Hash hash = new Hash();
                var passwordHash = hash.GetHash(user.Password);
                var chechuser = _context.User.Where(l => l.Login == user.Login && l.Password == passwordHash).FirstOrDefault();

                if (chechuser != null)
                {
                    ClaimsIdentity identity;
                    bool isAuth = false;

                    if (chechuser.IsAdmin)
                    {
                        identity = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, chechuser.Login),
                            new Claim(ClaimTypes.NameIdentifier, Convert.ToString(chechuser.Id)),
                            new Claim(ClaimTypes.Role,"Admin")
                            }, CookieAuthenticationDefaults.AuthenticationScheme);
                        isAuth = true;
                    }
                    else
                    {
                        identity = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, chechuser.Login),
                            new Claim(ClaimTypes.NameIdentifier, Convert.ToString(chechuser.Id)),
                            new Claim(ClaimTypes.Role,"User")
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                        isAuth = true;
                    }

                    if (isAuth)
                    {
                        var principal = new ClaimsPrincipal(identity);
                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    }
                    return RedirectToAction("List", "Track");
                }
                else
                {
                    ModelState.AddModelError("error", "Неверный логин или пароль!");
                    return View("Auth");
                }
            }
            else
            {
                ModelState.AddModelError("error", "Неверный логин или пароль!");
                return View("Auth");
            }
        }

        public IActionResult CreateView() => View("Create");

        public IActionResult Create(User user)
        {
            var usercheck = _context.User.Where(l => l.Login == user.Login || l.Email == user.Email).FirstOrDefault();

            if (usercheck == null)
            {

                Hash hash = new Hash();
                var passwordHash = hash.GetHash(user.Password);

                User newuser = new User
                {
                    Login = user.Login,
                    Password = passwordHash,
                    Email = user.Email,
                    IsAdmin = false
                };
                _context.User.Add(newuser);
                _context.SaveChanges();
                return View("Auth");
            }
            else
            {
                ModelState.AddModelError("error", "Пользователь с таким логином или почтой уже существует!");
                return View("Create");
            }

        }

        public IActionResult Exit()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Auth", "User");
        }

        public IActionResult GetEmailView() => View("Recovery");

        int code_1;

        public async Task<IActionResult> EmailAsync(string email)
        {
            var userEmail = _context.User.Where(l => l.Email == email).FirstOrDefault();
            

            if (userEmail != null)
            {
                try
                {

                    Random r = new Random();
                    code_1 = r.Next(100000, 999999);

                    Code cod = new Code
                    {
                        Cod_1 = code_1,
                        Cod = 0
                    };

                    var _email = new MimeMessage();

                    _email.From.Add(new MailboxAddress("Web_Music", "druian.oleg@yandex.ru"));
                    _email.To.Add(new MailboxAddress("Уважаемый пользователь", $"{email}"));

                    _email.Subject = "Восстановление пароля";
                    _email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        Text = $"<b>Ваш код для сброса пароля: {code_1}</b>"
                    };

                    using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                    {
                        smtp.Connect("smtp.yandex.ru", 465, true);

                        smtp.Authenticate();

                        smtp.Send(_email);
                        smtp.Disconnect(true);
                    }

                    return View("CheakCod", cod);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", "Ошибка при отправки кода, попробуйте позже!");
                    return View("Recovery");
                }

            }
            else
            {
                ModelState.AddModelError("error", "Пользователя с такой почтой не существует!");
                return View("Recovery");
            }
        }

        public IActionResult CheakCod(Code code)
        {
            if(code.Cod_1 == code.Cod)
            {
                return View("ChengePassword");
            }
            else
            {
                ModelState.AddModelError("error", "Неверный код!");
                return View("CheakCod");
            }
        }

        public IActionResult CheangePassword(User user)
        {
            var usercheck = _context.User.Where(l => l.Login == user.Login).FirstOrDefault();

            if(usercheck != null)
            {
                Hash hash = new Hash();
                var passwordHash = hash.GetHash(user.Password);

                usercheck.Password = passwordHash;

                _context.Update(usercheck);
                _context.SaveChanges();
                return View("Auth");
            }
            else
            {
                ModelState.AddModelError("error", "Неверный логин!");
                return View("ChengePassword");
            }            
        }
    }
}
