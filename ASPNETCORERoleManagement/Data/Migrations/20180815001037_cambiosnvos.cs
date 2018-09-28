using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class cambiosnvos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cname",
                table: "Personals");

            migrationBuilder.CreateTable(
                name: "Personal_agregarVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Afore = table.Column<string>(maxLength: 30, nullable: true),
                    Area_pers = table.Column<string>(maxLength: 2, nullable: false),
                    Banco = table.Column<int>(nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Cent_cost = table.Column<string>(maxLength: 10, nullable: false),
                    Clabe_banco = table.Column<string>(maxLength: 20, nullable: true),
                    Col_post = table.Column<string>(maxLength: 5, nullable: true),
                    Colonia = table.Column<string>(maxLength: 40, nullable: true),
                    Cttyp = table.Column<string>(maxLength: 2, nullable: true),
                    Cuenta = table.Column<int>(nullable: false),
                    Curp = table.Column<string>(maxLength: 14, nullable: true),
                    Dia_1 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_2 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_3 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_4 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_5 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_6 = table.Column<int>(maxLength: 1, nullable: false),
                    Dia_7 = table.Column<int>(maxLength: 1, nullable: false),
                    Divi = table.Column<string>(maxLength: 4, nullable: false),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(maxLength: 3, nullable: true),
                    Estado1 = table.Column<string>(maxLength: 3, nullable: true),
                    Estatus = table.Column<int>(nullable: false),
                    GbDat = table.Column<DateTime>(nullable: false),
                    Gbdep = table.Column<string>(maxLength: 3, nullable: true),
                    Gblnd = table.Column<string>(maxLength: 3, nullable: true),
                    Gbort = table.Column<string>(maxLength: 40, nullable: true),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Gesch = table.Column<string>(maxLength: 1, nullable: true),
                    Hr_Entrada = table.Column<TimeSpan>(nullable: false),
                    Hr_Pausa1 = table.Column<TimeSpan>(nullable: false),
                    Hr_Pausa2 = table.Column<TimeSpan>(nullable: false),
                    Hr_Salida = table.Column<TimeSpan>(nullable: false),
                    Hrs_Trab = table.Column<double>(nullable: false),
                    IdMassg = table.Column<string>(nullable: false),
                    Ine = table.Column<string>(maxLength: 30, nullable: true),
                    Issste = table.Column<string>(maxLength: 30, nullable: true),
                    Land1 = table.Column<string>(maxLength: 3, nullable: true),
                    Licencia = table.Column<string>(maxLength: 30, nullable: true),
                    Munic = table.Column<string>(maxLength: 4, nullable: true),
                    Nach2 = table.Column<string>(maxLength: 40, nullable: true),
                    Nachn = table.Column<string>(maxLength: 40, nullable: true),
                    Natio = table.Column<string>(maxLength: 3, nullable: true),
                    Nomina = table.Column<string>(maxLength: 2, nullable: false),
                    Orgeh = table.Column<string>(maxLength: 8, nullable: false),
                    Pais = table.Column<string>(maxLength: 3, nullable: true),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    PersonalId = table.Column<int>(nullable: false),
                    Plans = table.Column<string>(maxLength: 8, nullable: false),
                    Plaza_cta = table.Column<string>(maxLength: 30, nullable: true),
                    Poblac = table.Column<string>(maxLength: 40, nullable: true),
                    Prbeh = table.Column<string>(maxLength: 3, nullable: true),
                    Prbzt = table.Column<int>(maxLength: 3, nullable: false),
                    Rfc = table.Column<string>(maxLength: 30, nullable: true),
                    Sdo_hora = table.Column<double>(nullable: false),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Stell = table.Column<string>(maxLength: 8, nullable: false),
                    Stras = table.Column<string>(maxLength: 60, nullable: true),
                    Subdivis = table.Column<string>(maxLength: 4, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Sueldo_dia = table.Column<double>(nullable: false),
                    Sueldo_mens = table.Column<double>(nullable: false),
                    Telnr = table.Column<int>(maxLength: 14, nullable: false),
                    Tipo_pago = table.Column<string>(maxLength: 1, nullable: true),
                    Tipo_pers = table.Column<int>(nullable: false),
                    Titl2 = table.Column<string>(maxLength: 15, nullable: true),
                    Title = table.Column<string>(maxLength: 15, nullable: true),
                    Usrid1 = table.Column<string>(maxLength: 30, nullable: true),
                    Usrty1 = table.Column<string>(maxLength: 4, nullable: true),
                    Vorna = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal_agregarVM", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personal_agregarVM");

            migrationBuilder.AddColumn<string>(
                name: "Cname",
                table: "Personals",
                maxLength: 80,
                nullable: true);
        }
    }
}
