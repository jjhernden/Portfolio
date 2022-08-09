namespace WebService
{
    public interface EmployeeInterface
    {
        /// <summary>
        /// Returns a list of all employees
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDAO> GetAllEmployees();

        /// <summary>
        /// Returns single employee by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeDAO GetEmployeeById(string id);
        
        /// <summary>
        /// Inserts a new employee into the employee table
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        public int InsertNewEmployee(EmployeeDAO newEmployee);
        
        /// <summary>
        /// Updates an employee based on their ID
        /// </summary>
        /// <param name="updatedEmployee"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateEmployeeById(EmployeeDAO updatedEmployee, string id);
        
        /// <summary>
        /// Deletes and employee based on their ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEmployeeById(string id);

    }
}
