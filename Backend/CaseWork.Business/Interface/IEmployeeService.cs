using CaseWork.Abstractions.Dto;
using CaseWork.Data.Entity;
using CaseWork.DataAcces.Interface;

namespace CaseWork.Business.Interface
{
    public interface IEmployeeService : IService<Employee>
    {
        List<EmployeeResponse> GetEmployees();
        void Save(EmployeeRequest departmentRequest);
        EmployeeResponse GetEmployee(int id);
    }
}
