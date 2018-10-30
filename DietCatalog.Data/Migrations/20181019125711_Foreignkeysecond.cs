using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DietCatalog.Data.Migrations
{
    public partial class Foreignkeysecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Diets_DietId",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "Days",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Diets_DietId",
                table: "Days",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Diets_DietId",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "Days",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Diets_DietId",
                table: "Days",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
