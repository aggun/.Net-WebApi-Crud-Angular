using AutoMapper;
using CaseWork.Abstractions.Dto;
using CaseWork.Business.Interface;
using CaseWork.Data.Entity;
using CaseWork.DataAcces.Service;

namespace CaseWork.Business.Service
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        private readonly IMapper _mapper;

        public DepartmentService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Department GetByDepartmentCode(int departmentCode)
        {
            return GetAll().FirstOrDefault(x => x.DepartmentCode == departmentCode);
        }

        public void Save(DepartmentRequest departmentRequest)
        {
            var department = Where(x => x.DepartmentCode == departmentRequest.DepartmentCode).FirstOrDefault();
            if (department != null)
            {
                //  throw new Exception("A record already exists with this department code");
            }
            department = _mapper.Map<Department>(departmentRequest);
            Add(department);
        }
    }
}
