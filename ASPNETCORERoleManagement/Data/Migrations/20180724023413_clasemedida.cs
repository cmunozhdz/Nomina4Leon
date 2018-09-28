using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class clasemedida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Massg",
                table: "ClasedeMedida",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Massg",
                table: "ClasedeMedida",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 3);
        }
    }
}
