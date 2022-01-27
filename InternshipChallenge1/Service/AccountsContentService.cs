using InternshipChallenge1.Data;
using InternshipChallenge1.IService;
using InternshipChallenge1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipChallenge1.Service
{
    public class AccountsContentService : IAccountsContentService
    {
        private readonly ApplicationDbContext _context;

        public AccountsContentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public AccountsContent GetSavedAccountsContent()
        {
            return _context.AccountsContents.SingleOrDefault();
        }

        public AccountsContent Save(AccountsContent oAccountsContent)
        {
            _context.AccountsContents.Add(oAccountsContent);
            _context.SaveChanges();
            return oAccountsContent;
        }
    }
}
