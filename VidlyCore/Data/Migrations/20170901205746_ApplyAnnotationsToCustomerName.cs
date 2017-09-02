using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VidlyCore.Data.Migrations
{
    public partial class ApplyAnnotationsToCustomerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_MembershipType",
            //    table: "MembershipType");

            //migrationBuilder.RenameTable(
            //    name: "MembershipType",
            //    newName: "MembershipTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_MembershipTypes",
            //    table: "MembershipTypes",
            //    column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipTypes",
                table: "MembershipTypes");

            migrationBuilder.RenameTable(
                name: "MembershipTypes",
                newName: "MembershipType");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipType",
                table: "MembershipType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
