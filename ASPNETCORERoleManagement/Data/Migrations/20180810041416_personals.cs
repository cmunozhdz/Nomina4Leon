using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class personals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "IT9s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "IT8s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "IT7s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "IT41s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "IT369s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "IT21s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "IT2_185_105s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "IT1s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "IT16s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "IT0s",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "IT9s");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "IT8s");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "IT7s");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "IT41s");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "IT369s");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "IT21s");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "IT2_185_105s");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "IT1s");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "IT16s");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "IT0s");
        }
    }
}
