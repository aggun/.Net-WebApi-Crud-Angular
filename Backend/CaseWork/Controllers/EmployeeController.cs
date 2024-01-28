using CaseWork.Abstractions.Dto;
using CaseWork.Business.Interface;
using CaseWork.Data.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaseWork.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeResponse> Get()
        {
            var result = _employeeService.GetEmployees();
            return result;
        }

        [HttpGet("{id}")]
        public EmployeeResponse Get(int id)
        {
            var result = _employeeService.GetEmployee(id);
            return result;
        }

        [HttpPost]
        public void Post([FromBody] EmployeeRequest employeeRequest)
        {
            _employeeService.Save(employeeRequest);
        }

        [HttpPut]
        public void Put(Employee employee)
        {
            _employeeService.Update(employee);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeService.Delete(id);
        }
    }
}
