using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class personals1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Cname = table.Column<string>(maxLength: 80, nullable: true),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Nach2 = table.Column<string>(maxLength: 40, nullable: true),
                    Nachn = table.Column<string>(maxLength: 40, nullable: true),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Uname = table.Column<string>(maxLength: 12, nullable: true),
                    Vorna = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IT6",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aedtm = table.Column<DateTime>(nullable: false),
                    BegDa = table.Column<DateTime>(nullable: false),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Cod_post = table.Column<string>(maxLength: 5, nullable: true),
                    Colonia = table.Column<string>(maxLength: 40, nullable: true),
                    EndDa = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(maxLength: 3, nullable: true),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Land1 = table.Column<string>(maxLength: 3, nullable: true),
                    Munic = table.Column<string>(maxLength: 4, nullable: true),
                    Pernr = table.Column<int>(maxLength: 8, nullable: false),
                    PersonalId = table.Column<int>(nullable: false),
                    Poblac = table.Column<string>(maxLength: 40, nullable: true),
                    Seqnr = table.Column<int>(maxLength: 3, nullable: false),
                    Stras = table.Column<string>(maxLength: 60, nullable: true),
                    Subty = table.Column<string>(maxLength: 4, nullable: true),
                    Telnr = table.Column<int>(maxLength: 14, nullable: false),
                    Uname = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT6", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IT6_Personals_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IT9s_PersonalId",
                table: "IT9s",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_IT8s_PersonalId",
                table: "IT8s",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_IT7s_PersonalId",
                table: "IT7s",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_IT41s_PersonalId",
                table: "IT41s",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_IT369s_PersonalId",
                table: "IT369s",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_IT21s_PersonalId",
                table: "IT21s",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_IT2_185_105s_PersonalId",
                table: "IT2_185_105s",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_IT1s_PersonalId",
                table: "IT1s",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_IT16s_PersonalId",
                table: "IT16s",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_IT0s_PersonalId",
                table: "IT0s",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_IT6_PersonalId",
                table: "IT6",
                column: "PersonalId");

            migrationBuilder.AddForeignKey(
                name: "FK_IT0s_Personals_PersonalId",
                table: "IT0s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IT16s_Personals_PersonalId",
                table: "IT16s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IT1s_Personals_PersonalId",
                table: "IT1s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IT2_185_105s_Personals_PersonalId",
                table: "IT2_185_105s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IT21s_Personals_PersonalId",
                table: "IT21s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IT369s_Personals_PersonalId",
                table: "IT369s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IT41s_Personals_PersonalId",
                table: "IT41s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IT7s_Personals_PersonalId",
                table: "IT7s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IT8s_Personals_PersonalId",
                table: "IT8s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IT9s_Personals_PersonalId",
                table: "IT9s",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IT0s_Personals_PersonalId",
                table: "IT0s");

            migrationBuilder.DropForeignKey(
                name: "FK_IT16s_Personals_PersonalId",
                table: "IT16s");

            migrationBuilder.DropForeignKey(
                name: "FK_IT1s_Personals_PersonalId",
                table: "IT1s");

            migrationBuilder.DropForeignKey(
                name: "FK_IT2_185_105s_Personals_PersonalId",
                table: "IT2_185_105s");

            migrationBuilder.DropForeignKey(
                name: "FK_IT21s_Personals_PersonalId",
                table: "IT21s");

            migrationBuilder.DropForeignKey(
                name: "FK_IT369s_Personals_PersonalId",
                table: "IT369s");

            migrationBuilder.DropForeignKey(
                name: "FK_IT41s_Personals_PersonalId",
                table: "IT41s");

            migrationBuilder.DropForeignKey(
                name: "FK_IT7s_Personals_PersonalId",
                table: "IT7s");

            migrationBuilder.DropForeignKey(
                name: "FK_IT8s_Personals_PersonalId",
                table: "IT8s");

            migrationBuilder.DropForeignKey(
                name: "FK_IT9s_Personals_PersonalId",
                table: "IT9s");

            migrationBuilder.DropTable(
                name: "IT6");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropIndex(
                name: "IX_IT9s_PersonalId",
                table: "IT9s");

            migrationBuilder.DropIndex(
                name: "IX_IT8s_PersonalId",
                table: "IT8s");

            migrationBuilder.DropIndex(
                name: "IX_IT7s_PersonalId",
                table: "IT7s");

            migrationBuilder.DropIndex(
                name: "IX_IT41s_PersonalId",
                table: "IT41s");

            migrationBuilder.DropIndex(
                name: "IX_IT369s_PersonalId",
                table: "IT369s");

            migrationBuilder.DropIndex(
                name: "IX_IT21s_PersonalId",
                table: "IT21s");

            migrationBuilder.DropIndex(
                name: "IX_IT2_185_105s_PersonalId",
                table: "IT2_185_105s");

            migrationBuilder.DropIndex(
                name: "IX_IT1s_PersonalId",
                table: "IT1s");

            migrationBuilder.DropIndex(
                name: "IX_IT16s_PersonalId",
                table: "IT16s");

            migrationBuilder.DropIndex(
                name: "IX_IT0s_PersonalId",
                table: "IT0s");
        }
    }
}
