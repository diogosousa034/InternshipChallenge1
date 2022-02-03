using InternshipChallenge1.Data;
using InternshipChallenge1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Web.Helpers;

namespace InternshipChallenge1.Controllers
{
    public class AccountsContentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountsContentController(ApplicationDbContext db)
        {
            _db = db;
        }

        //image file
        public async Task<ActionResult> RenderImage(int id)
        {
            AccountsContent item = await _db.AccountsContents.FindAsync(id);

            byte[] photoBack = item.Image;

            return File(photoBack, "image/png");
        }
        //


        public IActionResult Index(int id)
        {
            IEnumerable<AccountsContent> objList = _db.AccountsContents.Where(m => m.AccountId == id).ToList();

            return View(objList);
        }

        // GET-Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var acc = await _db.AccountsContents
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.AccountsContentId == id);
            return View(acc);
        }

        // POST-Edit
        [HttpPost]
        public async Task<IActionResult> EditAsync(IFormFile files, int id)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    var fileName = Path.GetFileName(files.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                    var objFiles = new AccountsContent()
                    {
                        AccountsContentId = id,
                        PublicationData = DateTime.Now
                    };
                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objFiles.Image = target.ToArray();
                    }

                    var acc = await _db.AccountsContents
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.AccountsContentId == id);

                    objFiles.AccountId = acc.AccountId;

                    _db.Attach(objFiles);
                    _db.Entry(objFiles).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            //_db.Attach(accs);
            //_db.Entry(accs).State = EntityState.Modified;
            //_db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        // Get-Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            var acc = await _db.AccountsContents
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AccountsContentId == id);

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
        public async Task<IActionResult> CreateAsync(AccountsContent obj, int id)
        {

            var acc = await _db.Accounts
                                .Include(m => m.AccountsContents)
                .FirstOrDefaultAsync(m => m.Id == obj.AccountId);

            //acc.AccountsContents.ToList().Add(obj);

            _db.Entry(acc).State = EntityState.Added;

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

