using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakeWeBet.Data.Migrations
{
    public partial class MG_FirstMigration_07_07_2022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BET_CATEGORY",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BET_CATEGORY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRY",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CURRENCY",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURRENCY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_CURRENCY_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "CURRENCY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BET",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BetPrivatePasscode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BetCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BetReviewStatus = table.Column<int>(type: "int", nullable: false),
                    BetValidityStatus = table.Column<int>(type: "int", nullable: false),
                    LikeCount = table.Column<long>(type: "bigint", nullable: false),
                    ReshareCount = table.Column<long>(type: "bigint", nullable: false),
                    CommentCount = table.Column<long>(type: "bigint", nullable: false),
                    BetCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BetStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BetEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorBonus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BET", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BET_BET_CATEGORY_BetCategoryId",
                        column: x => x.BetCategoryId,
                        principalTable: "BET_CATEGORY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BET_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_BET_CATEGORY_SUGGESTION",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_BET_CATEGORY_SUGGESTION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_BET_CATEGORY_SUGGESTION_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_FOLLOWERSHIP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserFollowingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowershipStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_FOLLOWERSHIP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_FOLLOWERSHIP_USER_UserFollowingId",
                        column: x => x.UserFollowingId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_FOLLOWERSHIP_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_BET",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BetAmount = table.Column<long>(type: "bigint", nullable: false),
                    SelectedBetResponse = table.Column<int>(type: "int", nullable: false),
                    PairingStatus = table.Column<int>(type: "int", nullable: false),
                    BetResult = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_BET", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_BET_BET_BetId",
                        column: x => x.BetId,
                        principalTable: "BET",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_BET_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BET_BetCategoryId",
                table: "BET",
                column: "BetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BET_UserId",
                table: "BET",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_CurrencyId",
                table: "USER",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_BET_BetId",
                table: "USER_BET",
                column: "BetId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_BET_UserId",
                table: "USER_BET",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_BET_CATEGORY_SUGGESTION_UserId",
                table: "USER_BET_CATEGORY_SUGGESTION",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_FOLLOWERSHIP_UserFollowingId",
                table: "USER_FOLLOWERSHIP",
                column: "UserFollowingId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_FOLLOWERSHIP_UserId",
                table: "USER_FOLLOWERSHIP",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COUNTRY");

            migrationBuilder.DropTable(
                name: "USER_BET");

            migrationBuilder.DropTable(
                name: "USER_BET_CATEGORY_SUGGESTION");

            migrationBuilder.DropTable(
                name: "USER_FOLLOWERSHIP");

            migrationBuilder.DropTable(
                name: "BET");

            migrationBuilder.DropTable(
                name: "BET_CATEGORY");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "CURRENCY");
        }
    }
}
