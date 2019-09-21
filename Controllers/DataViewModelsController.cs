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
    public class DataViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DataViewModels
        public ActionResult Index()
        {
            return View(db.DataViewModels.ToList());
        }

        // GET: DataViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataViewModel dataViewModel = db.DataViewModels.Find(id);
            if (dataViewModel == null)
            {
                return HttpNotFound();
            }
            return View(dataViewModel);
        }

        // GET: DataViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] DataViewModel dataViewModel)
        {
            if (ModelState.IsValid)
            {
                db.DataViewModels.Add(dataViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dataViewModel);
        }

        // GET: DataViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataViewModel dataViewModel = db.DataViewModels.Find(id);
            if (dataViewModel == null)
            {
                return HttpNotFound();
            }
            return View(dataViewModel);
        }

        // POST: DataViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] DataViewModel dataViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dataViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dataViewModel);
        }

        // GET: DataViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataViewModel dataViewModel = db.DataViewModels.Find(id);
            if (dataViewModel == null)
            {
                return HttpNotFound();
            }
            return View(dataViewModel);
        }

        // POST: DataViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataViewModel dataViewModel = db.DataViewModels.Find(id);
            db.DataViewModels.Remove(dataViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult CalleeStats()
        {
            using (ApplicationDbContext context = new ApplicationDbContext()
            {
                try
                {
                    
                }
                catch
                {
                    return View();

                }
            }

        }

    public ActionResult CampaignStats()
    {
        try
        {
         
        }
        catch
        {
            

        }
    }
    
    
    


    


        

        public ActionResult CampaignStats()
        {




        }


        public void EmployoeeStats()
        {

        }

        public void EmployoeeStats()
        {

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
