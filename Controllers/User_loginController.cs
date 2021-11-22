using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AdminTemplate;
using AdminTemplate.Models;

namespace AdminTemplate.Controllers
{
    
    public class User_loginController : Controller
    {
        private UserTestEntities2 db = new UserTestEntities2();
        public ActionResult Index()
        {
            if (Session["user_name"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [HandleError(ExceptionType =typeof(InvalidOperationException))]
        public ActionResult Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserTestEntities2 db = new UserTestEntities2();
                    var user = (from Login in db.Logins
                                where Login.Email == login.Email && Login.Password == login.Password
                                select new
                                {
                                    Login.Email,
                                    Login.Password
                                }).ToList();
                    if (user.FirstOrDefault() != null)
                    {
                        Session["user_name"] = user.FirstOrDefault().Email;
                        return Redirect("/User_details/Index");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid login credentials !";
                        return View();
                    }

                }
                else
                {
                    return View("Login", login);
                }
            }
            catch (Exception er)
            {
                return View("Error");
            }
            finally
            {
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [HandleError(ExceptionType = typeof(InvalidOperationException))]
        public ActionResult Register(Login registerDetails)
        {
            if (ModelState.IsValid)
            {
                using (var databaseContext = new UserTestEntities2())
                {
                    Login reglog = new Login();
                    reglog.Email = registerDetails.Email;
                    reglog.Password = registerDetails.Password;
                    databaseContext.Logins.Add(reglog);
                    databaseContext.SaveChanges();
                }
                ViewBag.Message = "User Details Saved !";
                return View();
            }
            else
            {
                return View("Register", registerDetails);
            }
        }
        [OutputCache(NoStore = true, Duration = 0)]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session["user_name"] = null;
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Session.Clear();
            return RedirectToAction("Login", "User_login");
        }
    }
}
