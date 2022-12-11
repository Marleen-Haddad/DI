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
            employee.Guid = new Guid();
            List<IEmployee> employees = new List<IEmployee>();
            employees = JsonConvert.DeserializeObject<List<IEmployee>>(FileHelper.ReadFile("Employees.txt"));
            employees.Add(employee);
            FileHelper.WriteToFile("Employees.txt", JsonConvert.SerializeObject(employees));
            return employee.Guid;
        }

        public bool DeleteEmployee(Guid guid)
        {
            string? employees = FileHelper.ReadFile("Employees.txt");
            if (string.IsNullOrEmpty(employees))
            {
                throw new SystemException("No Employees found");
            }
            else
            {
                FileHelper.WriteToFile("Employees.txt", JsonConvert.SerializeObject(JsonConvert.DeserializeObject<List<EmployeeHasManager>>(employees).Where(e => !e.Guid.Equals(guid))));
                return true;
            }

        }

        public bool UpdateEmployee(Guid guid, IEmployee employee)
        {
            List<IEmployee> employees = new List<IEmployee>();
            employees = JsonConvert.DeserializeObject<List<IEmployee>>(FileHelper.ReadFile("Employees.txt"));
            employees = employees.Select(e =>
            {
                if (e.Guid.Equals(guid))
                    return employee;
                else return e;
            }).ToList();
            FileHelper.WriteToFile("Employees.txt", JsonConvert.SerializeObject(employees));
            return true;
        }
    }
}
