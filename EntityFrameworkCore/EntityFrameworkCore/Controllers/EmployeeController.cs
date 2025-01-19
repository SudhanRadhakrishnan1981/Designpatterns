using EFModellayer.Models;
using EFServiceLayer.RepositoryModule;
using EFServiceLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        

        private readonly IEmployeeService _employeeservices;

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeservices)
        {
            _logger = logger;
            _employeeservices = employeeservices;
        }

        //// GET: api/employee>
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Employee>>> Get()
        //{
        //    return await Task.FromResult(_IEmployee.GetEmployeeDetails());
        //}

        //// GET api/employee/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Employee>> Get(int id)
        //{
        //    var employees = await Task.FromResult(_IEmployee.GetEmployeeDetails(id));
        //    if (employees == null)
        //    {
        //        return NotFound();
        //    }
        //    return employees;
        //}

        // POST api/employee
        [HttpPost]
        public  ActionResult<Employee> Post(Employee employee)
        {

            if (employee != null)
            {
                Employee firstproduct = new Employee()
                {
                   EmployeeID = employee.EmployeeID,
                    NationalIDNumber = employee.NationalIDNumber,
                    BirthDate = employee.BirthDate,
                    EmployeeName = employee.EmployeeName,
                    Gender = employee.Gender,
                    HireDate = employee.HireDate,
                    JobTitle = employee.JobTitle,
                    LoginID = employee.LoginID,
                    MaritalStatus = employee.MaritalStatus,
                    ModifiedDate = employee.ModifiedDate,
                    RowGuid = employee.RowGuid,
                    SickLeaveHours = employee.SickLeaveHours,
                    VacationHours = employee.VacationHours
                };
                _employeeservices.AddEmployee(firstproduct);
            }

            return Ok();
        }

        //// PUT api/employee/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult<Employee>> Put(int id, Employee employee)
        //{
        //    if (id != employee.EmployeeID)
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        _IEmployee.UpdateEmployee(employee);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return await Task.FromResult(employee);
        //}

        //// DELETE api/employee/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Employee>> Delete(int id)
        //{
        //    var employee = _IEmployee.DeleteEmployee(id);
        //    return await Task.FromResult(employee);
        //}

        //private bool EmployeeExists(int id)
        //{
        //    return _IEmployee.CheckEmployee(id);
        //}
    }
}
