using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class ChangeTableNameToSingular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagDetails_Tags_TagId",
                table: "TagDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Document_DocumentId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagDetails",
                table: "TagDetails");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "TagDetails",
                newName: "TagDetail");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_DocumentId",
                table: "Tag",
                newName: "IX_Tag_DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_TagDetails_TagId",
                table: "TagDetail",
                newName: "IX_TagDetail_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagDetail",
                table: "TagDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Document_DocumentId",
                table: "Tag",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagDetail_Tag_TagId",
                table: "TagDetail",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Document_DocumentId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_TagDetail_Tag_TagId",
                table: "TagDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagDetail",
                table: "TagDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "TagDetail",
                newName: "TagDetails");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_TagDetail_TagId",
                table: "TagDetails",
                newName: "IX_TagDetails_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_DocumentId",
                table: "Tags",
                newName: "IX_Tags_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagDetails",
                table: "TagDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagDetails_Tags_TagId",
                table: "TagDetails",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Document_DocumentId",
                table: "Tags",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
