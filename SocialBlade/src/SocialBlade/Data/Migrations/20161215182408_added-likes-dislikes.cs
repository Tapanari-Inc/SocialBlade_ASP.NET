using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialBlade.Data.Migrations
{
    public partial class addedlikesdislikes : Migration
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
                name: "User_Dislike",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PostId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Dislike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Dislike_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Dislike_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Like",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PostId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Like_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Like_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_User_Dislike_PostId",
                table: "User_Dislike",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Dislike_UserId",
                table: "User_Dislike",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Like_PostId",
                table: "User_Like",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Like_UserId",
                table: "User_Like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelation_FolloweeId",
                table: "UserRelation",
                column: "FolloweeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelation_FollowerId",
                table: "UserRelation",
                column: "FollowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Dislike");

            migrationBuilder.DropTable(
                name: "User_Like");

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
