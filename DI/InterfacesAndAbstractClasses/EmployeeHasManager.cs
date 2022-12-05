using DI.Models;

namespace DI
{
    public abstract class EmployeeHasManager : IEmployee, IEmployeeWithManager
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public Manager Manager { get; set; }

        public void AssignManager(Manager manager)
        {
            Manager = manager;
        }

        public virtual void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 12.50M;

            Salary = baseAmount + (rank * 2);
        }

        public virtual void GeneratePerformanceReview()
        {
            Console.WriteLine("I'm reviewing a direct report's performance.");
        }
    }

}