using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InternshipChallenge1.Models.AccountsDb;

namespace InternshipChallenge1.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountsContent> AccountsContents { get; set; }
        public DbSet<AccountContentComment> AccountContentComments { get; set; }
    }
}
