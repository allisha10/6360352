using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/emp")]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> employeeList = new List<Employee>
        {
            new Employee { Id = 1, Name = "Allisha", Department = "Finance" },
            new Employee { Id = 2, Name = "Alex", Department = "IT" }
        };

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(employeeList);
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Employee> Post([FromBody] Employee emp)
        {
            employeeList.Add(emp);
            return CreatedAtAction(nameof(Get), new { id = emp.Id }, emp);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}
