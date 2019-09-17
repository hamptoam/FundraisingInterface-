using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fundraising_Capstone2.Models;

namespace Fundraising_Capstone2.Controllers
{
    public class CalleesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Callees
        public ActionResult Index()
        {
            return View(db.Callees.ToList());
        }

        // GET: Callees/Details/5
        public ActionResult Details(int? CalleeId)
        {
            if (CalleeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Callee callee = db.Callees
                .Include("CalleeCampaign").Select(cp => cp)
                .Include("CalleeFunds").Select(fu => fu)
                .FirstOrDefault(co => co.CalleeId == CalleeId);

                if (callee == null)
                {
                    return HttpNotFound();
                }
                return View(callee);
            }
        }

        // GET: Callees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Callees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "phoneNumber,firstName,lastName,Address,City,zipCode")] Callee callee)
        {
            if (ModelState.IsValid)
            {
                db.Callees.Add(callee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(callee);
        }

        // GET: Callees/Edit/5
        public ActionResult Edit(int? CalleeId)
        {
            if (CalleeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Callee callee = db.Callees.Find(CalleeId);
            if (callee == null)
            {
                return HttpNotFound();
            }
            return View(callee);
        }

        // POST: Callees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "phoneNumber,firstName,lastName,Address,City,zipCode,isInterested,dayToCall,timeToCall")] Callee callee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(callee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(callee);
        }

        // GET: Callees/Delete/5
        public ActionResult Delete(int? CalleeId)
        {
            if (CalleeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Callee callee = db.Callees.Find(CalleeId);
            if (callee == null)
            {
                return HttpNotFound();
            }
            return View(callee);
        }

        // POST: Callees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ? CalleeId)
        {
            Callee callee = db.Callees.Find(CalleeId);
            db.Callees.Remove(callee);
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
