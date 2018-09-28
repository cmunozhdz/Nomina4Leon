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
    [Migration("20180810025631_ites")]
    partial class ites
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

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.IT0", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Aedtm");

                    b.Property<DateTime>("BegDa");

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<DateTime>("EndDa");

                    b.Property<int>("Estatus");

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Massg")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Massn")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<int>("Pernr")
                        .HasMaxLength(8);

                    b.Property<int>("Seqnr")
                        .HasMaxLength(3);

                    b.Property<string>("Subty")
                        .HasMaxLength(4);

                    b.Property<string>("Uname")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("IT0s");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.IT1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Aedtm");

                    b.Property<string>("Area_pers")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<DateTime>("BegDa");

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Cent_cost")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Divi")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<DateTime>("EndDa");

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Nomina")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Orgeh")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<int>("Pernr")
                        .HasMaxLength(8);

                    b.Property<string>("Plans")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<int>("Seqnr")
                        .HasMaxLength(3);

                    b.Property<string>("Stell")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("Subdivis")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("Subty")
                        .HasMaxLength(4);

                    b.Property<int>("Tipo_pers");

                    b.Property<string>("Uname")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("IT1s");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.IT16", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Aedtm");

                    b.Property<DateTime>("BegDa");

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Cttyp")
                        .HasMaxLength(2);

                    b.Property<DateTime>("EndDa");

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<int>("Pernr")
                        .HasMaxLength(8);

                    b.Property<string>("Prbeh")
                        .HasMaxLength(3);

                    b.Property<int>("Prbzt")
                        .HasMaxLength(3);

                    b.Property<int>("Seqnr")
                        .HasMaxLength(3);

                    b.Property<string>("Subty")
                        .HasMaxLength(4);

                    b.Property<string>("Uname")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("IT16s");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.IT2_185_105", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Aedtm");

                    b.Property<string>("Afore")
                        .HasMaxLength(30);

                    b.Property<DateTime>("BegDa");

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Cartilla")
                        .HasMaxLength(30);

                    b.Property<string>("Curp")
                        .HasMaxLength(14);

                    b.Property<DateTime>("EndDa");

                    b.Property<string>("Fm2")
                        .HasMaxLength(30);

                    b.Property<string>("Fm3")
                        .HasMaxLength(30);

                    b.Property<DateTime>("GbDat");

                    b.Property<string>("Gbdep")
                        .HasMaxLength(3);

                    b.Property<string>("Gblnd")
                        .HasMaxLength(3);

                    b.Property<string>("Gbort")
                        .HasMaxLength(40);

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Gesch")
                        .HasMaxLength(1);

                    b.Property<string>("Ine")
                        .HasMaxLength(30);

                    b.Property<string>("Issste")
                        .HasMaxLength(30);

                    b.Property<string>("Licencia")
                        .HasMaxLength(30);

                    b.Property<string>("Natio")
                        .HasMaxLength(3);

                    b.Property<string>("Pasaporte")
                        .HasMaxLength(30);

                    b.Property<int>("Pernr")
                        .HasMaxLength(8);

                    b.Property<string>("Rfc")
                        .HasMaxLength(30);

                    b.Property<int>("Seqnr")
                        .HasMaxLength(3);

                    b.Property<string>("Subty")
                        .HasMaxLength(4);

                    b.Property<string>("Titl2")
                        .HasMaxLength(15);

                    b.Property<string>("Title")
                        .HasMaxLength(15);

                    b.Property<string>("Uname")
                        .HasMaxLength(12);

                    b.Property<string>("Usrid1")
                        .HasMaxLength(30);

                    b.Property<string>("Usrid2")
                        .HasMaxLength(30);

                    b.Property<string>("Usrid3")
                        .HasMaxLength(30);

                    b.Property<string>("Usrid4")
                        .HasMaxLength(30);

                    b.Property<string>("Usrty1")
                        .HasMaxLength(4);

                    b.Property<string>("Usrty2")
                        .HasMaxLength(4);

                    b.Property<string>("Usrty3")
                        .HasMaxLength(4);

                    b.Property<string>("Usrty4")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("IT2_185_105s");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.IT21", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Aedtm");

                    b.Property<DateTime>("BegDa");

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<DateTime>("EndDa");

                    b.Property<string>("Famsa")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("Fanam")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Fanat")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("Fasex")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Favor")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("Fgbdt");

                    b.Property<string>("Fgbld")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("Fgbot")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Fgdep")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("Fnac2")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<int>("Pernr")
                        .HasMaxLength(8);

                    b.Property<int>("Seqnr")
                        .HasMaxLength(3);

                    b.Property<string>("Subty")
                        .HasMaxLength(4);

                    b.Property<string>("Uname")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("IT21s");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.IT369", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Aedtm");

                    b.Property<DateTime>("BegDa");

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<DateTime>("EndDa");

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Ijred")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Nimss")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<int>("Pernr")
                        .HasMaxLength(8);

                    b.Property<string>("Rimss")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<int>("Seqnr")
                        .HasMaxLength(3);

                    b.Property<string>("Subty")
                        .HasMaxLength(4);

                    b.Property<string>("Uname")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("IT369s");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.IT41", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Aedtm");

                    b.Property<DateTime>("BegDa");

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Dar01")
                        .HasMaxLength(2);

                    b.Property<DateTime>("Dat01");

                    b.Property<DateTime>("EndDa");

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<int>("Pernr")
                        .HasMaxLength(8);

                    b.Property<int>("Seqnr")
                        .HasMaxLength(3);

                    b.Property<string>("Subty")
                        .HasMaxLength(4);

                    b.Property<string>("Uname")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("IT41s");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.IT7", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Aedtm");

                    b.Property<DateTime>("BegDa");

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<int>("Dia_1")
                        .HasMaxLength(1);

                    b.Property<int>("Dia_2")
                        .HasMaxLength(1);

                    b.Property<int>("Dia_3")
                        .HasMaxLength(1);

                    b.Property<int>("Dia_4")
                        .HasMaxLength(1);

                    b.Property<int>("Dia_5")
                        .HasMaxLength(1);

                    b.Property<int>("Dia_6")
                        .HasMaxLength(1);

                    b.Property<int>("Dia_7")
                        .HasMaxLength(1);

                    b.Property<DateTime>("EndDa");

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<TimeSpan>("Hr_Entrada");

                    b.Property<TimeSpan>("Hr_Pausa1");

                    b.Property<TimeSpan>("Hr_Pausa2");

                    b.Property<TimeSpan>("Hr_Salida");

                    b.Property<double>("Hrs_Trab");

                    b.Property<int>("Pernr")
                        .HasMaxLength(8);

                    b.Property<int>("Seqnr")
                        .HasMaxLength(3);

                    b.Property<string>("Subty")
                        .HasMaxLength(4);

                    b.Property<string>("Uname")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("IT7s");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.IT8", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Aedtm");

                    b.Property<DateTime>("BegDa");

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<DateTime>("EndDa");

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<int>("Pernr")
                        .HasMaxLength(8);

                    b.Property<double>("Sdo_hora");

                    b.Property<int>("Seqnr")
                        .HasMaxLength(3);

                    b.Property<string>("Subty")
                        .HasMaxLength(4);

                    b.Property<double>("Sueldo_dia");

                    b.Property<double>("Sueldo_mens");

                    b.Property<string>("Uname")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("IT8s");
                });

            modelBuilder.Entity("ASPNETCORERoleManagement.Models.IT9", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Aedtm");

                    b.Property<int>("Banco");

                    b.Property<DateTime>("BegDa");

                    b.Property<string>("Bukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Clabe_banco")
                        .HasMaxLength(20);

                    b.Property<int>("Cuenta");

                    b.Property<DateTime>("EndDa");

                    b.Property<string>("Estado")
                        .HasMaxLength(3);

                    b.Property<string>("Gbukrs")
                        .HasMaxLength(4);

                    b.Property<string>("Pais")
                        .HasMaxLength(3);

                    b.Property<int>("Pernr")
                        .HasMaxLength(8);

                    b.Property<string>("Plaza_cta")
                        .HasMaxLength(30);

                    b.Property<int>("Seqnr")
                        .HasMaxLength(3);

                    b.Property<string>("Subty")
                        .HasMaxLength(4);

                    b.Property<string>("Tipo_pago")
                        .HasMaxLength(1);

                    b.Property<string>("Uname")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("IT9s");
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
