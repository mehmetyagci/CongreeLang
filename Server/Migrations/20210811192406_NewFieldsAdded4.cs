using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class NewFieldsAdded4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysisItem_Analyzes_AnalysisId",
                table: "AnalysisItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Document_DocumentId",
                table: "Analyzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Analyzes",
                table: "Analyzes");

            migrationBuilder.RenameTable(
                name: "Analyzes",
                newName: "Analysis");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_DocumentId",
                table: "Analysis",
                newName: "IX_Analysis_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Analysis",
                table: "Analysis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Analysis_Document_DocumentId",
                table: "Analysis",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysisItem_Analysis_AnalysisId",
                table: "AnalysisItem",
                column: "AnalysisId",
                principalTable: "Analysis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analysis_Document_DocumentId",
                table: "Analysis");

            migrationBuilder.DropForeignKey(
                name: "FK_AnalysisItem_Analysis_AnalysisId",
                table: "AnalysisItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Analysis",
                table: "Analysis");

            migrationBuilder.RenameTable(
                name: "Analysis",
                newName: "Analyzes");

            migrationBuilder.RenameIndex(
                name: "IX_Analysis_DocumentId",
                table: "Analyzes",
                newName: "IX_Analyzes_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Analyzes",
                table: "Analyzes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysisItem_Analyzes_AnalysisId",
                table: "AnalysisItem",
                column: "AnalysisId",
                principalTable: "Analyzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Document_DocumentId",
                table: "Analyzes",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
