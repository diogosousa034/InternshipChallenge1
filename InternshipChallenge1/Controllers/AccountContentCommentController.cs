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
    public class AccountContentCommentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountContentCommentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int id)
        {
            IEnumerable<AccountContentComment> objList = _db.AccountContentComments.Where(m => m.AccountsContentId == id).ToList();

            return View(objList);
        }

        // GET-Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var acc = await _db.AccountContentComments
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.AccountContentCommentId == id);
            return View(acc);
        }

        // POST-Edit
        [HttpPost]
        public IActionResult Edit(AccountContentComment accs)
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

            var acc = await _db.AccountContentComments
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AccountContentCommentId == id);

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
        public IActionResult Create(AccountContentComment obj)
        {
            _db.AccountContentComments.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
