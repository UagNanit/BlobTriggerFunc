using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using FunctionBLOBtrigger.Models;

namespace FunctionBLOBtrigger.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DbModelData> DbModelDatas { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
              // создаем базу данных при первом обращении
        }
    }

   
}
