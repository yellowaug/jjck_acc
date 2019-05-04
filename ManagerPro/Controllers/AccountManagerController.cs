using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagerPro.Models;

namespace ManagerPro.Controllers
{
    public class AccountManagerController : Controller

    {
        private Account Accountdb = new Account();
        // GET: AccountManager
        public ActionResult Index()
        {
            //var Acclist = from e in Accountdb.weblist
            //              orderby e.ID
            //              select e;
            var Acclist = Accountdb.weblist.ToList();
            return View(Acclist);
        }

        // GET: AccountManager/Details/5
        public ActionResult Details(int id)
        {
            AccountList accounts = Accountdb.accountlist.Find(id);
            return View(accounts);
        }

        // GET: AccountManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountManager/Create
        [HttpPost]
        public ActionResult Create(WebList webs)
        {
            try
            {
                // TODO: Add insert logic here
                Accountdb.weblist.Add(webs);
                Accountdb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountManager/Delete/5
        public ActionResult Delete(int id)
        {
            AccountList accounts = Accountdb.accountlist.Find(id);
            return View(accounts);
        }

        // POST: AccountManager/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                AccountList accounts = Accountdb.accountlist.Find(id);
                Accountdb.accountlist.Remove(accounts);
                Accountdb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
