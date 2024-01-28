using CaseWork.Abstractions.Dto;
using CaseWork.Business.Interface;
using CaseWork.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CaseWork.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IEnumerable<Department> Get()
        {
            var departments = _departmentService.GetAll();
            return departments;
        }

        [HttpGet("{id}")]
        public Department Get(int id)
        {
            var department = _departmentService.GetById(id);
            return department;
        }

        [HttpPost]
        public void Post([FromBody] DepartmentRequest department)
        {
            _departmentService.Save(department);
        }

        [HttpPut]
        public void Put([FromBody] Department department)
        {
            _departmentService.Update(department);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _departmentService.Delete(id);
        }
    }
}
