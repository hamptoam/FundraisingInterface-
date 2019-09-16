using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Fundraising_Capstone2.API;
using Fundraising_Capstone2.Keys;
using Fundraising_Capstone2.Models;
using Twilio;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Twilio.TwiML.Voice;
using Twilio.Rest.Api.V2010.Account;

namespace Fundraising_Capstone2.Controllers
{
    public class PhonesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Callee Callee { get; set; }

        public Funds Funds { get; set; }

        public Campaign Campaign { get; set; }

        public CalleeFunds CalleeFunds { get; set; }

        public CalleeCampaign CalleeCampaign { get; set; }


        // GET: Phones
        public ActionResult Index() //get
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                try
                {
                    var callees = db.Callees.ToList();

                    return View(callees);
                }
                catch
                {
                    return View();
                }
            }
        }
        // GET: Phones/Details/5
        public ActionResult Details(int? CalleeId)
        {
            if (CalleeId == null)
            {
                return new Twilio.AspNet.Mvc.HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Callee callee = db.Callees
                .Include("CalleeCampaign").Select(cp => cp)
                .Include("CalleeFunds").Select(fu => fu)
                .FirstOrDefault(co => co.CalleeId == CalleeId);

                if (Callee == null)
                {
                    return HttpNotFound();
                }
                return View(callee);
            }
        }

        // GET: Phones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Phones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Callee callee)
        {
            if (ModelState.IsValid)
            {
                db.Callees.Add(callee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(callee);
        }
        // GET: Phones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new Twilio.AspNet.Mvc.HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }
        // POST: Phones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Callee callee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(callee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(callee);
        }
        // GET: Phones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new Twilio.AspNet.Mvc.HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Callee callee = db.Callees.Find(id);
            if (callee == null)
            {
                return HttpNotFound();
            }
            return View(callee);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Callee callee = db.Callees.Find(id);
            db.Callees.Remove(callee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Dial(string to)
        {
            TwilioWrapperClient test = new TwilioWrapperClient(APIKeys.SID, APIKeys.AuthToken);
            test.CallAsync("414-310-7982", this.Callee.phoneNumber, "Goodbye");


            return View();

        }
   
        [HttpGet]
        public ActionResult Text()
        {
            TwilioWrapperClient sms = new TwilioWrapperClient(APIKeys.SID, APIKeys.AuthToken);

            Console.WriteLine("Endter text here");
            string employeeInput = Console.ReadLine();

            sms.SendSmsAsync("414-310-7982", this.Callee.phoneNumber, employeeInput);

            return View();
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
       
    

