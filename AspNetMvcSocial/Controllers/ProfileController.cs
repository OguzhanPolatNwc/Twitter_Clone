using App.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcSocial.Controllers
{
    [Authorize(Roles = "User")]
    public class ProfileController : Controller
    {
        private readonly AppDbContext _db;

        public ProfileController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string name)
        {
            var user = _db.Users.FirstOrDefault(x => x.UserName == name);

            ViewBag.Name = name;

            return View(user);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}