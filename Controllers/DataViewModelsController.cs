using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Fundraising_Capstone2.Models;

namespace Fundraising_Capstone2.Controllers
{
    public class DataViewModelsController : Controller
    {
        #region Index method 
        private ApplicationDbContext db = new ApplicationDbContext();

        public int EmployeeId { get; private set; }

        public int CampaignId { get; private set; }

        // GET: Funds
        public ActionResult Index()
        {
            return this.View();
        }
        #endregion

        // GET: Funds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

              using (ApplicationDbContext context = new ApplicationDbContext())
              {
                  Employee employee = db.Employees
                 .Include("EmployeeFunds").Select(fu => fu)
                 .Include("ManagerEmployee").Select(em => em)
                 .Include("CampaignEmployee").Select(ca => ca)
                  .FirstOrDefault(em => em.EmployeeId == EmployeeId);
                  if (employee == null)
                  {
                      return HttpNotFound();
                  }   
                return View();
              }
        }
        #region Get data method
        public ActionResult GetGata()
        {
            JsonResult result = new JsonResult();

            try
            {
                List<Funds> data = this.LoadData();

                var graphData = data.GroupBy(p => new
                {
                    p.DailyFunds,
                    p.WeeklyFunds,
                    p.MonthlyFunds,
                    p.QuarterlyFunds,
                    p.YearlyFunds
                })
                    .Select(g => new
                    {

                    g.Key.DailyFunds,
                    g.Key.WeeklyFunds,
                    g.Key.MonthlyFunds,
                    g.Key.QuarterlyFunds,
                    g.Key.YearlyFunds
                       });

                graphData = graphData.Take(10).Select(p => p).ToList();

                result = this.Json(graphData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return result;
        }
        #endregion

        #region Helpers 

        #region Load Data

        private List<Funds> LoadData()
        {
            List<Funds> first = new List<Funds>();

            try
            {
                string line = string.Empty;
                string srcFilePath = "Content/files/Funds.txt";
                var rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var fullPath = Path.Combine(rootPath, srcFilePath);
                string filePath = new Uri(fullPath).LocalPath;
                StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read));

                while ((line = sr.ReadLine()) != null)
                {
                    Funds infoObj = new Funds();
                    string[] info = line.Split(',');

                    infoObj.FundId = Convert.ToInt32(info[0].ToString());
                    infoObj.DailyFunds = Convert.ToInt32(info[1].ToString());
                    infoObj.WeeklyFunds = Convert.ToInt32(info[2].ToString());
                    infoObj.MonthlyFunds = Convert.ToInt32(info[3].ToString());
                    infoObj.QuarterlyFunds = Convert.ToInt32(info[4].ToString());
                    infoObj.YearlyFunds = Convert.ToInt32(info[5].ToString());

                    first.Add(infoObj);
                }

                sr.Dispose();
                sr.Close();

            }
            catch (Exception ex)
            {

                Console.Write(ex);

            }


            return first;
        }
        #endregion

        #endregion


        public ActionResult calleeData(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                CalleeFunds calleefunds = db.CalleeFunds
                .FirstOrDefault(fu => fu.Id == Id);


                if (calleefunds == null)
                {
                    return (HttpNotFound());
                }
                return View(calleefunds);
            }
        }

        public ActionResult campaignData(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                CampaignFunds campaignfunds = db.CampaignFunds
                .FirstOrDefault(fu => fu.Id == Id);


                if (campaignfunds == null)
                {
                    return (HttpNotFound());
                }
                return View(campaignfunds);
            }
        }

        public ActionResult employeeData(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                EmployeeFunds employeefunds = db.EmployeeFunds
                .FirstOrDefault(fu => fu.Id == Id);


                if (employeefunds == null)
                {
                    return (HttpNotFound());
                }
                return View(employeefunds);
            }
        }
        // GET: Funds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FundId,DailyFunds,WeeklyFunds,MonthlyFunds,QuarterlyFunds,YearlyFunds")] Funds funds)
        {
            if (ModelState.IsValid)
            {
                db.Funds.Add(funds);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funds);
        }

        // GET: Funds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funds funds = db.Funds.Find(id);
            if (funds == null)
            {
                return HttpNotFound();
            }
            return View(funds);
        }

        // POST: Funds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FundId,DailyFunds,WeeklyFunds,MonthlyFunds,QuarterlyFunds,YearlyFunds")] Funds funds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funds).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funds);
        }

        // GET: Funds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funds funds = db.Funds.Find(id);
            if (funds == null)
            {
                return HttpNotFound();
            }
            return View(funds);
        }

        // POST: Funds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funds funds = db.Funds.Find(id);
            db.Funds.Remove(funds);
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


//    [HttpGet]
//    public ActionResult CalleeStats()
//    {
//        using (ApplicationDbContext context = new ApplicationDbContext()
//        {
//            try
//            {

//            }
//            catch
//            {
//                return View();

//            }
//        }

//    }

//public ActionResult CampaignStats()
//{
//    try
//    {

//    }
//    catch
//    {


//    }
//

//public ActionResult CampaignStats()
//        {




//        }


//        public void EmployoeeStats()
//        {

//        }

//        public void EmployoeeStats()
//        {

//        }

