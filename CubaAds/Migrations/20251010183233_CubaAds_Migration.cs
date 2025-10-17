using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CubaAds.Migrations
{
    /// <inheritdoc />
    public partial class CubaAds_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    app_type = table.Column<string>(type: "text", nullable: false),
                    ad_type = table.Column<string>(type: "text", nullable: false),
                    cost_per_view = table.Column<decimal>(type: "numeric", nullable: false),
                    payout_per_view = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    rol = table.Column<string>(type: "text", nullable: false),
                    refresh_token = table.Column<string>(type: "text", nullable: false),
                    refresh_token_expire = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AppClients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    app_client_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    app_type = table.Column<string>(type: "text", nullable: false),
                    api_key = table.Column<string>(type: "text", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppClients", x => x.id);
                    table.ForeignKey(
                        name: "FK_AppClients_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    business_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    contact_email = table.Column<string>(type: "text", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    category = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Businesses_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    business_id = table.Column<Guid>(type: "uuid", nullable: false),
                    media_url = table.Column<string>(type: "text", nullable: false),
                    media_type = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    ad_type = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    target_url = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ads_Businesses_business_id",
                        column: x => x.business_id,
                        principalTable: "Businesses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdViews",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    app_id = table.Column<Guid>(type: "uuid", nullable: false),
                    device_id = table.Column<string>(type: "text", nullable: false),
                    earned = table.Column<decimal>(type: "numeric", nullable: false),
                    cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdViews", x => x.id);
                    table.ForeignKey(
                        name: "FK_AdViews_Ads_ad_id",
                        column: x => x.ad_id,
                        principalTable: "Ads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdViews_AppClients_app_id",
                        column: x => x.app_id,
                        principalTable: "AppClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campains",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    max_views = table.Column<int>(type: "integer", nullable: false),
                    view_count = table.Column<int>(type: "integer", nullable: false),
                    allowed_app_type = table.Column<int[]>(type: "integer[]", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campains", x => x.id);
                    table.ForeignKey(
                        name: "FK_Campains_Ads_ad_id",
                        column: x => x.ad_id,
                        principalTable: "Ads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClickEvents",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    app_id = table.Column<Guid>(type: "uuid", nullable: false),
                    device_ip = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClickEvents", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClickEvents_Ads_ad_id",
                        column: x => x.ad_id,
                        principalTable: "Ads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClickEvents_AppClients_app_id",
                        column: x => x.app_id,
                        principalTable: "AppClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_business_id",
                table: "Ads",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdViews_ad_id",
                table: "AdViews",
                column: "ad_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdViews_app_id",
                table: "AdViews",
                column: "app_id");

            migrationBuilder.CreateIndex(
                name: "IX_AppClients_api_key",
                table: "AppClients",
                column: "api_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppClients_user_id",
                table: "AppClients",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_contact_email",
                table: "Businesses",
                column: "contact_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_user_id",
                table: "Businesses",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Campains_ad_id",
                table: "Campains",
                column: "ad_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClickEvents_ad_id",
                table: "ClickEvents",
                column: "ad_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClickEvents_app_id",
                table: "ClickEvents",
                column: "app_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdViews");

            migrationBuilder.DropTable(
                name: "Campains");

            migrationBuilder.DropTable(
                name: "ClickEvents");

            migrationBuilder.DropTable(
                name: "Pricings");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "AppClients");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
