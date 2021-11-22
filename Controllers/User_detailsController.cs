using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminTemplate.Models;

namespace AdminTemplate.Controllers
{
    public class User_detailsController : Controller
    {
        private UserTestEntities2 db = new UserTestEntities2();

        public ActionResult Index()
        {
            return View(db.user_details.ToList());
        }
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                user_details user_details = db.user_details.Find(id);
                if (user_details == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.Message = String.Format("Please wait..");
                    return View(user_details);
                }
            }
            catch(Exception er)
            {
                return View("Error");
            }
            finally
            {
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,User_Name,Password,Email,Contact_No,Login_Date")] user_details user_details)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.user_details.Add(user_details);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = String.Format("Please wait..");
                    return View(user_details);
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
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                user_details user_details = db.user_details.Find(id);
                if (user_details == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.Message = String.Format("Please wait..");
                    return View(user_details);
                }
            }
            catch (Exception er)
            {
                return View("Error");
            }
            finally
            {
            }
           // return View(user_details);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,User_Name,Password,Email,Contact_No,Login_Date")] user_details user_details)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user_details).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            
                else
            {
                ViewBag.Message = String.Format("Please wait..");
                return View(user_details);
            }
        }
            catch(Exception er)
            {
                return View("Error");
    }
            finally
            {
            }
        }
        public ActionResult Delete(int? id)
        {
            try
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                user_details user_details = db.user_details.Find(id);
                if (user_details == null)
                {
                    return HttpNotFound();
                }
                else
               {
                ViewBag.Message = String.Format("Please wait..");
                return View(user_details);
               }
            }
            catch(Exception er)
            {
                return View("Error");
             }
            finally
            {
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                user_details user_details = db.user_details.Find(id);
                db.user_details.Remove(user_details);
                db.SaveChanges();
            }
            catch (Exception er)
            {
                return View("Error");
            }
            finally
            {

            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
