using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Constructcode.Web.Migrations
{
    public partial class ChangedHashToSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hash",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "Accounts",
                nullable: true);
        }
    }
}
