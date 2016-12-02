using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Constructcode.Web.Migrations
{
    public partial class InsertDefaultAdminAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([Password], [Username], [Salt]) VALUES ('+Y49bJDXYllwSRje7C2xyayCh4ejd1nY5a/2dUITjEE=', 'admin', '3fxjrVKNn2KSqZ4uRiRmJg==')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
