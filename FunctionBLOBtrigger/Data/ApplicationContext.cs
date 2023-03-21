using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using FunctionBLOBtrigger.Models;


namespace FunctionBLOBtrigger.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DbModelData> DbModelDatas { get; set; } = null!;
        protected readonly string _connectionString;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

    }


}
