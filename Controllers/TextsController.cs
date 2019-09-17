using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fundraising_Capstone2.API;
using Fundraising_Capstone2.Keys;
using Fundraising_Capstone2.Models;

namespace Fundraising_Capstone2.Controllers
{
    public class TextsController : PhonesController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Texts
        public ActionResult Index()
        {
            return View(db.Texts.ToList());
        }

        // GET: Texts/Details/5
        public ActionResult Details(int? CalleeId)
        {
            if (CalleeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Text text = db.Texts.Find(CalleeId);
            if (text == null)
            {
                return HttpNotFound();
            }
            return View(text);
        }

        // GET: Texts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Texts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Text text)
        {
            if (ModelState.IsValid)
            {
                db.Texts.Add(text);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(text);
        }

        // GET: Texts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Text text = db.Texts.Find(id);
            if (text == null)
            {
                return HttpNotFound();
            }
            return View(text);
        }

        // POST: Texts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Text text)
        {
            if (ModelState.IsValid)
            {
                db.Entry(text).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(text);
        }

        // GET: Texts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Text text = db.Texts.Find(id);
            if (text == null)
            {
                return HttpNotFound();
            }
            return View(text);
        }

        // POST: Texts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Text text = db.Texts.Find(id);
            db.Texts.Remove(text);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





        [HttpGet]
        public ActionResult SendText()
        {
             TwilioWrapperClient sms = new TwilioWrapperClient(APIKeys.SID, APIKeys.AuthToken);

            //    Console.WriteLine("Enter Text Here: Short Description, Ask when a good time to call");
             //   string outgoingText;
           //     sms.SendSmsAsync("414-310-7982", this.Callee.phoneNumber, outgoingText);

            //    if (this.Callee.hasResponse)
             //    {
          //        Console.WriteLine(Response);
            //        Console.WriteLine("Is callee interested");
            //        string Input = Console.ReadLine();
            //        if (Input == "Yes")
        //        {
        //            Callee.isInterested = true;
        //        }
        //        else if (Input == "No")
        //        {
        //            Callee.isInterested = false;
        //        };
        //    }
        //    else
        //    {
        //        return View();
        //    }

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
