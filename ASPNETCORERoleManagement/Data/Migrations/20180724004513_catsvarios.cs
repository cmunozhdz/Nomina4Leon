using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class catsvarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaPers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Area_pers = table.Column<int>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Descrip = table.Column<string>(maxLength: 20, nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Tipo_pers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaPers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentrodeCostos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Cent_cost = table.Column<int>(maxLength: 15, nullable: false),
                    Descrip = table.Column<string>(maxLength: 25, nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrodeCostos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClasedeMedida",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Massg = table.Column<int>(nullable: false),
                    Massg_desc = table.Column<string>(maxLength: 15, nullable: true),
                    Massn = table.Column<int>(nullable: false),
                    Massn_desc = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasedeMedida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Descrip = table.Column<string>(maxLength: 20, nullable: false),
                    Divi = table.Column<int>(nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subdivision",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Descrip = table.Column<string>(maxLength: 20, nullable: false),
                    Divi = table.Column<int>(nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Subdivis = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivision", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipodeNomina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Descrip = table.Column<string>(maxLength: 20, nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Nomina = table.Column<string>(nullable: false),
                    Tipo_nom = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipodeNomina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPersonal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Descrip = table.Column<string>(maxLength: 20, nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Tipo_pers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersonal", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaPers");

            migrationBuilder.DropTable(
                name: "CentrodeCostos");

            migrationBuilder.DropTable(
                name: "ClasedeMedida");

            migrationBuilder.DropTable(
                name: "Divis");

            migrationBuilder.DropTable(
                name: "Subdivision");

            migrationBuilder.DropTable(
                name: "TipodeNomina");

            migrationBuilder.DropTable(
                name: "TipoPersonal");
        }
    }
}
