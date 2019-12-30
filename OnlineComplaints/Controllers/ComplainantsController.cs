using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineComplaints.Controllers
{

    public class ComplainantsController : Controller
    {
        [Filters.Admin]
        public ActionResult AllComplainantsDetail()
        {
            BL_ComplainantsDetail bL_ComplainantsDetail = new BL_ComplainantsDetail();

            List<ComplainantsDetail> ComplainantsDetail_List = bL_ComplainantsDetail.ComplainantsDetails.ToList();
            return View(ComplainantsDetail_List);
        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {

            return View();

        }


        [HttpPost]
        [ActionName("Create")]//=>reposnd on  .../complainants/create either we change its name(part#15)
        public ActionResult Create_Post()
        {
            ComplainantsDetail complainantsDetail = new ComplainantsDetail();
            TryUpdateModel(complainantsDetail);

            if (ModelState.IsValid)
            {

                BL_ComplainantsDetail bL_ComplainantsDetail = new BL_ComplainantsDetail();
                bL_ComplainantsDetail.InsertComplainantsDetails(complainantsDetail);

                return RedirectToAction("AllComplainantsDetail");
            }
            return View();

        }

        public ActionResult Delete(int id)
        {
            BL_ComplainantsDetail bL_ComplainantsDetail = new BL_ComplainantsDetail();
            bL_ComplainantsDetail.DeleteComplainant(id);

            return RedirectToAction("AllComplainantsDetail");
        }
    }

}