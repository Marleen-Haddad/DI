using System;

namespace DI.Models
{
    public class Manager : EmployeeHasManager
    {
        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 19.75M;

            Salary = baseAmount + rank * 4;
        }

    }

}