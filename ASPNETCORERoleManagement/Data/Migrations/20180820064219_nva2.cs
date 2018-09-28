using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class nva2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdMassg",
                table: "Personal_agregarVM",
                newName: "IntMassgid");

            migrationBuilder.AddColumn<string>(
                name: "Estatus2",
                table: "Personal_agregarVM",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estatus2",
                table: "Personal_agregarVM");

            migrationBuilder.RenameColumn(
                name: "IntMassgid",
                table: "Personal_agregarVM",
                newName: "IdMassg");
        }
    }
}
