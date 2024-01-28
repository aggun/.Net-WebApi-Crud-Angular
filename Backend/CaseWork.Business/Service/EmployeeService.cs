using AutoMapper;
using CaseWork.Abstractions.Dto;
using CaseWork.Business.Interface;
using CaseWork.Data.Entity;
using CaseWork.DataAcces.Service;

namespace CaseWork.Business.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public EmployeeService(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public EmployeeResponse GetEmployee(int id)
        {
            var employe = _mapper.Map<EmployeeResponse>(GetById(id));
            if (employe != null)
            {
                var departmentName = _departmentService.GetByDepartmentCode(employe.DepartmentCode).DepartmentName;
                employe.DepartmentName = departmentName;
                return employe;
            }
            return null;
        }


        public List<EmployeeResponse> GetEmployees()
        {
            List<EmployeeResponse> responses = new();
            var employees = GetAll();
            var departments = _departmentService.GetAll().ToDictionary(x => x.DepartmentCode, x => x.DepartmentName);

            foreach (var employee in employees)
            {
                var response = _mapper.Map<EmployeeResponse>(employee);
                response.DepartmentName = departments[employee.DepartmentCode];
                responses.Add(response);
            }
            return responses;
        }

        public void Save(EmployeeRequest employeeRequest)
        {
            var employee = _mapper.Map<Employee>(employeeRequest);
            employee.HireDate = DateTime.Now;
            base.Add(employee);
        }
    }
}
