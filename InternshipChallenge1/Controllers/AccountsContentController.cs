﻿using InternshipChallenge1.Data;
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

            ViewBag.AccountId = id;

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

            return View(dto);
        }

        // POST-Edit
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile files, AccountsContentDto model)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    var dbContent = await _db.AccountsContents
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.AccountsContentId == model.AccountsContentId);

                    var fileName = Path.GetFileName(files.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                    var objFiles = new AccountsContent()
                    {
                        AccountsContentId = model.AccountsContentId,
                        PublicationData = DateTime.Now,
                        AccountId = dbContent.AccountId
                    };
                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objFiles.Image = target.ToArray();
                    }

                    _db.Update(objFiles);
                    await _db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }


        // Get-Details
        [HttpGet]
        public async Task<IActionResult> Details(int id, AccountsContentDto model)
        {

            var dbContent = await _db.AccountsContents
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AccountsContentId == id);

            dbContent.Image = model.Image;
            dbContent.PublicationData = model.PublicationData;
            dbContent.AccountId = model.AccountId;

            return View(dbContent);
        }

        // GET-Create
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            AccountsContentDto content = new AccountsContentDto();
            content.AccountId = id;
            
            return View(content);
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
                        AccountsContentId = model.AccountsContentId,
                        PublicationData = DateTime.Now,
                        AccountId = id,
                    };
                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objFiles.Image = target.ToArray();
                    }

                    var dbContent = new AccountsContent()
                    {
                        Image = model.Image,
                        PublicationData = DateTime.Now,
                        AccountId = model.AccountId,
                    };


                    objFiles.AccountsContentId = dbContent.AccountsContentId;

                    _db.AccountsContents.Add(objFiles);

                    var result = await _db.SaveChangesAsync();

                    if (result < 1)
                        return BadRequest();

                }
            }

            return RedirectToAction("Index");
        }

    }
}

