using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestAPII2.Entities;

namespace TestAPII2.DbContexttest
{
    public class DbContextTest : DbContext
    {


        public DbContextTest(DbContextOptions<DbContextTest> options)
      : base(options)
        {
        }


        public DbSet<Empleado> Empleados { get; set; }

    }
}
