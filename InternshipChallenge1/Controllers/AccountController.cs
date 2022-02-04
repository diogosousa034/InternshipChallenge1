using InternshipChallenge1.Data;
using InternshipChallenge1.Dto;
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

        public async Task<IActionResult> Index()
        {
            var accounts = await _db.Accounts
                .AsNoTracking()
                .ToListAsync();

            var objList = accounts.Select(x => new AccountDto()
            {
                Id = x.Id,
                FullName = x.FullName,
                NrFollowers = x.NrFollowers,
                NrFollowing = x.NrFollowing,
                UserName = x.UserName
            }).ToList();

            return View(objList);
        }


        // GET-Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dbAccount = await _db.Accounts
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.Id == id);

            var dto = new AccountDto()
            {
                Id = dbAccount.Id,
                FullName = dbAccount.FullName,
                UserName = dbAccount.UserName,
                NrFollowers = dbAccount.NrFollowers,
                NrFollowing = dbAccount.NrFollowing
            };

            return View(dto);
        }

        // POST-Edit
        [HttpPost]
        public async Task<IActionResult> Edit(AccountDto model)
        {

            var dbAccount = await _db.Accounts
                .FirstOrDefaultAsync(m => m.Id == model.Id);

            dbAccount.UserName = model.UserName;
            dbAccount.FullName = model.FullName;    
            dbAccount.NrFollowers = model.NrFollowers;
            dbAccount.NrFollowing = model.NrFollowing;

            var result = await _db.SaveChangesAsync();

            if (result < 1)
                return BadRequest();

            return RedirectToAction("Index");
        }


        // Get-Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

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
        public async Task<IActionResult> Create(AccountDto model)
        {
            var dbAccout = new Account()
            {
                FullName = model.FullName,
                NrFollowers = model.NrFollowers,
                NrFollowing = model.NrFollowing,
                UserName = model.UserName
            };

            _db.Accounts.Add(dbAccout);
            
            var result = await _db.SaveChangesAsync();

            if (result < 1)
                return BadRequest();

            return RedirectToAction("Index");
        }
    }
}
