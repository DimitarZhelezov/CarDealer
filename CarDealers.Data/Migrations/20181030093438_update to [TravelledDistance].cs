using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarDealersWeb.Data.Migrations
{
    public partial class updatetoTravelledDistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TravellDistance",
                table: "Cars",
                newName: "TravelledDistance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TravelledDistance",
                table: "Cars",
                newName: "TravellDistance");
        }
    }
}
