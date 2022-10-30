using System;
using System.Collections.Generic;
using System.Text;

namespace DI
{
    public interface IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public void CalculatePerHourRate(int rank);
    }

}