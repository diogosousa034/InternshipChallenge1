using InternshipChallenge1.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InternshipChallenge1.Models.AccountsDb;

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
            IEnumerable<Account> objList = _db.Accounts;
            return View(objList);
        }
    }
}
