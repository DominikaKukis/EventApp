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
        public ActionResult Index(string searchString, string sortOrder, string nameString, string addressString, string costString, string maxDateString, string minDateString)
        {
            using (DbModels dbModel = new DbModels())
            {

                var events = dbModel.EventTable.AsQueryable();
                ViewBag.EventNameSortParam = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";

                switch (sortOrder)
                {
                    case "Name_desc":
                        events = events.OrderBy(x => x.Name);
                        return View(events.ToList());
                }

                if (!string.IsNullOrEmpty(searchString))
                {
                    return View(dbModel.EventTable.Where(x => x.Name.Contains(searchString) || x.Address.Contains(searchString)).ToList());
                }

                else if(!string.IsNullOrEmpty(nameString) || !string.IsNullOrEmpty(addressString) || !string.IsNullOrEmpty(costString) || !string.IsNullOrEmpty(maxDateString) || !string.IsNullOrEmpty(minDateString)) {

                    if (!string.IsNullOrEmpty(maxDateString))
                    {
                        var maxDate = DateTime.Parse(maxDateString);

                        if (!string.IsNullOrEmpty(minDateString))
                        {
                            var minDate = DateTime.Parse(minDateString);

                            if (!string.IsNullOrEmpty(costString))
                            {
                                double cost = Double.Parse(costString);
                                return View(dbModel.EventTable.Where(x => x.Name.Contains(nameString) && x.Address.Contains(addressString) && (x.Cost <= cost || x.Cost == null) && x.Date <= maxDate && x.Date >= minDate).ToList());
                            }

                            return View(dbModel.EventTable.Where(x => x.Name.Contains(nameString) && x.Address.Contains(addressString) && x.Date <= maxDate && x.Date >= minDate).ToList());

                        }

                        if (!string.IsNullOrEmpty(costString))
                        {
                            double cost = Double.Parse(costString);
                            return View(dbModel.EventTable.Where(x => x.Name.Contains(nameString) && x.Address.Contains(addressString) && (x.Cost <= cost || x.Cost == null) && x.Date <= maxDate).ToList());
                        }
                        return View(dbModel.EventTable.Where(x => x.Name.Contains(nameString) && x.Address.Contains(addressString) && x.Date <= maxDate).ToList());

                    }

                    if (!string.IsNullOrEmpty(minDateString))
                    {
                        var minDate = DateTime.Parse(minDateString);
                        return View(dbModel.EventTable.Where(x => x.Name.Contains(nameString) && x.Address.Contains(addressString) && x.Date >= minDate).ToList());

                    }

                    if (!string.IsNullOrEmpty(costString))
                    {
                        double cost = Double.Parse(costString);
                        return View(dbModel.EventTable.Where(x => x.Name.Contains(nameString) && x.Address.Contains(addressString) && (x.Cost <= cost || x.Cost == null)).ToList());
                    }

                    return View(dbModel.EventTable.Where(x => x.Name.Contains(nameString) && x.Address.Contains(addressString)).ToList());
                }
                
                else return View(dbModel.EventTable.ToList());
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
                //var tempId = (from c in dbModels.EventTable select eventTable.Id).Max();
                //tempId++;
                //eventTable.Id = tempId;
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
