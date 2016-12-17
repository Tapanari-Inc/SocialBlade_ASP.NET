using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialBlade.Data.Migrations
{
    public partial class somecommentsissuesfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorFullName = table.Column<string>(nullable: true),
                    AuthorProfilePictureUrl = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Dislikes = table.Column<int>(nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    ParentCommentId = table.Column<Guid>(nullable: false),
                    RepliesCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentViewModel", x => x.Id);
                });

            migrationBuilder.AddColumn<Guid>(
                name: "CommentViewModelId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PostID1",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentViewModelId",
                table: "Comments",
                column: "CommentViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostID1",
                table: "Comments",
                column: "PostID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CommentViewModel_CommentViewModelId",
                table: "Comments",
                column: "CommentViewModelId",
                principalTable: "CommentViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostID1",
                table: "Comments",
                column: "PostID1",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CommentViewModel_CommentViewModelId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostID1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentViewModelId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostID1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentViewModelId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostID1",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "CommentViewModel");
        }
    }
}
