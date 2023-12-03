using ASPCoreApplication2023.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreApplication2023.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GenreController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
