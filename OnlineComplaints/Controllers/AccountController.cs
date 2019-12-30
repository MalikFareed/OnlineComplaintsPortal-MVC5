using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineComplaints.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [ActionName("LogIn")]
        public ActionResult Login_Get()
        {

            return View();
        }

        [HttpPost]
        [ActionName("LogIn")]
        public ActionResult Login_Post()
        {
            LogIn logIn = new LogIn();
            TryUpdateModel(logIn);

            if (ModelState.IsValid)
            {

                BL_ComplainantsDetail bL_ComplainantsDetail = new BL_ComplainantsDetail();
                List<ComplainantsDetail> ComplainantsDetails = bL_ComplainantsDetail.ComplainantsDetails.ToList();

                foreach (var user in ComplainantsDetails.ToList())
                {
                    if (user.Email == logIn.Email && user.UserPassword == logIn.Password)
                    {
                        Session[user.AccountType] = true;
                        return RedirectToAction("Create", "Complains");
                    }

                }

                BL_Employees bL_Employees = new BL_Employees();
                List<Employee> employees = bL_Employees.Employees.ToList();

                foreach (var employee in employees.ToList())
                {
                    if (logIn.Email == employee.Email && logIn.Password == employee.EmployeePassword && employee.AccountType == "Admin")
                    {
                        Session[employee.AccountType] = true;
                        return RedirectToAction("Admin_Index", "Admin");

                    }
                    else if (employee.Email == logIn.Email && employee.EmployeePassword == logIn.Password)
                    {
                        Session[employee.AccountType] = true;
                        if (employee.AccountType == "ASI")
                        {
                            return RedirectToAction("ComplainsByStationName/" + (employee.StationName) + "", "Complains");
                        }

                    }

                }
            }

            ViewBag.Error = "Incorrect username or password!";
            return View();

        }

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            Session["User"] = null;
            return RedirectToAction("LogIn", "Account");
        }
    }
}