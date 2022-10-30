using DI.Helpers;
using DI.InterfacesAndAbstractClasses;
using Newtonsoft.Json;
namespace DI.Services
{
    public class EmployeeDAL : IEmployeeDAL
    {
        public Guid AddEmployeeWithManager(EmployeeHasManager employee)
        {
            employee.Guid = new Guid();
            FileHelper.WriteToFile("Employees.txt", JsonConvert.SerializeObject(employee));
            return employee.Guid;
        }

        public Guid AddEmployeeWithoutManager(IEmployee employee)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(Guid guid)
        {
            string? employees = FileHelper.ReadFile("Employees.txt");
            if (string.IsNullOrEmpty(employees))
            {
                return false;
            }
            else
            {
                FileHelper.WriteToFile("Employees.txt", JsonConvert.SerializeObject(JsonConvert.DeserializeObject<List<EmployeeHasManager>>(employees).Where(e => !e.Guid.Equals(guid))));
                return true;
            }

        }

        public bool UpdateEmployee(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
