using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialBlade.Data.Migrations
{
    public partial class randomdbfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Dislike_Posts_PostId",
                table: "User_Dislike");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Dislike_AspNetUsers_UserId",
                table: "User_Dislike");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_Groups_GroupId",
                table: "User_Group");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_AspNetUsers_UserId",
                table: "User_Group");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Like_Posts_PostId",
                table: "User_Like");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Like_AspNetUsers_UserId",
                table: "User_Like");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelation_AspNetUsers_FolloweeId",
                table: "UserRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelation_AspNetUsers_FollowerId",
                table: "UserRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRelation",
                table: "UserRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Like",
                table: "User_Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Group",
                table: "User_Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Dislike",
                table: "User_Dislike");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRelations",
                table: "UserRelation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikes",
                table: "User_Like",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "User_Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDislikes",
                table: "User_Dislike",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDislikes_Posts_PostId",
                table: "User_Dislike",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDislikes_AspNetUsers_UserId",
                table: "User_Dislike",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Groups_GroupId",
                table: "User_Group",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_AspNetUsers_UserId",
                table: "User_Group",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_Posts_PostId",
                table: "User_Like",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_AspNetUsers_UserId",
                table: "User_Like",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRelations_AspNetUsers_FolloweeId",
                table: "UserRelation",
                column: "FolloweeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRelations_AspNetUsers_FollowerId",
                table: "UserRelation",
                column: "FollowerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_UserRelation_FollowerId",
                table: "UserRelation",
                newName: "IX_UserRelations_FollowerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRelation_FolloweeId",
                table: "UserRelation",
                newName: "IX_UserRelations_FolloweeId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Like_UserId",
                table: "User_Like",
                newName: "IX_UserLikes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Like_PostId",
                table: "User_Like",
                newName: "IX_UserLikes_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Group_UserId",
                table: "User_Group",
                newName: "IX_UserGroups_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Group_GroupId",
                table: "User_Group",
                newName: "IX_UserGroups_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Dislike_UserId",
                table: "User_Dislike",
                newName: "IX_UserDislikes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Dislike_PostId",
                table: "User_Dislike",
                newName: "IX_UserDislikes_PostId");

            migrationBuilder.RenameTable(
                name: "UserRelation",
                newName: "UserRelations");

            migrationBuilder.RenameTable(
                name: "User_Like",
                newName: "UserLikes");

            migrationBuilder.RenameTable(
                name: "User_Group",
                newName: "UserGroups");

            migrationBuilder.RenameTable(
                name: "User_Dislike",
                newName: "UserDislikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDislikes_Posts_PostId",
                table: "UserDislikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDislikes_AspNetUsers_UserId",
                table: "UserDislikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Groups_GroupId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_AspNetUsers_UserId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_Posts_PostId",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_AspNetUsers_UserId",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelations_AspNetUsers_FolloweeId",
                table: "UserRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelations_AspNetUsers_FollowerId",
                table: "UserRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRelations",
                table: "UserRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDislikes",
                table: "UserDislikes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRelation",
                table: "UserRelations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Like",
                table: "UserLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Group",
                table: "UserGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Dislike",
                table: "UserDislikes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Dislike_Posts_PostId",
                table: "UserDislikes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Dislike_AspNetUsers_UserId",
                table: "UserDislikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_Groups_GroupId",
                table: "UserGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_AspNetUsers_UserId",
                table: "UserGroups",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Like_Posts_PostId",
                table: "UserLikes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Like_AspNetUsers_UserId",
                table: "UserLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRelation_AspNetUsers_FolloweeId",
                table: "UserRelations",
                column: "FolloweeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRelation_AspNetUsers_FollowerId",
                table: "UserRelations",
                column: "FollowerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_UserRelations_FollowerId",
                table: "UserRelations",
                newName: "IX_UserRelation_FollowerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRelations_FolloweeId",
                table: "UserRelations",
                newName: "IX_UserRelation_FolloweeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLikes_UserId",
                table: "UserLikes",
                newName: "IX_User_Like_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLikes_PostId",
                table: "UserLikes",
                newName: "IX_User_Like_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_UserId",
                table: "UserGroups",
                newName: "IX_User_Group_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_GroupId",
                table: "UserGroups",
                newName: "IX_User_Group_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDislikes_UserId",
                table: "UserDislikes",
                newName: "IX_User_Dislike_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDislikes_PostId",
                table: "UserDislikes",
                newName: "IX_User_Dislike_PostId");

            migrationBuilder.RenameTable(
                name: "UserRelations",
                newName: "UserRelation");

            migrationBuilder.RenameTable(
                name: "UserLikes",
                newName: "User_Like");

            migrationBuilder.RenameTable(
                name: "UserGroups",
                newName: "User_Group");

            migrationBuilder.RenameTable(
                name: "UserDislikes",
                newName: "User_Dislike");
        }
    }
}
