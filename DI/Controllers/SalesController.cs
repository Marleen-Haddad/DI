using DI.InterfacesAndAbstractClasses;
using DI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
    
        private readonly IEmployeeDAL _employeeDAL;
        public SalesController( IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        [HttpPost]
        [Route("AddSales")]
        public IActionResult Add(string SalesFirstName, string SalesLastName)
        {
            EmployeeHasManager sales = new Sales();
            sales.FirstName = SalesFirstName;
            sales.LastName = SalesLastName;

            Guid guid= _employeeDAL.AddEmployeeWithManager(sales);

            return Ok($"Employee Guid : {guid}");
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(Guid guid)
        {
            bool isDeleted = _employeeDAL.DeleteEmployee(guid);
            return Ok(isDeleted);
        }
    }
}