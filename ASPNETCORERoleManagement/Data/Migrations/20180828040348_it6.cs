using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class it6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      

            migrationBuilder.DropPrimaryKey(
                name: "PK_IT6",
                table: "IT6s");

     

            migrationBuilder.RenameIndex(
                name: "IX_IT6_PersonalId",
                table: "IT6s",
                newName: "IX_IT6s_PersonalId");

            migrationBuilder.AlterColumn<string>(
                name: "Uname",
                table: "IT0s",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IT6s",
                table: "IT6s",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IT6s_Personals_PersonalId",
                table: "IT6s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IT6s_Personals_PersonalId",
                table: "IT6s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IT6s",
                table: "IT6s");

         

            migrationBuilder.RenameIndex(
                name: "IX_IT6s_PersonalId",
                table: "IT6s",
                newName: "IX_IT6_PersonalId");

            migrationBuilder.AlterColumn<string>(
                name: "Uname",
                table: "IT0s",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IT6",
                table: "IT6s",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IT6_Personals_PersonalId",
                table: "IT6s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
