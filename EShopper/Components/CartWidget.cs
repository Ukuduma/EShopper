using EShopper.Data;
using EShopper.Infrastructure;
using EShopper.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Components
{
    public class CartWidget:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(HttpContext.Session.GetJson<Cart>("cart"));
        }
    }
}
