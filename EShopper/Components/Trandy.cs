using EShopper.Data;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Components
{
    public class Trandy:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Trandy(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Products.Where(p=>p.isTrandy == true).ToList());
        }
    }
}
