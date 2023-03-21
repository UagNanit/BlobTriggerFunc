using FunctionBLOBtrigger.Data;
using FunctionBLOBtrigger.Repository;
using FunctionBLOBtrigger.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


public class Program
{
    
    public static void Main(string[] args)
    {
        var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(s =>
    {
        string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:DefaultConnection") ?? "Server=tcp:reenbittesttaskdbserver.database.windows.net,1433;Initial Catalog=ReenbitTestTask_db;Persist Security Info=False;User ID=nanit;Password=19891206Kov;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        s.AddDbContext<ApplicationContext>(
          options => options.UseSqlServer(connectionString));

        s.AddSingleton<IEmailSender>((s) => { return new EmailSender(); });
    })
    .Build();

        host.Run();
    }
}