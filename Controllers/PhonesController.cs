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
using Twilio.TwiML;
using Twilio.TwiML.Voice;

namespace Fundraising_Capstone2.Controllers
{
    public class PhonesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public object Callee { get; private set; }

        // GET: Phones
        public ActionResult Index(string to)
        {
            // string to = this.Callee.phoneNumber.ToString(); 
       
            var response = new VoiceResponse();
            response.Dial(to);
            response.Say("Goodbye");

            Console.WriteLine(response.ToString());

            return View(); //db.Phones.ToList()


        }


        // GET: Phones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
        [HttpPost]
        public ActionResult Dial(string to)
        {
            TwilioWrapperClient test = new TwilioWrapperClient(APIKeys.SID, APIKeys.AuthToken);


            var callerId = ConfigurationManager.AppSettings["TwilioCallerId"];

            var response = new VoiceResponse();
            if (!string.IsNullOrEmpty(to))
            {
                var dial = new Dial(callerId: callerId);
                // wrap the phone number or client name in the appropriate TwiML verb
                ////////    // by checking if the number given has only digits and format symbols
                if (Regex.IsMatch(to, "^[\\d\\+\\-\\(\\) ]+$"))
                {
                    dial.Number();
                }
                else
                {
                    dial.Client(to);
                }
                 response.Dial(dial);
            }
            else
            {
                response.Say("Thanks for calling!");
            }
            return Content(response.ToString(), "text/xml");
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
