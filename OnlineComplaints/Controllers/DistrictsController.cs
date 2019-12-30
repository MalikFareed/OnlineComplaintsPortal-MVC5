using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace OnlineComplaints.Controllers
{
    [Filters.Admin]
    public class DistrictsController : Controller
    {

        public ActionResult AllDistricts()
        {
            BL_Districts bL_Districts = new BL_Districts();

            List<District> districts_List = bL_Districts.Districts.ToList();
            return View(districts_List);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(District district)
        {
            if (ModelState.IsValid)
            {
                BL_Districts bL_Districts = new BL_Districts();
                bL_Districts.InsertDistrict(district);

                return RedirectToAction("AllDistricts");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            BL_Districts bL_Districts = new BL_Districts();
            bL_Districts.DeleteDistrict(id);

            return RedirectToAction("AllDistricts");
        }
    }
}