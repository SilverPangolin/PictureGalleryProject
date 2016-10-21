using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PictureGalleryProject.Models;
using System.Web.Security;

namespace PictureGalleryProject.Controllers
{
    public class UsersController : Controller
    {
        private PictureGalleryModel db = new PictureGalleryModel();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        //-----------------------------------------------------------------------------------------------------

        [HttpPost]
        public ActionResult LogIn(User userlogin)
        {
            //Checks if Username and password is valid
            if (IsValid(userlogin.UserName, userlogin.Password))
            {
                FormsAuthentication.SetAuthCookie(userlogin.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View(userlogin);
        }

        private bool IsValid(string username, string password)
        {
            ////Installed SimpleCrypto for complex hashing algorithms such as PBKDF2 for quick and simple usage.
            ////Installation method PowerShell (Tools -> NuGet Package Manager -> Package Manager Console -> Write: Install-Package SimpleCrypto -> OK -> Installed)
            //var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (var db = new PictureGalleryModel())
            {
                var UserInput = from u in db.Users
                                where username == UserName
                                        select cust;

                //var userinput = db.Users.FirstOrDefault(u => u.UserName == username);
                //if (userinput != null)
                {
                    if (UserInput.Password == password)
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //-----------------------------------------------------------------------------------------------------

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,FirstName,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,FirstName,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
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
