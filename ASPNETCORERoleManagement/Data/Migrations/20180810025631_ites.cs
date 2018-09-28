using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class ites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IT0s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Estatus = table.Column<int>(nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Massg = table.Column<string>(maxLength: 2, nullable: false),
                    Massn = table.Column<string>(maxLength: 2, nullable: false),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Uname = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT0s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IT16s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Cttyp = table.Column<string>(maxLength: 2, nullable: true),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    Prbeh = table.Column<string>(maxLength: 3, nullable: true),
                    Prbzt = table.Column<int>(maxLength: 3, nullable: false),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Uname = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT16s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IT1s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    Area_pers = table.Column<string>(maxLength: 2, nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Cent_cost = table.Column<string>(maxLength: 10, nullable: false),
                    Divi = table.Column<string>(maxLength: 4, nullable: false),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Nomina = table.Column<string>(maxLength: 2, nullable: false),
                    Orgeh = table.Column<string>(maxLength: 8, nullable: false),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    Plans = table.Column<string>(maxLength: 8, nullable: false),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Stell = table.Column<string>(maxLength: 8, nullable: false),
                    Subdivis = table.Column<string>(maxLength: 4, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Tipo_pers = table.Column<int>(nullable: false),
                    Uname = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IT2_185_105s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    Afore = table.Column<string>(maxLength: 30, nullable: true),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Cartilla = table.Column<string>(maxLength: 30, nullable: true),
                    Curp = table.Column<string>(maxLength: 14, nullable: true),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Fm2 = table.Column<string>(maxLength: 30, nullable: true),
                    Fm3 = table.Column<string>(maxLength: 30, nullable: true),
                    GbDat = table.Column<DateTime>(nullable: false),
                    Gbdep = table.Column<string>(maxLength: 3, nullable: true),
                    Gblnd = table.Column<string>(maxLength: 3, nullable: true),
                    Gbort = table.Column<string>(maxLength: 40, nullable: true),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Gesch = table.Column<string>(maxLength: 1, nullable: true),
                    Ine = table.Column<string>(maxLength: 30, nullable: true),
                    Issste = table.Column<string>(maxLength: 30, nullable: true),
                    Licencia = table.Column<string>(maxLength: 30, nullable: true),
                    Natio = table.Column<string>(maxLength: 3, nullable: true),
                    Pasaporte = table.Column<string>(maxLength: 30, nullable: true),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    Rfc = table.Column<string>(maxLength: 30, nullable: true),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Titl2 = table.Column<string>(maxLength: 15, nullable: true),
                    Title = table.Column<string>(maxLength: 15, nullable: true),
                    Uname = table.Column<string>(maxLength: 12, nullable: true),
                    Usrid1 = table.Column<string>(maxLength: 30, nullable: true),
                    Usrid2 = table.Column<string>(maxLength: 30, nullable: true),
                    Usrid3 = table.Column<string>(maxLength: 30, nullable: true),
                    Usrid4 = table.Column<string>(maxLength: 30, nullable: true),
                    Usrty1 = table.Column<string>(maxLength: 4, nullable: true),
                    Usrty2 = table.Column<string>(maxLength: 4, nullable: true),
                    Usrty3 = table.Column<string>(maxLength: 4, nullable: true),
                    Usrty4 = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT2_185_105s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IT21s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Famsa = table.Column<string>(maxLength: 4, nullable: false),
                    Fanam = table.Column<string>(maxLength: 40, nullable: false),
                    Fanat = table.Column<string>(maxLength: 3, nullable: false),
                    Fasex = table.Column<string>(maxLength: 1, nullable: false),
                    Favor = table.Column<string>(maxLength: 40, nullable: false),
                    Fgbdt = table.Column<DateTime>(nullable: false),
                    Fgbld = table.Column<string>(maxLength: 3, nullable: false),
                    Fgbot = table.Column<string>(maxLength: 40, nullable: false),
                    Fgdep = table.Column<string>(maxLength: 3, nullable: false),
                    Fnac2 = table.Column<string>(maxLength: 40, nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Uname = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT21s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IT369s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Ijred = table.Column<string>(maxLength: 1, nullable: false),
                    Nimss = table.Column<string>(maxLength: 11, nullable: false),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    Rimss = table.Column<string>(maxLength: 1, nullable: false),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Uname = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT369s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IT41s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Dar01 = table.Column<string>(maxLength: 2, nullable: true),
                    Dat01 = table.Column<DateTime>(nullable: false),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Uname = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT41s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IT7s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Dia_1 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_2 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_3 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_4 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_5 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_6 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_7 = table.Column<int>(maxLength: 1, nullable: false),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Hr_Entrada = table.Column<TimeSpan>(nullable: false),
                    Hr_Pausa1 = table.Column<TimeSpan>(nullable: false),
                    Hr_Pausa2 = table.Column<TimeSpan>(nullable: false),
                    Hr_Salida = table.Column<TimeSpan>(nullable: false),
                    Hrs_Trab = table.Column<double>(nullable: false),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Uname = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT7s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IT8s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    Sdo_hora = table.Column<double>(nullable: false),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Sueldo_dia = table.Column<double>(nullable: false),
                    Sueldo_mens = table.Column<double>(nullable: false),
                    Uname = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT8s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IT9s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    Banco = table.Column<int>(nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Clabe_banco = table.Column<string>(maxLength: 20, nullable: true),
                    Cuenta = table.Column<int>(nullable: false),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(maxLength: 3, nullable: true),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Pais = table.Column<string>(maxLength: 3, nullable: true),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    Plaza_cta = table.Column<string>(maxLength: 30, nullable: true),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Tipo_pago = table.Column<string>(maxLength: 1, nullable: true),
                    Uname = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT9s", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IT0s");

            migrationBuilder.DropTable(
                name: "IT16s");

            migrationBuilder.DropTable(
                name: "IT1s");

            migrationBuilder.DropTable(
                name: "IT2_185_105s");

            migrationBuilder.DropTable(
                name: "IT21s");

            migrationBuilder.DropTable(
                name: "IT369s");

            migrationBuilder.DropTable(
                name: "IT41s");

            migrationBuilder.DropTable(
                name: "IT7s");

            migrationBuilder.DropTable(
                name: "IT8s");

            migrationBuilder.DropTable(
                name: "IT9s");
        }
    }
}
