using CaseWork.Data.Core;

namespace CaseWork.Data.Entity
{
    public class Department : IEntity
    {
        public int Id { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
