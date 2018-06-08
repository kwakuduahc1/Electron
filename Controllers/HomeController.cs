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

        public async Task<IActionResult> Index()
        {
            using (var db = new ApplicationDbContext(context))
            {
                //Make sure the database has been created;
                await db.Database.EnsureCreatedAsync();
            }
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        public async Task<IEnumerable> Locations()
        {
            using (var db = new ApplicationDbContext(context))
            {
                //Apply any pending migrations
                if (db.Database.GetAppliedMigrations().Count() < 1)
                    await db.Database.MigrateAsync();
                return await db.Locations.ToListAsync();
            }
        }
    }
}
