using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class nombrecompleto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estatus2",
                table: "Personal_agregarVM");

            migrationBuilder.AddColumn<string>(
                name: "Cname",
                table: "Personals",
                maxLength: 80,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cname",
                table: "Personals");

            migrationBuilder.AddColumn<string>(
                name: "Estatus2",
                table: "Personal_agregarVM",
                nullable: false,
                defaultValue: "");
        }
    }
}
