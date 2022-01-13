using InternshipChallenge1.Data;
using InternshipChallenge1.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Details()
        {
            return View();
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
