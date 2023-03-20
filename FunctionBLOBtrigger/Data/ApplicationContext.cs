using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using FunctionBLOBtrigger.Models;


namespace FunctionBLOBtrigger.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DbModelData> DbModelDatas { get; set; } = null!;
        protected readonly string _connectionString;
        public ApplicationContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string
            options.UseSqlServer(_connectionString);
        }
    }

   
}
