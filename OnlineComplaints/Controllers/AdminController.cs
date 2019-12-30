using System.Web.Mvc;

namespace OnlineComplaints.Controllers
{
    [Filters.Admin]
    public class AdminController : Controller
    {
        public ActionResult Admin_Index()
        {
            return RedirectToAction("AllEmployees", "Employees");
        }

        public ActionResult ASP_Index(string id)
        {
            return RedirectToAction("ComplainsByStationName(id)", "Complains");
        }
    }
}