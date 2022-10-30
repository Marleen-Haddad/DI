using DI.InterfacesAndAbstractClasses;
using DI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
    

        private readonly ILogger<SalesController> _logger;

        private readonly IEmployeeDAL _employeeDAL;
        public SalesController(ILogger<SalesController> logger, IEmployeeDAL employeeDAL)
        {
            _logger = logger;
            _employeeDAL = employeeDAL;
        }

        [HttpPost]
        [Route("AddSales")]
        public async Task<IActionResult> Add(string SalesFirstName, string SalesLastName ,string ManagerFirstName , string ManagerLastName )
        {
            Manager manager = new Manager();
            manager.FirstName = ManagerFirstName;
            manager.LastName = ManagerLastName;

            EmployeeHasManager sales = new Sales();
            sales.AssignManager(manager);
            sales.FirstName = SalesFirstName;
            sales.LastName = SalesLastName;

            Guid guid= _employeeDAL.AddEmployeeWithManager(sales);

            return Ok($"Employee Guid : {guid}");
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            bool isDeleted = _employeeDAL.DeleteEmployee(guid);

            return Ok(isDeleted);
        }
    }
}