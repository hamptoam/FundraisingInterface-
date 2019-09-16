﻿using System;
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

            var calleeList = db.Callees.ToList();

            foreach (Callee c in calleeList)
            {
                test.CallAsync("414-310-7982", c.phoneNumber, "Test");
            }

            return View();

        }

        [HttpGet]
        public ActionResult Text()
        {

            Console.WriteLine("Enter text here");
            string body = Console.ReadLine();

            TwilioClient.Init(APIKeys.sID, APIKeys.authToken);

            var message = MessageResource.Create(
                body: "",
                from: new Twilio.Types.PhoneNumber("+14143107982"),
                to: new Twilio.Types.PhoneNumber(this.Callee.phoneNumber)
            ); ;

            Console.WriteLine(message.Sid);

            return View();
        }

        //static void Main(string[] args)
        //{
        //    // Find your Account Sid and Token at twilio.com/console
        //    // DANGER! This is insecure. See http://twil.io/secure
        //    const string accountSid = "ACad990750b705f73b388ec579ef0a82ba";
        //    const string authToken = "your_auth_token";

        //    TwilioClient.Init(accountSid, authToken);

        //    var message = MessageResource.Create(
        //        body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
        //        from: new Twilio.Types.PhoneNumber("+15017122661"),
        //        to: new Twilio.Types.PhoneNumber("+15558675310")
        //    );

        //    Console.WriteLine(message.Sid);

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
       
    

