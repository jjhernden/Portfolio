namespace WebService
{
    public class EmployeeDAO
    {
        public string EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeFullName { get { return EmployeeFirstName + " " + EmployeeLastName; } }
        public string EmployeeEmail { get; set; }
        public bool AdminAccess { get; set; }
        public string Role { get; set; }
        public string Team { get; set; }
        public bool IsManager { get; set; }
        public string ManagerName { get; set; }
        public int YearsOfTenure { get; set; }
    }
}
