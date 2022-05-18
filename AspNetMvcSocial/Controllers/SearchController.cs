using App.Application.Services;
using App.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcSocial.Controllers
{
    [Authorize(Roles = "User")]
    public class SearchController : Controller
    {
        private readonly AppDbContext _db;
        private readonly SearchService _searchService;

        public SearchController(SearchService searchService)
        {
            
            _searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string query)
        {
            return View(await _searchService.Search(query));
        }
    }
}