using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class codp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Col_post",
                table: "IT6",
                newName: "Cod_post");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo_pago",
                table: "Personal_agregarVM",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Stell",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Plans",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Orgeh",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Nomina",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Munic",
                table: "Personal_agregarVM",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gesch",
                table: "Personal_agregarVM",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gbdep",
                table: "Personal_agregarVM",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Personal_agregarVM",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cttyp",
                table: "Personal_agregarVM",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cent_cost",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Area_pers",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cod_post",
                table: "IT6",
                newName: "Col_post");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo_pago",
                table: "Personal_agregarVM",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Stell",
                table: "Personal_agregarVM",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Plans",
                table: "Personal_agregarVM",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Orgeh",
                table: "Personal_agregarVM",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nomina",
                table: "Personal_agregarVM",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Munic",
                table: "Personal_agregarVM",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gesch",
                table: "Personal_agregarVM",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gbdep",
                table: "Personal_agregarVM",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Personal_agregarVM",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cttyp",
                table: "Personal_agregarVM",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cent_cost",
                table: "Personal_agregarVM",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Area_pers",
                table: "Personal_agregarVM",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
