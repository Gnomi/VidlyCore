using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VidlyCore.Data.Migrations
{
    public partial class PopulateCustomerBirthdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Birthdaydate",
            //    table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MembershipTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "Birthdate",
            //    table: "Customers",
            //    type: "datetime2",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropColumn(
        //        name: "Birthdate",
        //        table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MembershipTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "Birthdaydate",
            //    table: "Customers",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
