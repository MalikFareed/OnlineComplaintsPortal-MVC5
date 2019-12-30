using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineComplaints.Controllers
{

    public class ComplainsController : Controller
    {
        [Filters.Admin]
        public ActionResult AllComplains()
        {
            BL_Complains bL_Complains = new BL_Complains();
            List<Complain> complains_List = bL_Complains.complains.ToList();

            return View(complains_List);
        }


        [HttpGet]
        [ActionName("Create")]
        [Filters.User]
        public ActionResult Create_Get()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        [Filters.User]
        public ActionResult Create_Post()
        {
            Complain complain = new Complain();
            TryUpdateModel(complain);

            if (ModelState.IsValid)
            {
                BL_Complains bL_Complains = new BL_Complains();
                bL_Complains.InsertComplain(complain);

                RedirectToAction("AllComplains");
            }
            return View();
        }

        [Filters.ASP]
        public ActionResult ComplainsByStationName(string id)
        {

            BL_Complains bL_Complains = new BL_Complains();
            List<Complain> complains_List = bL_Complains.ComplainsByStationName(id).ToList();

            return View(complains_List);
        }

        public ActionResult Delete(int id)
        {
            BL_Complains bL_Complains = new BL_Complains();
            bL_Complains.DeleteComplain(id);
            return RedirectToAction("AllComplains");
        }
    }
}