using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagerPro.Models;
using PagedList;

namespace ManagerPro.Controllers
{
    public class AccountManagerController : Controller

    {
        private Account Accountdb = new Account();
        // GET: AccountManager
        public ActionResult Index(string sortOrder,string serachString,string currentFilter,int?page)
        {
            //添加排序和搜索功能
            ViewBag.CurrentSort = sortOrder;
            ViewBag.WebsiteSort = String.IsNullOrEmpty(sortOrder) ? "site_desc" : ""; //这个是排序功能
            if (serachString != null) //这个是分页的功能
            {
                page = 1;
            }
            else
            {
                serachString = currentFilter;
            }
            ViewBag.CurrentFilter = serachString;
            var Acclist = from e in Accountdb.weblist                          
                          select e;
            if (!String.IsNullOrEmpty(serachString)) //这个是搜索功能
            {
                Acclist = Acclist.Where(e => e.Website.Contains(serachString)|| e.Note.Contains(serachString));
            }
            switch (sortOrder)
            {
                case "site_desc":
                    Acclist = Acclist.OrderByDescending(e => e.Website);
                    break;
                default:
                    Acclist = Acclist.OrderBy(e => e.Website);
                    break;
            }
            int pageSize = 20; //这个是分页的功能
            int pageNumber = (page ?? 1);
            //var Acclist = Accountdb.weblist.ToList();
            return View(Acclist.ToPagedList(pageNumber,pageSize));
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
            WebList webList = Accountdb.weblist.Find(id);
            return this.View(webList);
        }

        // POST: AccountManager/Edit/5
        [HttpPost]
        public ActionResult Edit(WebList webLists)
        {
            try
            {
                // TODO: Add update logic here
                Accountdb.Entry(webLists).State = System.Data.Entity.EntityState.Modified;
                Accountdb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(webLists);
            }
        }

        // GET: AccountManager/Delete/5
        public ActionResult Delete(int id)
        {
            AccountList accounts = Accountdb.accountlist.Find(id);
            return View(accounts);
        }
        public ActionResult DeleteWebsite(int id)
        {
            WebList webs = Accountdb.weblist.Find(id);
            return View(webs);
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
        [HttpPost,ActionName("DeleteWebsite")]
        public ActionResult DeleteWebsite(int id,FormCollection collection)
        {
            try
            {
                WebList webs = Accountdb.weblist.Find(id);
                Accountdb.weblist.Remove(webs);
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
