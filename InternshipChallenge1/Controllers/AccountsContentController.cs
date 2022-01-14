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
    public class AccountsContentController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AccountsContentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int id)
        {
            IEnumerable<AccountsContent> objList = _db.AccountsContents.ToList();

            return View(objList);
        }
    }
}
