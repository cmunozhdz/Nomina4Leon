using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class otraclasedemedidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClasedeMedida_Gbukrs_Bukrs_Massg_Massn",
                table: "ClasedeMedida");

            migrationBuilder.DropColumn(
                name: "Massg_desc2",
                table: "ClasedeMedida");

            migrationBuilder.CreateIndex(
                name: "IX_ClasedeMedida_Gbukrs_Bukrs_Massg_Massn",
                table: "ClasedeMedida",
                columns: new[] { "Gbukrs", "Bukrs", "Massg", "Massn" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClasedeMedida_Gbukrs_Bukrs_Massg_Massn",
                table: "ClasedeMedida");

            migrationBuilder.AddColumn<string>(
                name: "Massg_desc2",
                table: "ClasedeMedida",
                maxLength: 15,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClasedeMedida_Gbukrs_Bukrs_Massg_Massn",
                table: "ClasedeMedida",
                columns: new[] { "Gbukrs", "Bukrs", "Massg", "Massn" });
        }
    }
}
