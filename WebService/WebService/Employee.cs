namespace WebService
{
    public class Employee : EmployeeInterface
    {
        //Employee Repository Object
        private EmployeeRepository repo;

        /// <summary>
        /// Constructor for Employee
        /// </summary>
        public Employee()
        {
            repo = new EmployeeRepository();
        }

        /// <summary>
        /// Returns a list of all employees
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDAO> GetAllEmployees()
        {
            return repo.GetAllEmployees();
        }

        /// <summary>
        /// Returns single employee by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeDAO GetEmployeeById(string id)
        {
            return repo.GetEmployeeById(id);
        }

        /// <summary>
        /// Inserts a new employee into the employee table
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        public int InsertNewEmployee(EmployeeDAO newEmployee)
        {
            return repo.InsertNewEmployee(newEmployee);
        }

        /// <summary>
        /// Updates an employee based on their ID
        /// </summary>
        /// <param name="updatedEmployee"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateEmployeeById(EmployeeDAO updatedEmployee, string id) 
        {
            return repo.UpdateEmployeeById(updatedEmployee, id);
        }

        /// <summary>
        /// Deletes and employee based on their ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEmployeeById(string id)
        {
            return repo.DeleteEmployeeById(id);
        }
    }
}
