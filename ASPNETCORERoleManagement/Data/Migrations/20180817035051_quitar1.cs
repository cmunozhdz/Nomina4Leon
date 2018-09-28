using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class quitar1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "Personal_agregarVM");

            migrationBuilder.DropColumn(
                name: "Titl2",
                table: "Personal_agregarVM");

            migrationBuilder.RenameColumn(
                name: "Cod_post",
                table: "Personal_agregarVM",
                newName: "Cod_post");

            migrationBuilder.AlterColumn<string>(
                name: "Prbeh",
                table: "Personal_agregarVM",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Dia_7",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "Dia_6",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "Dia_5",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "Dia_4",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "Dia_3",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "Dia_2",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "Dia_1",
                table: "Personal_agregarVM",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cod_post",
                table: "Personal_agregarVM",
                newName: "Col_post");

            migrationBuilder.AlterColumn<string>(
                name: "Prbeh",
                table: "Personal_agregarVM",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Dia_7",
                table: "Personal_agregarVM",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "Dia_6",
                table: "Personal_agregarVM",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "Dia_5",
                table: "Personal_agregarVM",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "Dia_4",
                table: "Personal_agregarVM",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "Dia_3",
                table: "Personal_agregarVM",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "Dia_2",
                table: "Personal_agregarVM",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "Dia_1",
                table: "Personal_agregarVM",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "Personal_agregarVM",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Titl2",
                table: "Personal_agregarVM",
                maxLength: 15,
                nullable: true);
        }
    }
}
