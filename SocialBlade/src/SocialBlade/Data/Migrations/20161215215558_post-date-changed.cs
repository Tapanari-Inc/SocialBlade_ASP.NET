using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialBlade.Data.Migrations
{
    public partial class postdatechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Dislike_Posts_PostId",
                table: "User_Dislike");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_Groups_GroupId",
                table: "User_Group");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Like_Posts_PostId",
                table: "User_Like");

            migrationBuilder.CreateTable(
                name: "ShortPostViewModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AuthorName = table.Column<string>(nullable: true),
                    AuthorPictureUrl = table.Column<string>(nullable: true),
                    CommentsCount = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    CreateTime = table.Column<string>(nullable: true),
                    Dislikes = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Likes = table.Column<int>(nullable: false),
                    Reaction = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortPostViewModel", x => x.ID);
                });

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Posts",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Posts",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentID",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostID",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Groups_GroupID",
                table: "Messages",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Dislike_Posts_PostID",
                table: "User_Dislike",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_Groups_GroupID",
                table: "User_Group",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Like_Posts_PostID",
                table: "User_Like",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserRelation",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "User_Like",
                newName: "PostID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User_Like",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "User_Group",
                newName: "GroupID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User_Group",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "User_Dislike",
                newName: "PostID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User_Dislike",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posts",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Messages",
                newName: "GroupID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Messages",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Groups",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comments",
                newName: "PostID");

            migrationBuilder.RenameColumn(
                name: "ParentCommentId",
                table: "Comments",
                newName: "ParentCommentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_User_Like_PostId",
                table: "User_Like",
                newName: "IX_User_Like_PostID");

            migrationBuilder.RenameIndex(
                name: "IX_User_Group_GroupId",
                table: "User_Group",
                newName: "IX_User_Group_GroupID");

            migrationBuilder.RenameIndex(
                name: "IX_User_Dislike_PostId",
                table: "User_Dislike",
                newName: "IX_User_Dislike_PostID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_GroupId",
                table: "Messages",
                newName: "IX_Messages_GroupID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                newName: "IX_Comments_PostID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                newName: "IX_Comments_ParentCommentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Groups_GroupID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Dislike_Posts_PostID",
                table: "User_Dislike");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_Groups_GroupID",
                table: "User_Group");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Like_Posts_PostID",
                table: "User_Like");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "ShortPostViewModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostID",
                table: "Comments",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentID",
                principalTable: "Comments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Dislike_Posts_PostId",
                table: "User_Dislike",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_Groups_GroupId",
                table: "User_Group",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Like_Posts_PostId",
                table: "User_Like",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserRelation",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "User_Like",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User_Like",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "User_Group",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User_Group",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "User_Dislike",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User_Dislike",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Posts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "Messages",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Messages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Groups",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "Comments",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "ParentCommentID",
                table: "Comments",
                newName: "ParentCommentId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_User_Like_PostID",
                table: "User_Like",
                newName: "IX_User_Like_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Group_GroupID",
                table: "User_Group",
                newName: "IX_User_Group_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Dislike_PostID",
                table: "User_Dislike",
                newName: "IX_User_Dislike_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_GroupID",
                table: "Messages",
                newName: "IX_Messages_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostID",
                table: "Comments",
                newName: "IX_Comments_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentCommentID",
                table: "Comments",
                newName: "IX_Comments_ParentCommentId");
        }
    }
}
