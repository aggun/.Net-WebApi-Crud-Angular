using AutoMapper;
using CaseWork.Abstractions.Dto;
using CaseWork.Data.Entity;

namespace CaseWork.Business.DtoMap
{
    internal class EmployeMap : Profile
    {
        public EmployeMap()
        {
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<Employee, EmployeeRequest>().ReverseMap();
        }
    }
}
