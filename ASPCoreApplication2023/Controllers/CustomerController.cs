using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPCoreApplication2023.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ASPCoreApplication2023.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public IActionResult Index()
        {
            var customers = _context?.Customers?.Include(c => c.Membership).ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            // Fetch the list of available memberships and pass it to the view
            ViewBag.MembershipList = _context?.Memberships?
                .AsEnumerable()
                .Select((m, index) => new SelectListItem { Value = m.Id.ToString(), Text = $"Membership {index + 1}" })
                .ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,MembershipId")] Customer customer)
        {
            ViewBag.Errors = ModelState.Values
            .SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            if (ModelState.IsValid)
            {
                _context?.Customers?.Add(customer);
                _context?.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Code to handle validation errors if necessary
            // Don't forget to fetch the list of memberships again and pass it to the view
            ViewBag.MembershipList = _context?.Memberships?
                .Select((m, index) => new SelectListItem { Value = m.Id.ToString(), Text = $"Membership {index + 1}" })
                .ToList();
            return View(customer);
        }
    }

}
