using FunctionBLOBtrigger.Data;
using FunctionBLOBtrigger.Repository;
using FunctionBLOBtrigger.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


public class Program
{
    //private static string connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
    private static void Main(string[] args)
    {
        var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(s =>
    {
        
       /* s.AddDbContext<ApplicationContext>(
          options => options.UseSqlServer(connectionString));*/

        s.AddSingleton<IEmailSender>((s) => { return new EmailSender(); });
    })
    .Build();

        host.Run();
    }
}