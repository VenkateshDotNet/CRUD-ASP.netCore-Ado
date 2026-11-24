using Microsoft.AspNetCore.Mvc;
using SpCrud.EmpServiceLayer;
namespace SpCrud.Controllers
{
    public class EmployeeController : Controller
    {
        IEmpSl _iempsl;
        public EmployeeController(IEmpSl empsl)
        {
            _iempsl = empsl;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Models.Employee emp)
        {
            int res = _iempsl.SaveEmployee(emp);
            return View();
        }
    }
}
