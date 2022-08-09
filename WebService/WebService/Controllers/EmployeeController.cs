using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //Employee object
        private Employee employee;
        
        /// <summary>
        /// Constructor for EmployeeController
        /// </summary>
        public EmployeeController()
        {
            employee = new Employee();
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public List<EmployeeDAO> Get()
        {
            return employee.GetAllEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public EmployeeDAO Get(string id)
        {
            return employee.GetEmployeeById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public string Post([FromBody] EmployeeDAO newEmployee)
        {
            return $"Rows affected: {employee.InsertNewEmployee(newEmployee)}";
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public string Put(string id, [FromBody] EmployeeDAO updatedEmployee)
        {
            return $"Rows Affected: {employee.UpdateEmployeeById(updatedEmployee, id)}";
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            return $"Rows Affected: {employee.DeleteEmployeeById(id)}";
        }
    }
}
