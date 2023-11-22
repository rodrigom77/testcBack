using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPII2.DbContexttest;
using TestAPII2.Entities;

namespace TestAPII2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCController : ControllerBase
    {


        private readonly DbContextTest _dbContext;

        public TestCController(DbContextTest dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<Empleado> Get() 
        {
           return _dbContext.Empleados.ToList();
        }

        [HttpPost]
        public Empleado Post(Empleado empleado)
        {
             _dbContext.Empleados.Add(empleado);
            _dbContext.SaveChanges(); 
            return empleado;
        }

        [HttpPut]
        public Empleado Update(Empleado empleado) 
        {
            var actual = _dbContext.Empleados.Find(empleado.Id);
            actual.Name = empleado.Name;
            actual.Edad = empleado.Edad;
            _dbContext.Empleados.Update(actual);
            _dbContext.SaveChanges();
            return actual; 
        }

        [HttpDelete]
        public void Delete([FromQuery] int id) 
        {
            var empleado = _dbContext.Empleados.Find(id);
            _dbContext.Empleados.Remove(empleado);
            _dbContext.SaveChanges();
        }

    }
}
