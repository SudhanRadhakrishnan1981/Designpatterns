using EFModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer.Service
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);


        Task<IEnumerable<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeetById(int id);
    }
}
