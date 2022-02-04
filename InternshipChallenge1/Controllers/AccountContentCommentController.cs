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
        public async Task<IActionResult> Edit(AccountContentCommentDto model, int id)
        {

            var dbComment = await _db.AccountContentComments
                .Where(c => c.AccountsContentId == id)
                .FirstOrDefaultAsync(m => m.AccountContentCommentId == model.AccountContentCommentId);

            dbComment.Message = model.Message;
            dbComment.AccountsContentId = model.AccountsContentId;

            var result = await _db.SaveChangesAsync();

            if (result < 1)
                return BadRequest();

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
        public async Task<IActionResult> Create(AccountContentCommentDto model, int id)
        {
            var dbComment = new AccountContentComment()
            {
                Message = model.Message,
                AccountsContentId = model.AccountsContentId,
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
