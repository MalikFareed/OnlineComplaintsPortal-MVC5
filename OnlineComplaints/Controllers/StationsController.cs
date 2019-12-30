using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineComplaints.Controllers
{
    [Filters.Admin]
    public class StationsController : Controller
    {
        public ActionResult AllStations()
        {
            BL_Stations bL_Stations = new BL_Stations();
            List<Station> stations_List = bL_Stations.Stations.ToList();
            return View(stations_List);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Station station)
        {
            if (ModelState.IsValid)
            {
                BL_Stations bL_Stations = new BL_Stations();
                bL_Stations.InsertStation(station);

                return RedirectToAction("AllStations");
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            BL_Stations bL_Stations = new BL_Stations();
            bL_Stations.DeleteStation(id);

            return RedirectToAction("AllStations");
        }







    }
}