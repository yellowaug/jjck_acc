using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ManagerPro.Models;
using System.Net;
using System.Data;
using ManagerPro.ViewModel;
using ManagerPro.BusinessLayer;
using System.Web.Security;


namespace ManagerPro.Controllers
{
    public class VhostAccountController : Controller
    {
        private Account Accountdb = new Account();
        [HttpPost]
        public ActionResult Dologin(UserDetails user)//这个是登录的功能
        {
            IsValidUser loginuser = new IsValidUser();
            if (loginuser.IsUser(user))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "VhostAccount");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "用户或密码错误");
                return View();
            }
        }
        public ActionResult Logout()//这个是登出的功能
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authentication");
        }
        // GET: VhostAccount
        [Authorize]
        public ActionResult Index(string sortOrder, string serachString, string currentFilter, int? page)
        {
            //添加排序和搜索功能
            //ShowUser showuser = new ShowUser(); 这个可以不用
            ViewBag.LoginUserName = User.Identity.Name;//在页面显示登录用户
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
            var Acclist = from e in Accountdb.hostAccounts
                          select e;
            if (!String.IsNullOrEmpty(serachString)) //这个是搜索功能
            {
                Acclist = Acclist.Where(e => e.HostName.Contains(serachString) || e.HostAddress.Contains(serachString));
            }
            switch (sortOrder)
            {
                case "site_desc":
                    Acclist = Acclist.OrderByDescending(e => e.HostName);
                    break;
                default:
                    Acclist = Acclist.OrderBy(e => e.HostName);
                    break;
            }
            int pageSize = 20; //这个是分页的功能
            int pageNumber = (page ?? 1);
            //var Acclist = Accountdb.weblist.ToList();
            return View(Acclist.ToPagedList(pageNumber, pageSize));
        }

        // GET: VhostAccount/Details/5
        public ActionResult Details(int?id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var Vhost = Accountdb.hostAccounts.Find(id);
            if (Vhost == null)
                return HttpNotFound();
            return View(Vhost);
        }

        // GET: VhostAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VhostAccount/Create
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="HostName,HostAddress,HostAccountNum,HostAccountPas,InputDate,HostNote")]HostAccount hostAccount)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    Accountdb.hostAccounts.Add(hostAccount);
                    Accountdb.SaveChanges();
                    return RedirectToAction("Index");
                }             
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "数据添加失败，请联系管理员");
            }
            return View(hostAccount);
        }

        // GET: VhostAccount/Edit/5
        public ActionResult Edit(int?id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var vhost = Accountdb.hostAccounts.Find(id);
            if (vhost == null)
                return HttpNotFound();
            return View(vhost);
        }

        // POST: VhostAccount/Edit/5
        [HttpPost,ActionName("Edit")]
        public ActionResult EditPost(int?id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var vhostupdata = Accountdb.hostAccounts.Find(id);
            if(TryUpdateModel(vhostupdata,"",new string[] { "HostName","HostAddress","HostAccountNum","HostAccountPas","InputDate","HostNote" }))
            try
            {
                    // TODO: Add update logic here
                Accountdb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(DataException)
            {
                    ModelState.AddModelError("", "数据编辑失败，请联系管理员");
            }
            return View(vhostupdata);
        }

        // GET: VhostAccount/Delete/5
        public ActionResult Delete(int?id,bool?saveChangesError=false)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "删除失败，请重试货联系管理员";
            var vhostdelete = Accountdb.hostAccounts.Find(id);
            if (vhostdelete == null)
                return HttpNotFound();
            return View(vhostdelete);
        }

        // POST: VhostAccount/Delete/5
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            try
            {
                // TODO: Add delete logic here
                var vhostdelete = Accountdb.hostAccounts.Find(id);
                Accountdb.hostAccounts.Remove(vhostdelete);
                Accountdb.SaveChanges();
               
            }
            catch(DataException)
            {

                return RedirectToAction("Delete", new { id = id, savesaveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Accountdb.Dispose();
            base.Dispose(disposing);
        }

    }
}
