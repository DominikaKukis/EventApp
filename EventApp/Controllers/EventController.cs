using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventApp.Models;

namespace EventApp.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.EventTable.ToList());
            }
                
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {

            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.EventTable.Where(x=> x.Id == id).FirstOrDefault());
            }
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventTable eventTable)
        {

            using (DbModels dbModels = new DbModels())

            {
                dbModels.EventTable.Add(eventTable);
                dbModels.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.EventTable.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventTable eventTable)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    dbModels.Entry(eventTable).State = EntityState.Modified;
                    dbModels.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.EventTable.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventTable eventTable)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    eventTable = dbModels.EventTable.Where(x=>x.Id==id).FirstOrDefault();
                    dbModels.EventTable.Remove(eventTable);
                    dbModels.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
