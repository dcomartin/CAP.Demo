using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCore.CAP;
using MySql.Data.MySqlClient;

namespace CAPDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICapPublisher _capPublisher;

        public HomeController(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;
        }

        public async Task<IActionResult> Index()
        {
            using (var connection = new MySqlConnection("Server=localhost;Uid=root;Pwd=root;Database=Demo"))
            {
                using (var transaction = connection.BeginTransaction(_capPublisher))
                {
                    // This is where you would do other work that is going to persist data to your database
                    await _capPublisher.PublishAsync("helloWorld", "CodeOpinion");        
                    await transaction.CommitAsync();
                }
            }
            
            return View();
        }
    }
}