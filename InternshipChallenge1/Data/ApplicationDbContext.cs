using InternshipChallenge1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipChallenge1.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

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

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountsContent> AccountsContents { get; set; }
        public DbSet<AccountContentComment> AccountContentComments { get; set; }
    }
}
