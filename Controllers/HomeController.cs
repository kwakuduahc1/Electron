using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Electron.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Electron.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> context;

        public HomeController(DbContextOptions<ApplicationDbContext> dbContextOptions) => context = dbContextOptions;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        public async Task<IEnumerable> Locations()
        {
            //Since the Index method is called way earlier that other methods, it would be a good place to ensure the database has been created
            //Bad idea. Context appeared to be called too early
            using (var db = new ApplicationDbContext(context))
            {
                //Make sure the database has been created;
                await db.Database.EnsureCreatedAsync();

                //Apply any pending migrations
                await db.Database.MigrateAsync();
                return await db.Locations.ToListAsync();
            }
        }
    }
}
