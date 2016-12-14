using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialBlade.Data.Migrations
{
    public partial class addedfollowers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "UserRelation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FolloweeId = table.Column<string>(nullable: false),
                    FollowerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRelation_AspNetUsers_FolloweeId",
                        column: x => x.FolloweeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRelation_AspNetUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PostId1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PostId",
                table: "AspNetUsers",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PostId1",
                table: "AspNetUsers",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelation_FolloweeId",
                table: "UserRelation",
                column: "FolloweeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelation_FollowerId",
                table: "UserRelation",
                column: "FollowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Posts_PostId",
                table: "AspNetUsers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Posts_PostId1",
                table: "AspNetUsers",
                column: "PostId1",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Posts_PostId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Posts_PostId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PostId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PostId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserRelation");

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }
    }
}
