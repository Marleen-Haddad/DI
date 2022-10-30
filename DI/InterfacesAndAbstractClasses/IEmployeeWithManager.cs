using DI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DI
{
    public interface IEmployeeWithManager
    {
        public Manager Manager { get; set; }
        public void AssignManager (Manager manager);
    }

}