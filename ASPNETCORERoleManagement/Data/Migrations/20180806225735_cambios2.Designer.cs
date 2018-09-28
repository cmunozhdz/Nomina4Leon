﻿// <auto-generated />
using ASPNETCORERoleManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180806225735_cambios2")]
    partial class cambios2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.AreaPers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Area_pers")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Bukrs")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("Descrip")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Gbukrs")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<int>("Tipo_pers");

                    b.HasKey("Id");

                    b.ToTable("AreaPers");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.Cat1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Calle_num")
                        .HasMaxLength(30);

                    b.Property<string>("Cod_post")
                        .HasMaxLength(5);

                    b.Property<string>("Colonia")
                        .HasMaxLength(40);

                    b.Property<string>("Correo_resp")
                        .IsRequired();

                    b.Property<string>("Estado")
                        .HasMaxLength(3);

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Munic")
                        .HasMaxLength(4);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Nombre_largo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nombre_resp")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Num_edif")
                        .HasMaxLength(15);

                    b.Property<string>("Of_schp")
                        .HasMaxLength(20);

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Poblac")
                        .HasMaxLength(40);

                    b.Property<string>("Rfc")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Skype_resp")
                        .HasMaxLength(20);

                    b.Property<string>("Tel_cel_respo")
                        .HasMaxLength(10);

                    b.Property<string>("Telefono")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Cat1");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.CentrodeCostos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Cent_cost")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Descrip")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("CentrodeCostos");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.ClasedeMedida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Massg")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Massg_desc")
                        .HasMaxLength(15);

                    b.Property<string>("Massn")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Massn_desc")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("Gbukrs", "Bukrs", "Massg", "Massn")
                        .IsUnique();

                    b.ToTable("ClasedeMedida");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.Divis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Descrip")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Divi")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("Divis");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.Estatus_stat2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("Estatus");

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("Estatus_Stat2");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.MenuMaster", b =>
                {
                    b.Property<int>("MenuIdentity")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("MenuFileName");

                    b.Property<string>("MenuID");

                    b.Property<string>("MenuName");

                    b.Property<string>("MenuURL");

                    b.Property<string>("Parent_MenuID");

                    b.Property<string>("USE_YN");

                    b.Property<string>("User_Roll");

                    b.HasKey("MenuIdentity");

                    b.ToTable("MenuMaster");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.Municipio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("descripcion")
                        .HasMaxLength(50);

                    b.Property<string>("mpio")
                        .HasMaxLength(4);

                    b.Property<string>("region");

                    b.HasKey("id");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.Region1", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nombre")
                        .HasMaxLength(50);

                    b.Property<string>("rg")
                        .HasMaxLength(3);

                    b.HasKey("id");

                    b.ToTable("Region1");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.Subdivision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Descrip")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Divi")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Subdivis")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("Subdivision");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.TipodeNomina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Descrip")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Nomina")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Tipo_nom")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("TipodeNomina");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.TipoPersonal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Descrip")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<int>("Tipo_pers");

                    b.HasKey("Id");

                    b.ToTable("TipoPersonal");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ASPNETCORERoleManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ASPNETCORERoleManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ASPNETCORERoleManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ASPNETCORERoleManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
