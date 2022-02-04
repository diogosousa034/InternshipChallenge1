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
using InternshipChallenge1.Dto;

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


        public async Task<IActionResult> Index(int id)
        {
            var contents = await _db.AccountsContents
                .AsNoTracking()
                .Where(c => c.AccountId == id)         
                .Select(x => new AccountsContentDto()
                {
                    AccountsContentId = x.AccountsContentId,
                    Image = x.Image,
                    PublicationData = x.PublicationData,
                    AccountId = x.AccountId,
                }).ToListAsync();

            return View(contents);
        }

        // GET-Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var acc = await _db.AccountsContents
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.AccountsContentId == id);

            var dto = new AccountsContentDto()
            {
                AccountsContentId = acc.AccountsContentId,
                Image = acc.Image,
                PublicationData = acc.PublicationData,
                AccountId = acc.AccountId,
            };

            return View(acc);
        }

        // POST-Edit
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile files, int id, AccountsContentDto model)
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
                        AccountsContentId = model.AccountsContentId,
                        PublicationData = DateTime.Now,
                        AccountId = id
                        
                    };
                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objFiles.Image = target.ToArray();
                    }

                    var acc = await _db.AccountsContents
                    //.Where(a =>a.AccountId == id)
                    .FirstOrDefaultAsync(m => m.AccountsContentId == model.AccountsContentId);

                    acc.Image = model.Image;
                    acc.PublicationData = model.PublicationData;
                    acc.AccountId = model.AccountId;


                    objFiles.AccountId = acc.AccountId;

                    var result = await _db.SaveChangesAsync();

                    if (result < 1)
                        return BadRequest();

                    //_db.Attach(objFiles);
                    //_db.Entry(objFiles).State = EntityState.Modified;
                    //_db.SaveChanges();
                }
            }
            //_db.Attach(accs);
            //_db.Entry(accs).State = EntityState.Modified;
            //_db.SaveChanges();
            return RedirectToAction("Index");
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
        public async Task<IActionResult> Create(IFormFile files, int id, AccountsContentDto model)
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
                    .FirstOrDefaultAsync(m => m.AccountsContentId == id);

                    acc.AccountsContentId = model.AccountsContentId;
                    acc.Image = model.Image;
                    acc.PublicationData = model.PublicationData;
                    acc.AccountId = model.AccountId;


                    objFiles.AccountId = acc.AccountId;

                    var result = await _db.SaveChangesAsync();

                    if (result < 1)
                        return BadRequest();

                    //_db.Attach(objFiles);
                    //_db.Entry(objFiles).State = EntityState.Modified;
                    //_db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

    }
}

