namespace CaseWork.Abstractions.Dto
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string MainAddress { get; set; }
        public string Gender { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
