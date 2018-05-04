using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LIA.Data.Migrations
{
    public partial class ItemTitleAddedToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Items");
        }
    }
}
