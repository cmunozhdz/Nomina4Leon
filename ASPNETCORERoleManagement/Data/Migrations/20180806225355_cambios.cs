using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class cambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nomina",
                table: "TipodeNomina",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Subdivis",
                table: "Subdivision",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Divi",
                table: "Subdivision",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Divi",
                table: "Divis",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Massn",
                table: "ClasedeMedida",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Massg",
                table: "ClasedeMedida",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Cent_cost",
                table: "CentrodeCostos",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Gbukrs",
                table: "AreaPers",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bukrs",
                table: "AreaPers",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Area_pers",
                table: "AreaPers",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nomina",
                table: "TipodeNomina",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Subdivis",
                table: "Subdivision",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Divi",
                table: "Subdivision",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Divi",
                table: "Divis",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Massn",
                table: "ClasedeMedida",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Massg",
                table: "ClasedeMedida",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Cent_cost",
                table: "CentrodeCostos",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Gbukrs",
                table: "AreaPers",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Bukrs",
                table: "AreaPers",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Area_pers",
                table: "AreaPers",
                 nullable: false,
                oldClrType: typeof(string));
        }
    }
}
