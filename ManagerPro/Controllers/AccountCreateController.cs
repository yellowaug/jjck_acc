using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagerPro.Models;

namespace ManagerPro.Controllers
{
    public class AccountCreateController : Controller
    {
        // GET: AccountCreate
        // 实现选择框选择数据库已有内容的后端写法
        private Account Accountdb = new Account();
        public ActionResult Index()
        {
           // ViewData["Website"] = new SelectList(Accountdb.weblist, "ID", "Website");
            ViewData["AccountName"] = new SelectList(Accountdb.weblist, "ID", "Website");
            return View();
        }
        [HttpPost]
        public ActionResult Index(AccountList accounts)
        {
            if (ModelState.IsValid)
            {
                Accountdb.accountlist.Add(accounts);
                Accountdb.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["AccountName"] = new SelectList(Accountdb.weblist, "ID", "Website",accounts.AccountName);
            return View(accounts);
        }
        public ActionResult CreateUrl()
        {
            ViewData["WebSiteID"] = new SelectList(Accountdb.weblist, "ID", "Website");
            return View();
        }
        [HttpPost]
        public ActionResult CreateUrl(Urllist urllists)
        {
            if (ModelState.IsValid)
            {
                Accountdb.urllists.Add(urllists);
                Accountdb.SaveChanges();
                return RedirectToAction("CreateUrl");

            }
            ViewData["WebSiteID"] = new SelectList(Accountdb.weblist, "ID", "Website",urllists.WebSiteUrl);
            return View(urllists);
        }

    }
}