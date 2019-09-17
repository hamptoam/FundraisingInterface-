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

                if (callee == null)
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
        public ActionResult Edit([Bind(Include = "Id")]  Phone phone)
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
            test.CallAsync("414-310-7982", this.Callee.phoneNumber, "Goodbye");


            return View();
        }
        [HttpGet]
        public void setTime()
        {
            List<SelectListItem> dayToCall = new List<SelectListItem>()
                {
                    new SelectListItem
                    {
                        Text = "Monday",
                        Value = "1"
                    },
                    new SelectListItem
                    {
                        Text = "Tuesday",
                        Value = "2"
                    },
                    new SelectListItem
                    {
                        Text = "Wednesday",
                        Value = "3"
                    },
                    new SelectListItem
                    {
                        Text = "Thursday",
                        Value = "4"
                    },
                    new SelectListItem
                    {
                        Text = "Friday",
                        Value = "5"
                    },
                    new SelectListItem
                    {
                        Text = "Saturday",
                        Value = "6"
                    },

                };
            ViewBag(dayToCall);

            List<SelectListItem> hourToCall = new List<SelectListItem>()
                {
                    new SelectListItem
                        {
                            Text = "9", Value = "9"
                        },
                    new SelectListItem
                        {
                            Text = "10", Value = "10"
                        },
                    new SelectListItem
                        {
                            Text = "11", Value = "11"
                        },
                    new SelectListItem
                        {
                            Text = "12", Value = "12"
                        },
                    new SelectListItem
                        {
                            Text = "1", Value = "1"
                        },
                    new SelectListItem
                        {
                            Text = "2", Value = "2"
                        },
                    new SelectListItem
                        {
                            Text = "3", Value = "3"
                        },
                    new SelectListItem
                        {
                            Text = "4", Value = "4"
                        },
                    new SelectListItem
                        {
                            Text = "5", Value = "5"
                        },
                    };
            ViewBag(hourToCall);

            List<SelectListItem> minuteToCall = new List<SelectListItem>()
                {
                new SelectListItem
                {
                    Text = "05", Value = "05"
                },
                new SelectListItem
                {
                    Text = "10", Value = "5"
                },
                new SelectListItem
                {
                    Text = "15", Value = "5"
                },
                new SelectListItem
                {
                    Text = "20", Value = "5"
                },
                new SelectListItem
                {
                    Text = "25", Value = "5"
                },
                new SelectListItem
                {
                    Text = "30", Value = "5"
                },
                new SelectListItem
                {
                    Text = "35", Value = "5"
                },
                new SelectListItem
                {
                    Text = "40", Value = "5"
                },
                new SelectListItem
                {
                    Text = "45", Value = "5"
                },
                new SelectListItem
                {
                    Text = "50", Value = "5"
                },
                new SelectListItem
                {
                    Text = "55", Value = "5"
                },
                new SelectListItem
                {
                    Text = "00", Value = "5"
                },

                };
            ViewBag(minuteToCall);
        }

        //public ActionResult Text(Text Text, int CalleeId)
        //{

        //    // grab calle from id
        //    return RedirectToAction("SendTextAsync", "Texts");
        //}

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> SendTextAsync()
        {
            TwilioWrapperClient sms = new TwilioWrapperClient(APIKeys.SID, APIKeys.AuthToken);

           // await sms.SendSmsAsync("414-310-7982", this.Callee.phoneNumber, outgoingText);

            if (this.Callee.hasResponse)
            {
                //Console.WriteLine(Respose);
                //Console.WriteLine("Is callee interested");
                //string Input = Console.ReadLine();
                //if (Input == "Yes")
                //{
                //    Callee.isInterested = true;
                //}
                //else if (Input == "No")
                //    /       {
                //    //            Callee.isInterested = false;
                //    //        };
                //    //    }
                //    //    else
                //    //    {
                //    //        return View();
                //    //    }

                return View();
            }
            return View();

        }

        [HttpGet]
        public ActionResult RecieveText()
        {
            TwilioWrapperClient rps = new TwilioWrapperClient(APIKeys.SID, APIKeys.AuthToken);

            //this.Callee.response)

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
       
    

