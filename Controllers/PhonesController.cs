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

namespace Fundraising_Capstone2.Controllers
{
    public class PhonesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public object Callee { get; private set; }

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
        public ActionResult Details(int? id)
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
        public ActionResult Create([Bind(Include = "Id")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Phones.Add(phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phone);
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
        public ActionResult Edit([Bind(Include = "Id")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phone);
        }

        // GET: Phones/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phone phone = db.Phones.Find(id);
            db.Phones.Remove(phone);
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
           var texteeList = db.Callees.ToList(); 

           foreach (Callee c in texteeList)
           {
                TwilioWrapperClient test = new TwilioWrapperClient(APIKeys.SID, APIKeys.AuthToken);

                test.SendSmsAsync("414-310-7982", c.phoneNumber, "Test");
           }

            return View();
        }

        // public void textCallee()
        //{
        //}

        // public void findCallee()
        // {
        //In seperate method create one with view
        //That will have an index of people to contact via text
        //Also where text responses will be logged into times to 
        //Reach the person 
        //This will also log time/day Callee wants to be contacted and call at 
        //that time, will still log demeanor 
        // }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult Index(string to)
        //{
        //    var response = new VoiceResponse();
        //    response.Say("Thanks for calling!");

        //    Execute();
        //    return Content(response.ToString(), "text/xml");
        //}



        //public void Conference()
        //{
        //    var response = new VoiceResponse();
        //    var dial = new Dial();
        //    dial.Conference("miderated-conference-room",
        //    startConferenceOnEnter: false);
        //    response.Append(dial);

        //    Console.WriteLine(response.ToString());

        //   {
        //        return Content(result.RestException.Message);
        //    }

        //  //  return Content("The call has been initiated");
    }
}
