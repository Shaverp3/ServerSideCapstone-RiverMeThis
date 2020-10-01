using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RiverMeThis.Migrations
{
    public partial class InitialDBSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    DeviceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.DeviceId);
                });

            migrationBuilder.CreateTable(
                name: "River",
                columns: table => new
                {
                    RiverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TotalLength = table.Column<float>(nullable: false),
                    NumAPs = table.Column<int>(nullable: false),
                    MapPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_River", x => x.RiverId);
                });

            migrationBuilder.CreateTable(
                name: "Sherpa",
                columns: table => new
                {
                    SherpaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PicPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sherpa", x => x.SherpaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessPoint",
                columns: table => new
                {
                    AccessPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    APIndex = table.Column<int>(nullable: false),
                    ClassRapids = table.Column<string>(nullable: true),
                    RiverId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPoint", x => x.AccessPointId);
                    table.ForeignKey(
                        name: "FK_AccessPoint_River_RiverId",
                        column: x => x.RiverId,
                        principalTable: "River",
                        principalColumn: "RiverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FloatTrip",
                columns: table => new
                {
                    FloatTripId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Distance = table.Column<float>(nullable: true),
                    NumberOfFloaters = table.Column<int>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: true),
                    PicPath = table.Column<string>(nullable: true),
                    NeedASherpa = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    RiverId = table.Column<int>(nullable: true),
                    PutInAPId = table.Column<int>(nullable: true),
                    TakeOutAPId = table.Column<int>(nullable: true),
                    DeviceId = table.Column<int>(nullable: true),
                    SherpaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloatTrip", x => x.FloatTripId);
                    table.ForeignKey(
                        name: "FK_FloatTrip_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloatTrip_AccessPoint_PutInAPId",
                        column: x => x.PutInAPId,
                        principalTable: "AccessPoint",
                        principalColumn: "AccessPointId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloatTrip_River_RiverId",
                        column: x => x.RiverId,
                        principalTable: "River",
                        principalColumn: "RiverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloatTrip_Sherpa_SherpaId",
                        column: x => x.SherpaId,
                        principalTable: "Sherpa",
                        principalColumn: "SherpaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloatTrip_AccessPoint_TakeOutAPId",
                        column: x => x.TakeOutAPId,
                        principalTable: "AccessPoint",
                        principalColumn: "AccessPointId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloatTrip_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "c8fb91fa-9459-4c71-8445-f8c6fc39c86c", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMgZdMB7al2p9G+29d0GKcE3T8yRUlJQLehQbAy6nfPBnO8qHGeWapl4HtKmXPh6nA==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "DeviceId", "Type" },
                values: new object[,]
                {
                    { 1, "Inner Tube/Pool Float" },
                    { 2, "Kayak/Canoe" },
                    { 3, "S.U.P." }
                });

            migrationBuilder.InsertData(
                table: "River",
                columns: new[] { "RiverId", "MapPath", "Name", "NumAPs", "TotalLength" },
                values: new object[,]
                {
                    { 1, "CoalRiverWaterTrailMap.jpg", "Big Coal to Coal River", 12, 60f },
                    { 2, "CoalRiverWaterTrailMap.jpg", "Little Coal to Coal River", 14, 47f },
                    { 3, "CoalRiverWaterTrailMap.jpg", "Coal River", 6, 20f },
                    { 4, "ElkRiverWaterTrailMap.jpg", "Elk River", 17, 172f },
                    { 5, "GyandotteRiverTrailMap.jpg", "Gyandotte River", 24, 166f }
                });

            migrationBuilder.InsertData(
                table: "AccessPoint",
                columns: new[] { "AccessPointId", "APIndex", "ClassRapids", "Location", "Name", "RiverId" },
                values: new object[,]
                {
                    { 1, 1, "I", "Whitesville, WV", "Whitesville Public Access", 1 },
                    { 2, 2, "I", "Orgas, WV", "JM Protan Community Center Public Access", 1 },
                    { 3, 1, "I", "Madison, WV", "Madison City Park Public Access", 2 },
                    { 4, 2, "I", "Danville, WV", "Danville Community Center Public Access", 2 },
                    { 11, 3, "I", "Julian, WV", "Donald Kuhn Juvenile Center Public Access", 2 },
                    { 12, 4, "I", "Julian, WV", "Big Earl's Campground", 2 },
                    { 5, 1, "I", "Alum Creek, WV", "Lock 4 Launch", 3 },
                    { 6, 2, "I", "Alum Creek, WV", "Lions Park Public Access", 3 },
                    { 7, 1, "II", "Sutton, WV", "Sutton Dam Tailwaters", 4 },
                    { 8, 2, "II", "Sutton, WV", "Cafe Cimino", 4 },
                    { 9, 1, "I", "Mullens, WV", "Three Mile Curve Access", 5 },
                    { 10, 2, "I", "Stollings, WV", "U.S. Post Office Access", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessPoint_RiverId",
                table: "AccessPoint",
                column: "RiverId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FloatTrip_DeviceId",
                table: "FloatTrip",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_FloatTrip_PutInAPId",
                table: "FloatTrip",
                column: "PutInAPId");

            migrationBuilder.CreateIndex(
                name: "IX_FloatTrip_RiverId",
                table: "FloatTrip",
                column: "RiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FloatTrip_SherpaId",
                table: "FloatTrip",
                column: "SherpaId");

            migrationBuilder.CreateIndex(
                name: "IX_FloatTrip_TakeOutAPId",
                table: "FloatTrip",
                column: "TakeOutAPId");

            migrationBuilder.CreateIndex(
                name: "IX_FloatTrip_UserId",
                table: "FloatTrip",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FloatTrip");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "AccessPoint");

            migrationBuilder.DropTable(
                name: "Sherpa");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "River");
        }
    }
}
