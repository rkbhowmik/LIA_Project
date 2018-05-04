using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LIA.Data.Migrations
{
    public partial class ImageUrlAddedtoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Items");
        }
    }
}
