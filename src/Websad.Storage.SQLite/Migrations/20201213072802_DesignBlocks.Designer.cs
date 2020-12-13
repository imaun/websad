﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Websad.Storage.SQLite;

namespace Websad.Storage.SQLite.Migrations
{
    [DbContext(typeof(SQLiteDbContext))]
    [Migration("20201213072802_DesignBlocks")]
    partial class DesignBlocks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("Websad.Core.Models.Block", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AddedByUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Attributes")
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(300)
                        .IsUnicode(true);

                    b.Property<string>("AuthorEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<int>("BodyType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000)
                        .IsUnicode(true);

                    b.Property<string>("Keywords")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(300)
                        .IsUnicode(true);

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(300)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("ParentId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("Websad.Core.Models.BlockSample", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Attributes")
                        .HasColumnType("TEXT")
                        .IsUnicode(true);

                    b.Property<Guid>("BlockId")
                        .HasColumnType("TEXT");

                    b.Property<int>("BodyType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<bool>("IsDefault")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OutputSrc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(300)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.ToTable("Block_Samples");
                });

            modelBuilder.Entity("Websad.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(500)
                        .IsUnicode(true);

                    b.Property<string>("Lang")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostType")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Lang = "fa",
                            PostType = "page",
                            Slug = "uncategorized",
                            Status = 1,
                            Title = "دسته بندی نشده"
                        });
                });

            modelBuilder.Entity("Websad.Core.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200)
                        .IsUnicode(true);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("Ip")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Message")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000)
                        .IsUnicode(true);

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<int?>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SessionId")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT")
                        .HasMaxLength(3000)
                        .IsUnicode(true);

                    b.Property<string>("UserAgent")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200)
                        .IsUnicode(true);

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Websad.Core.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000)
                        .IsUnicode(true);

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000)
                        .IsUnicode(true);

                    b.Property<int>("FileType")
                        .HasColumnName("FileTypeIndex")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT")
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Websad.Core.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AltTitle")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000)
                        .IsUnicode(true);

                    b.Property<string>("Body")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000)
                        .IsUnicode(true);

                    b.Property<int>("BodyType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Commenting")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CoverPhoto")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000)
                        .IsUnicode(true);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lang")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.Property<string>("MetaDescription")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("MetaRobots")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("PostType")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000)
                        .IsUnicode(true);

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000)
                        .IsUnicode(true);

                    b.Property<string>("Tags")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Websad.Core.Models.PostBlock", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("BlockId")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OutputSrc")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .IsUnicode(true);

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Post_Blocks");
                });

            modelBuilder.Entity("Websad.Core.Models.PostFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("FileId")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("PostId");

                    b.ToTable("Post_Files");
                });

            modelBuilder.Entity("Websad.Core.Models.PostLike", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("IP")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SessionId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Post_Likes");
                });

            modelBuilder.Entity("Websad.Core.Models.PostMeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lang")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.Property<string>("MetaKey")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200)
                        .IsUnicode(true);

                    b.Property<string>("MetaValue")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000)
                        .IsUnicode(true);

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT")
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Post_Meta");
                });

            modelBuilder.Entity("Websad.Core.Models.SiteVisit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AbsoluteUrl")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000)
                        .IsUnicode(true);

                    b.Property<string>("City")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Country")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000)
                        .IsUnicode(true);

                    b.Property<string>("IP")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("OsPlatform")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Region")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("SessionId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<string>("UrlReferrer")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000)
                        .IsUnicode(true);

                    b.Property<string>("UserAgent")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SiteVisits");
                });

            modelBuilder.Entity("Websad.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApiKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("WebUrl")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApiKey = "yfaUCvORbh6a0jFfE0yvCp0pLVDXkGSBPxGKeYBB",
                            Email = "admin@site.com",
                            Enabled = true,
                            LockoutEnabled = false,
                            PasswordHash = "e4uD8ajpPMmqVo5Rs/hL1g==",
                            RegisterDate = new DateTime(2020, 12, 13, 7, 28, 1, 499, DateTimeKind.Utc).AddTicks(3853),
                            Role = "modir",
                            Status = 1,
                            Title = "Admin",
                            Username = "modir"
                        });
                });

            modelBuilder.Entity("Websad.Core.Models.Widget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000)
                        .IsUnicode(true);

                    b.Property<string>("Category")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Lang")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.Property<int>("OrderNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Widgets");
                });

            modelBuilder.Entity("Websad.Core.Models.Block", b =>
                {
                    b.HasOne("Websad.Core.Models.User", "AddedByUser")
                        .WithMany("AddedBlocks")
                        .HasForeignKey("AddedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Websad.Core.Models.Block", "Parent")
                        .WithMany("InnerBlocks")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Websad.Core.Models.BlockSample", b =>
                {
                    b.HasOne("Websad.Core.Models.Block", "Block")
                        .WithMany("Samples")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Websad.Core.Models.Comment", b =>
                {
                    b.HasOne("Websad.Core.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Websad.Core.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Websad.Core.Models.File", b =>
                {
                    b.HasOne("Websad.Core.Models.User", "User")
                        .WithMany("Files")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Websad.Core.Models.Post", b =>
                {
                    b.HasOne("Websad.Core.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Websad.Core.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Websad.Core.Models.PostBlock", b =>
                {
                    b.HasOne("Websad.Core.Models.Block", "Block")
                        .WithMany("PostBlocks")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Websad.Core.Models.Post", "Post")
                        .WithMany("PostBlocks")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Websad.Core.Models.User", "User")
                        .WithMany("AddedPostBlocks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Websad.Core.Models.PostFile", b =>
                {
                    b.HasOne("Websad.Core.Models.File", "File")
                        .WithMany("Posts")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("Websad.Core.Models.Post", "Post")
                        .WithMany("Files")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();
                });

            modelBuilder.Entity("Websad.Core.Models.PostLike", b =>
                {
                    b.HasOne("Websad.Core.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Websad.Core.Models.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Websad.Core.Models.PostMeta", b =>
                {
                    b.HasOne("Websad.Core.Models.Post", "Post")
                        .WithMany("Meta")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}