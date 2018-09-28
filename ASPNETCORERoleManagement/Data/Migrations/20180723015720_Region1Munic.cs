using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCORERoleManagement.Data.Migrations
{
    public partial class Region1Munic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
              //  name: "IX_AspNetUserRoles_UserId",
              //  table: "AspNetUserRoles");

        //    migrationBuilder.DropIndex(
        //        name: "RoleNameIndex",
        //        table: "AspNetRoles");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUserClaims",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoleClaims",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "Cat1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Calle_num = table.Column<string>(maxLength: 30, nullable: true),
                    Cod_post = table.Column<string>(maxLength: 5, nullable: true),
                    Colonia = table.Column<string>(maxLength: 40, nullable: true),
                    Correo_resp = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(maxLength: 3, nullable: true),
                    Gbukrs = table.Column<string>(maxLength: 4, nullable: true),
                    Munic = table.Column<string>(maxLength: 4, nullable: true),
                    Nombre = table.Column<string>(maxLength: 30, nullable: true),
                    Nombre_largo = table.Column<string>(maxLength: 50, nullable: true),
                    Nombre_resp = table.Column<string>(maxLength: 40, nullable: true),
                    Num_edif = table.Column<string>(maxLength: 15, nullable: true),
                    Of_schp = table.Column<string>(maxLength: 20, nullable: true),
                    Pais = table.Column<string>(maxLength: 15, nullable: true),
                    Poblac = table.Column<string>(maxLength: 40, nullable: true),
                    Rfc = table.Column<string>(maxLength: 20, nullable: true),
                    Skype_resp = table.Column<string>(maxLength: 20, nullable: true),
                    Tel_cel_respo = table.Column<string>(maxLength: 10, nullable: true),
                    Telefono = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuMaster",
                columns: table => new
                {
                    MenuIdentity = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    MenuFileName = table.Column<string>(nullable: true),
                    MenuID = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    MenuURL = table.Column<string>(nullable: true),
                    Parent_MenuID = table.Column<string>(nullable: true),
                    USE_YN = table.Column<string>(nullable: true),
                    User_Roll = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMaster", x => x.MenuIdentity);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    mpio = table.Column<string>(maxLength: 4, nullable: true),
                    region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Region1",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 50, nullable: true),
                    rg = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region1", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cat1");

            migrationBuilder.DropTable(
                name: "MenuMaster");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Region1");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUserClaims",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoleClaims",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
