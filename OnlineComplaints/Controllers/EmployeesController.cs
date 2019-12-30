using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineComplaints.Controllers
{
    [Filters.Admin]
    public class EmployeesController : Controller
    {
        // GET: Employee
        public ActionResult AllEmployees()
        {
            BL_Employees bL_Employees = new BL_Employees();
            List<Employee> employees_List = bL_Employees.Employees.ToList();

            return View(employees_List);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                BL_Employees bL_Employees = new BL_Employees();
                bL_Employees.InsertEmployee(employee);
                return RedirectToAction("AllEmployees");
            }

            return View();
        }

        public ActionResult Delete(double id)
        {
            BL_Employees bL_Employees = new BL_Employees();
            bL_Employees.DeleteEmployee(id);

            return RedirectToAction("AllEmployees");
        }
    }
}