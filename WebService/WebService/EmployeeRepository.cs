using Dapper;
using System.Data.SqlClient;

namespace WebService
{
    public class EmployeeRepository : EmployeeRepositoryInterface
    {
        //Microsoft SQL Server Local Machine Connection String
        private string connectionString;

        //SQL Connection
        SqlConnection conn;

        /// <summary>
        /// Employee Repository Constructor
        /// </summary>
        public EmployeeRepository()
        {
            connectionString = "Data Source=DESKTOP-M0I0HA2;Initial Catalog=EmployeeDatabase;Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }


        /// <summary>
        /// Returns a list of all the Employees
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDAO> GetAllEmployees()
        {
            string sql = "SELECT * FROM Employee";
            List<EmployeeDAO> Employees = new List<EmployeeDAO>();
            using (conn)
            {
                Employees = conn.Query<EmployeeDAO>(sql).ToList();
            }

            return Employees;
        }
        
        /// <summary>
        /// Returns a single employee based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeDAO GetEmployeeById(string id)
        {
            string sql = "SELECT * FROM Employee WHERE EmployeeId = @id";
            EmployeeDAO employee = new EmployeeDAO();
            using (conn)
            {
                employee = conn.QuerySingle<EmployeeDAO>(sql, new {id = id});
            }
            
            return employee;
        }
        
        /// <summary>
        /// Inserts a new employee into the employee table
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        public int InsertNewEmployee(EmployeeDAO newEmployee)
        {
            string sql = @"INSERT INTO Employee
                           VALUES
                           (
                           @EmployeeId,
	                       @EmployeeFirstName,
	                       @EmployeeLastName,
	                       @EmployeeEmail,
	                       @AdminAccess,
	                       @Role,
	                       @Team,
	                       @IsManager,
	                       @ManagerName,
	                       @YearsOfTenure
                           )";
            int rowsAffected = 0;
            using (conn)
            {
                rowsAffected = conn.Execute(sql, new 
                {
                    EmployeeId = newEmployee.EmployeeId,
                    EmployeeFirstName = newEmployee.EmployeeFirstName,
                    EmployeeLastName = newEmployee.EmployeeLastName,
                    EmployeeEmail = newEmployee.EmployeeEmail,
                    AdminAccess = newEmployee.AdminAccess,
                    Role = newEmployee.Role,
                    Team = newEmployee.Team,
                    IsManager = newEmployee.IsManager,
                    ManagerName = newEmployee.ManagerName,
                    YearsOfTenure = newEmployee.YearsOfTenure
                });
            }
            return rowsAffected;
        }
        
        /// <summary>
        /// Updates a single employee based on their ID
        /// </summary>
        /// <param name="updatedEmployee"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateEmployeeById(EmployeeDAO updatedEmployee, string id)
        {
            string sql = @"UPDATE Employee 
                           SET EmployeeFirstName = @EmployeeFirstName,
                                EmployeeLastName = @EmployeeLastName,
                                EmployeeEmail = @EmployeeEmail,
                                AdminAccess = @AdminAccess,
                                Role = @Role,
                                Team = @Team,
                                IsManager = @IsManager, 
                                ManagerName = @ManagerName, 
                                YearsOfTenure = @YearsOfTenure
                            WHERE EmployeeId = @id";
            int rowsAffected = 0;
            using(conn)
            {
                rowsAffected = conn.Execute(sql, new
                {
                    id = updatedEmployee.EmployeeId,
                    EmployeeFirstName = updatedEmployee.EmployeeFirstName,
                    EmployeeLastName = updatedEmployee.EmployeeLastName,
                    EmployeeEmail = updatedEmployee.EmployeeEmail,
                    AdminAccess = updatedEmployee.AdminAccess,
                    Role = updatedEmployee.Role,
                    Team = updatedEmployee.Team,
                    IsManager = updatedEmployee.IsManager,
                    ManagerName = updatedEmployee.ManagerName,
                    YearsOfTenure = updatedEmployee.YearsOfTenure
                });
            }
            return rowsAffected; 
        }

        /// <summary>
        /// Deletes and employee based on their ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEmployeeById(string id)
        {
            string sql = "DELETE FROM Employee WHERE EmployeeId = @id";
            int rowsAffected = 0; 
            using (conn)
            {
                rowsAffected = conn.Execute(sql, new { id = id });
            }
            return rowsAffected;
        }
    }
}