using EFModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public void AddEmployee(Employee employee)
        {
            var employeeRepository = _unitOfWork.GetRepository<Employee>();
            employeeRepository.AddAsync(employee);

            // Additional logic, if any...

            _unitOfWork.SaveChanges();
        }


        public void DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
