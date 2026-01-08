using Microsoft.AspNetCore.Mvc;
using webapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        EmployeeDB db = new EmployeeDB();
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("GetAll")]
        public List<Employee> Get()
        {
            return db.SelectDB();
        }

        // GET api/<ValuesController>/5
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var employees = db.SelectById(id);

            if (employees == null || employees.Count == 0)
                return NotFound("Employee not found");
            return Ok(employees);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("PostTab")]
        public IActionResult Post(Employee objcls)
        {
            db.InsertDB(objcls);
            return Ok("Successfully Inserted");
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        [Route("UpdatebyId/{id}")]
        public IActionResult Put(int id, Employee employee)
        {
            db.Update(id,employee);
            return Ok("Data Updated Successfully");
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        [Route("Deletetab/{id}")]
        public IActionResult Delete(int id)
        {
            db.DeleteById(id);
            return Ok("Deleted Successfully");
        }
    }
}
