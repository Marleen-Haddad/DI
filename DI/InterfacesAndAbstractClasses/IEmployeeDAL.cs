namespace DI.InterfacesAndAbstractClasses
{
    public interface IEmployeeDAL
    {
        Guid AddEmployeeWithoutManager(IEmployee employee);
        Guid AddEmployeeWithManager(EmployeeHasManager employee);
        bool DeleteEmployee(Guid guid);
        bool UpdateEmployee(Guid guid);
    }
}
