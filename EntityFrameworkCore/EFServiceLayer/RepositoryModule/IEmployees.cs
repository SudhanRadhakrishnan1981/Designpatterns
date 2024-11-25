using EFModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer.RepositoryModule
{
    public interface IEmployees : IRepository<Employee>
    {
        public List<Employee> GetEmployeeDetails();
        public Employee GetEmployeeDetails(int id);
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(int id);
        public bool CheckEmployee(int id);
    }
}
