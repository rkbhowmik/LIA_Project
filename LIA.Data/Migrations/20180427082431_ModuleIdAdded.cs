using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LIA.Data.Migrations
{
    public partial class ModuleIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Items_ModuleId",
            //    table: "Items",
            //    column: "ModuleId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Items_Modules_ModuleId",
            //    table: "Items",
            //    column: "ModuleId",
            //    principalTable: "Modules",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Items_Modules_ModuleId",
            //    table: "Items");

            //migrationBuilder.DropIndex(
            //    name: "IX_Items_ModuleId",
            //    table: "Items");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "Items");
        }
    }
}
