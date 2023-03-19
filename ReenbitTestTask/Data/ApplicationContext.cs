using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using ReenbitTestTask.Models;

namespace ReenbitTestTask.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DbModelData> DbModelDatas { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }

   
}
