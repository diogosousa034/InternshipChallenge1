﻿// <auto-generated />
using System;
using InternshipChallenge1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InternshipChallenge1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220126151607_add image")]
    partial class addimage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InternshipChallenge1.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NrFollowers")
                        .HasColumnType("int");

                    b.Property<int>("NrFollowing")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("InternshipChallenge1.Models.AccountContentComment", b =>
                {
                    b.Property<int>("AccountContentCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountsContentId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountContentCommentId");

                    b.ToTable("AccountContentComments");
                });

            modelBuilder.Entity("InternshipChallenge1.Models.AccountsContent", b =>
                {
                    b.Property<int>("AccountsContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("PublicationData")
                        .HasColumnType("datetime2");

                    b.HasKey("AccountsContentId");

                    b.ToTable("AccountsContents");
                });

            modelBuilder.Entity("InternshipChallenge1.Models.AccountContentComment", b =>
                {
                    b.HasOne("InternshipChallenge1.Models.AccountsContent", "AccountsContent")
                        .WithMany("AccountContentComments")
                        .HasForeignKey("AccountContentCommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("InternshipChallenge1.Models.AccountsContent", b =>
                {
                    b.HasOne("InternshipChallenge1.Models.Account", "Account")
                        .WithMany("AccountsContents")
                        .HasForeignKey("AccountsContentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
