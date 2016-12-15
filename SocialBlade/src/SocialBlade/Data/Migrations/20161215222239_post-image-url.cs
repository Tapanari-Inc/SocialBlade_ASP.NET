using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialBlade.Data.Migrations
{
    public partial class postimageurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortPostViewModel");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Posts");

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
        }
    }
}
