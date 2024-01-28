using CaseWork.Abstractions.Dto;
using CaseWork.Data.Entity;
using CaseWork.DataAcces.Interface;

namespace CaseWork.Business.Interface
{
    public interface IDepartmentService : IService<Department>
    {
        void Save(DepartmentRequest departmentRequest);
        Department GetByDepartmentCode(int departmentCode);
    }
}
