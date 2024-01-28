using AutoMapper;
using CaseWork.Abstractions.Dto;
using CaseWork.Data.Entity;

namespace CaseWork.Business.DtoMap
{
    public class DepartmentMap : Profile
    {
        public DepartmentMap()
        {
            CreateMap<DepartmentRequest, Department>().ReverseMap();
        }
    }
}
