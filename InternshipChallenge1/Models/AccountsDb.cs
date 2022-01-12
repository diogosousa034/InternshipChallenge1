using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipChallenge1.Models
{
    public class AccountsDb
    {
        public class AccountContentComment
        {
            public int AccountContentCommentId { get; set; }
            public string Message { get; set; }

            public int AccountsContentId { get; set; }
            public AccountsContent AccountsContent { get; set; }
        }

        public class AccountsContent
        {
            public int AccountsContentId { get; set; }
            public byte[] Image { get; set; }
            public DateTime PublicationData { get; set; }

            public int AccountId { get; set; }
            public Account Account { get; set; }

            public IList<AccountContentComment> AccountContentComments { get; set; }
        }

        public class Account
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
            public int NrFollowers { get; set; }
            public int NrFollowing { get; set; }

            public IList<AccountsContent> AccountsContents { get; set; }
        }

        public class AccountsContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-0U772O3\SQLEXPRESS;Database=AccountsDb;Trusted_Connection=True;");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //Write Fluent API configurations here

                //Property Configurations
                modelBuilder.Entity<Account>()
                        .HasKey(o => o.Id);
                modelBuilder.Entity<Account>()
                    .Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                modelBuilder.Entity<AccountsContent>()
                        .HasKey(o => o.AccountsContentId);
                modelBuilder.Entity<AccountsContent>()
                    .Property(e => e.AccountsContentId)
                    .ValueGeneratedOnAdd();

                modelBuilder.Entity<AccountContentComment>()
                        .HasKey(o => o.AccountContentCommentId);
                modelBuilder.Entity<AccountContentComment>()
                    .Property(e => e.AccountContentCommentId)
                    .ValueGeneratedOnAdd();



                modelBuilder.Entity<AccountsContent>()
                .HasOne<Account>(s => s.Account)
                .WithMany(g => g.AccountsContents)
                .HasForeignKey(s => s.AccountsContentId)
                .OnDelete(DeleteBehavior.Restrict);


                modelBuilder.Entity<AccountContentComment>()
               .HasOne<AccountsContent>(s => s.AccountsContent)
               .WithMany(g => g.AccountContentComments)
               .HasForeignKey(s => s.AccountContentCommentId)
               .OnDelete(DeleteBehavior.Restrict);



            }
            public DbSet<Account> Account { get; set; }
            public DbSet<AccountsContent> AccountsContents { get; set; }
            public DbSet<AccountContentComment> AccountContentComments { get; set; }
        }
    }
}
