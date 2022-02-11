using InternshipChallenge1.Data;
using InternshipChallenge1.Dto;
using InternshipChallenge1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //IEnumerable<AccountContentComment> objList = _db.AccountContentComments.Where(m => m.AccountsContentId == id).ToList();

            var comments = await _db.AccountContentComments
                .AsNoTracking()
                .Where(c => c.AccountsContentId == id)
                .Select(x => new AccountContentCommentDto()
                {
                    AccountContentCommentId = x.AccountContentCommentId,
                    Message = x.Message,
                    AccountsContentId = x.AccountsContentId,
                }).ToListAsync();


            ViewBag.ContentId = id;
            return View(comments);
        }

        // GET-Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var acc = await _db.AccountContentComments
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.AccountContentCommentId == id);

            var dto = new AccountContentCommentDto()
            {
                AccountContentCommentId = acc.AccountContentCommentId,
                Message = acc.Message,
                AccountsContentId = acc.AccountsContentId,
            };

            return View(dto);
        }

        // POST-Edit
        [HttpPost]
        public async Task<IActionResult> Edit(AccountContentCommentDto model)
        {

            var dbComment = await _db.AccountContentComments
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AccountContentCommentId == model.AccountContentCommentId);

            var obj = new AccountContentComment()
            {
                AccountContentCommentId = model.AccountContentCommentId,
                Message = model.Message,
                AccountsContentId = dbComment.AccountsContentId,
            };


            _db.Update(obj);
            await _db.SaveChangesAsync();

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
        public IActionResult Create(int id)
        {
            AccountContentCommentDto comment = new AccountContentCommentDto();
            comment.AccountsContentId = id;

            return View(comment);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountContentCommentDto model, int id)
        {
            var dbComment = new AccountContentComment()
            {
                Message = model.Message,
                AccountsContentId = id,
            };

            _db.AccountContentComments.Add(dbComment);

            var result = await _db.SaveChangesAsync();

            if (result < 1)
                return BadRequest();

            //_db.AccountContentComments.Add(obj);
            //_db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
