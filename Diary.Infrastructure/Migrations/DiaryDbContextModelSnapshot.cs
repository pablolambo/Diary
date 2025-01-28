﻿// <auto-generated />
using System;
using Diary.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Diary.Infrastructure.Migrations
{
    [DbContext(typeof(DiaryDbContext))]
    partial class DiaryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Diary.Domain.Entities.BadgeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaryUserEntityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiaryUserEntityId");

                    b.ToTable("Badges");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2b7783f6-776d-4522-bd8f-713cacba018d"),
                            Name = "Your first entry",
                            Type = 1,
                            Value = 1
                        },
                        new
                        {
                            Id = new Guid("4a7b35e9-7d11-4725-a1ab-da40087e20d0"),
                            Name = "3 day streak",
                            Type = 0,
                            Value = 3
                        },
                        new
                        {
                            Id = new Guid("9fba1ab2-4948-43ab-b6b2-b1f5d09ed7ad"),
                            Name = "5 day streak",
                            Type = 0,
                            Value = 5
                        },
                        new
                        {
                            Id = new Guid("b245c56a-1646-40b9-999e-181269751833"),
                            Name = "7 day streak",
                            Type = 0,
                            Value = 7
                        },
                        new
                        {
                            Id = new Guid("f92eb28e-cae3-4b2f-896c-3afb9f82e31d"),
                            Name = "10 total entries",
                            Type = 1,
                            Value = 10
                        },
                        new
                        {
                            Id = new Guid("51d2e6dc-c587-4367-8f4a-98b16df5b6da"),
                            Name = "25 total entries",
                            Type = 1,
                            Value = 25
                        },
                        new
                        {
                            Id = new Guid("669ae0a1-06ee-4adc-9682-7c19ee4df6c1"),
                            Name = "50 total entries",
                            Type = 1,
                            Value = 50
                        });
                });

            modelBuilder.Entity("Diary.Domain.Entities.DiaryUserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDailyReminderEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Diary.Domain.Entities.EntryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFavourite")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("Diary.Domain.Entities.TagEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaryUserEntityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("EntryEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DiaryUserEntityId");

                    b.HasIndex("EntryEntityId");

                    b.HasIndex("UserId", "Name")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Diary.Domain.Entities.ThemeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("DiaryUserEntityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PrimaryColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiaryUserEntityId");

                    b.ToTable("Themes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("97c76c90-4ecc-4caf-b487-1f07c49f88cf"),
                            Cost = 100,
                            PrimaryColor = "Blue",
                            SecondaryColor = "LightBlue"
                        },
                        new
                        {
                            Id = new Guid("0b273dfc-9075-432b-a369-2eb9940e49d9"),
                            Cost = 250,
                            PrimaryColor = "Red",
                            SecondaryColor = "DarkRed"
                        },
                        new
                        {
                            Id = new Guid("73fe338d-5f76-494e-a7b3-84baa5c17a5b"),
                            Cost = 500,
                            PrimaryColor = "Green",
                            SecondaryColor = "DarkGreen"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Diary.Domain.Entities.BadgeEntity", b =>
                {
                    b.HasOne("Diary.Domain.Entities.DiaryUserEntity", null)
                        .WithMany("UnlockedBadges")
                        .HasForeignKey("DiaryUserEntityId");
                });

            modelBuilder.Entity("Diary.Domain.Entities.DiaryUserEntity", b =>
                {
                    b.OwnsOne("Diary.Domain.Entities.UserStatisticsEntity", "Statistics", b1 =>
                        {
                            b1.Property<string>("DiaryUserEntityId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<double>("AverageEntriesPerWeek")
                                .HasColumnType("float");

                            b1.Property<int>("CurrentDayStreak")
                                .HasColumnType("int");

                            b1.Property<int>("FavoriteEntries")
                                .HasColumnType("int");

                            b1.Property<DateTime?>("FirstEntryDate")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime?>("LastEntryDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("MostUsedTags")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Points")
                                .HasColumnType("int");

                            b1.Property<int>("TotalEntries")
                                .HasColumnType("int");

                            b1.HasKey("DiaryUserEntityId");

                            b1.ToTable("AspNetUsers");

                            b1.WithOwner()
                                .HasForeignKey("DiaryUserEntityId");
                        });

                    b.Navigation("Statistics")
                        .IsRequired();
                });

            modelBuilder.Entity("Diary.Domain.Entities.TagEntity", b =>
                {
                    b.HasOne("Diary.Domain.Entities.DiaryUserEntity", null)
                        .WithMany("EntryTags")
                        .HasForeignKey("DiaryUserEntityId");

                    b.HasOne("Diary.Domain.Entities.EntryEntity", null)
                        .WithMany("EntryTags")
                        .HasForeignKey("EntryEntityId");
                });

            modelBuilder.Entity("Diary.Domain.Entities.ThemeEntity", b =>
                {
                    b.HasOne("Diary.Domain.Entities.DiaryUserEntity", null)
                        .WithMany("UnlockedThemes")
                        .HasForeignKey("DiaryUserEntityId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Diary.Domain.Entities.DiaryUserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Diary.Domain.Entities.DiaryUserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diary.Domain.Entities.DiaryUserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Diary.Domain.Entities.DiaryUserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diary.Domain.Entities.DiaryUserEntity", b =>
                {
                    b.Navigation("EntryTags");

                    b.Navigation("UnlockedBadges");

                    b.Navigation("UnlockedThemes");
                });

            modelBuilder.Entity("Diary.Domain.Entities.EntryEntity", b =>
                {
                    b.Navigation("EntryTags");
                });
#pragma warning restore 612, 618
        }
    }
}
