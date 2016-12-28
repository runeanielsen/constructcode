using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Constructcode.Web.Migrations
{
    public partial class AddedLastModifiedToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PostCategories_PostId",
                table: "PostCategories");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Posts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Posts");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_PostId",
                table: "PostCategories",
                column: "PostId");
        }
    }
}
