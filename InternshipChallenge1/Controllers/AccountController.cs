using InternshipChallenge1.Data;
using InternshipChallenge1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipChallenge1.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Account> objList = _db.Accounts.ToList();       

            return View(objList);
        }


        // Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var acc = await _db.Accounts
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.Id == id);
            return View(acc);
        }


        [HttpPost]
        public IActionResult Edit(Account accs)
        {
            _db.Attach(accs);
            _db.Entry(accs).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Get-Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var acc = await _db.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            return View(acc);
        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account obj)
        {
            _db.Accounts.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
