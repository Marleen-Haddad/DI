using DI.InterfacesAndAbstractClasses;
using DI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : AppBaseController<SalesController>
    {
       
        private readonly IEmployeeDAL _employeeDAL;

        public SalesController(IEmployeeDAL employeeDAL, ILogger<SalesController> _logger) :base(_logger)    
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

            _logger.LogInformation($"Add new sales employee with Guid : {guid}");

            return Ok($"Employee Guid : {guid}");
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(Guid guid)
        {
            bool isDeleted = _employeeDAL.DeleteEmployee(guid);

            _logger.LogInformation($"Sales employee deleted with Guid : {guid}");

            return Ok(isDeleted);
        }
    }
}