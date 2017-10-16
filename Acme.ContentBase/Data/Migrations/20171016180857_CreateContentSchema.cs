using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Achilles.Acme.Content.Data.Migrations
{
    public partial class CreateContentSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cms_Posts",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_Posts", x => x.ContentId);
                });

            migrationBuilder.CreateTable(
                name: "cms_Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentTagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "cms_Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    PostContentId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cms_Comments_cms_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "cms_Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cms_Comments_cms_Posts_PostContentId",
                        column: x => x.PostContentId,
                        principalTable: "cms_Posts",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cms_PostTags",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_PostTags", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_cms_PostTags_cms_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "cms_Posts",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cms_PostTags_cms_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "cms_Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cms_Comments_CommentId",
                table: "cms_Comments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_cms_Comments_PostContentId",
                table: "cms_Comments",
                column: "PostContentId");

            migrationBuilder.CreateIndex(
                name: "IX_cms_PostTags_TagId",
                table: "cms_PostTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cms_Comments");

            migrationBuilder.DropTable(
                name: "cms_PostTags");

            migrationBuilder.DropTable(
                name: "cms_Posts");

            migrationBuilder.DropTable(
                name: "cms_Tags");
        }
    }
}
