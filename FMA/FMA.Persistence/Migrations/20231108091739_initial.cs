using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gemeente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Postcode = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    Stad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemeente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HerstellingType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HerstellingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nummerplaat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    IsActief = table.Column<bool>(type: "bit", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nummerplaat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tankkaart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KaartNummer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GeldigheidsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsGeblokkeerd = table.Column<bool>(type: "bit", nullable: false),
                    BrandstofType = table.Column<int>(type: "int", nullable: true),
                    AuthenticatieType = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tankkaart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voertuig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Chassisnummer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartLeasing = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EersteInschrijving = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LooptijdLeasing = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WagenType = table.Column<int>(type: "int", nullable: false),
                    BrandstofType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voertuig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Garage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Adres_Straat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres_Nummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres_Bus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GemeenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garage_Gemeente_GemeenteId",
                        column: x => x.GemeenteId,
                        principalTable: "Gemeente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Verzekeringsmaatschappij",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Referentienummer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres_Straat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres_Nummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres_Bus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GemeenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verzekeringsmaatschappij", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verzekeringsmaatschappij_Gemeente_GemeenteId",
                        column: x => x.GemeenteId,
                        principalTable: "Gemeente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chauffeur",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rijksregisternummer = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    IsActief = table.Column<bool>(type: "bit", nullable: false),
                    RijbewijsType = table.Column<int>(type: "int", nullable: true),
                    Geslacht = table.Column<int>(type: "int", nullable: false),
                    TankkaartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Adres_Straat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres_Nummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres_Bus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GemeenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chauffeur_Gemeente_GemeenteId",
                        column: x => x.GemeenteId,
                        principalTable: "Gemeente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chauffeur_Tankkaart_TankkaartId",
                        column: x => x.TankkaartId,
                        principalTable: "Tankkaart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceTankkaart",
                columns: table => new
                {
                    ServicesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TankkaartenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTankkaart", x => new { x.ServicesId, x.TankkaartenId });
                    table.ForeignKey(
                        name: "FK_ServiceTankkaart_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTankkaart_Tankkaart_TankkaartenId",
                        column: x => x.TankkaartenId,
                        principalTable: "Tankkaart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kilometerstand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoertuigId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kilometerstand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kilometerstand_Voertuig_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NummerplaatVoertuig",
                columns: table => new
                {
                    NummerplatenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoertuigenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NummerplaatVoertuig", x => new { x.NummerplatenId, x.VoertuigenId });
                    table.ForeignKey(
                        name: "FK_NummerplaatVoertuig_Nummerplaat_NummerplatenId",
                        column: x => x.NummerplatenId,
                        principalTable: "Nummerplaat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NummerplaatVoertuig_Voertuig_VoertuigenId",
                        column: x => x.VoertuigenId,
                        principalTable: "Voertuig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChauffeurVoertuig",
                columns: table => new
                {
                    ChauffeursId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoertuigenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChauffeurVoertuig", x => new { x.ChauffeursId, x.VoertuigenId });
                    table.ForeignKey(
                        name: "FK_ChauffeurVoertuig_Chauffeur_ChauffeursId",
                        column: x => x.ChauffeursId,
                        principalTable: "Chauffeur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChauffeurVoertuig_Voertuig_VoertuigenId",
                        column: x => x.VoertuigenId,
                        principalTable: "Voertuig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GemeldeSchade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumMelding = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumSchade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Schade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ChauffeurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoertuigId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GemeldeSchade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GemeldeSchade_Chauffeur_ChauffeurId",
                        column: x => x.ChauffeurId,
                        principalTable: "Chauffeur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GemeldeSchade_Voertuig_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspectieverslag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumUitvoering = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChauffeurAanwezig = table.Column<bool>(type: "bit", nullable: false),
                    TotaalKost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Verslag = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ChauffeurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoertuigId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspectieverslag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspectieverslag_Chauffeur_ChauffeurId",
                        column: x => x.ChauffeurId,
                        principalTable: "Chauffeur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspectieverslag_Voertuig_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Herstelling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumUitvoering = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kostprijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VoertuigId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerzekeringsmaatschappijId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GemeldeSchadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herstelling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Herstelling_GemeldeSchade_GemeldeSchadeId",
                        column: x => x.GemeldeSchadeId,
                        principalTable: "GemeldeSchade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Herstelling_Verzekeringsmaatschappij_VerzekeringsmaatschappijId",
                        column: x => x.VerzekeringsmaatschappijId,
                        principalTable: "Verzekeringsmaatschappij",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Herstelling_Voertuig_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeinspecteerdeSchade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Onderdeel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Schade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Kostprijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InspectieverslagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HerstellingTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GemeldeSchadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeinspecteerdeSchade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeinspecteerdeSchade_GemeldeSchade_GemeldeSchadeId",
                        column: x => x.GemeldeSchadeId,
                        principalTable: "GemeldeSchade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GeinspecteerdeSchade_HerstellingType_HerstellingTypeId",
                        column: x => x.HerstellingTypeId,
                        principalTable: "HerstellingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GeinspecteerdeSchade_Inspectieverslag_InspectieverslagId",
                        column: x => x.InspectieverslagId,
                        principalTable: "Inspectieverslag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestandType = table.Column<int>(type: "int", nullable: false),
                    HerstellingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GemeldeSchadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_GemeldeSchade_GemeldeSchadeId",
                        column: x => x.GemeldeSchadeId,
                        principalTable: "GemeldeSchade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Document_Herstelling_HerstellingId",
                        column: x => x.HerstellingId,
                        principalTable: "Herstelling",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumUitvoering = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kostprijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UitgevoerdeWerken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoertuigId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhoud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Garage_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Onderhoud_Voertuig_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aanvraag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumAanvraag = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeginPeriode = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindPeriode = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnderhoudId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HerstellingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChauffeurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoertuigId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AanvraagType = table.Column<int>(type: "int", nullable: false),
                    StatusType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aanvraag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aanvraag_Chauffeur_ChauffeurId",
                        column: x => x.ChauffeurId,
                        principalTable: "Chauffeur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aanvraag_Herstelling_HerstellingId",
                        column: x => x.HerstellingId,
                        principalTable: "Herstelling",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Aanvraag_Onderhoud_OnderhoudId",
                        column: x => x.OnderhoudId,
                        principalTable: "Onderhoud",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Aanvraag_Voertuig_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuig",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aanvraag_ChauffeurId",
                table: "Aanvraag",
                column: "ChauffeurId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanvraag_HerstellingId",
                table: "Aanvraag",
                column: "HerstellingId",
                unique: true,
                filter: "[HerstellingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Aanvraag_OnderhoudId",
                table: "Aanvraag",
                column: "OnderhoudId",
                unique: true,
                filter: "[OnderhoudId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Aanvraag_VoertuigId",
                table: "Aanvraag",
                column: "VoertuigId");

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
                name: "IX_Chauffeur_Email",
                table: "Chauffeur",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeur_GemeenteId",
                table: "Chauffeur",
                column: "GemeenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeur_Rijksregisternummer",
                table: "Chauffeur",
                column: "Rijksregisternummer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeur_TankkaartId",
                table: "Chauffeur",
                column: "TankkaartId");

            migrationBuilder.CreateIndex(
                name: "IX_ChauffeurVoertuig_VoertuigenId",
                table: "ChauffeurVoertuig",
                column: "VoertuigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_GemeldeSchadeId",
                table: "Document",
                column: "GemeldeSchadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_HerstellingId",
                table: "Document",
                column: "HerstellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Garage_GemeenteId",
                table: "Garage",
                column: "GemeenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GeinspecteerdeSchade_GemeldeSchadeId",
                table: "GeinspecteerdeSchade",
                column: "GemeldeSchadeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeinspecteerdeSchade_HerstellingTypeId",
                table: "GeinspecteerdeSchade",
                column: "HerstellingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeinspecteerdeSchade_InspectieverslagId",
                table: "GeinspecteerdeSchade",
                column: "InspectieverslagId");

            migrationBuilder.CreateIndex(
                name: "IX_GemeldeSchade_ChauffeurId",
                table: "GemeldeSchade",
                column: "ChauffeurId");

            migrationBuilder.CreateIndex(
                name: "IX_GemeldeSchade_VoertuigId",
                table: "GemeldeSchade",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Herstelling_GemeldeSchadeId",
                table: "Herstelling",
                column: "GemeldeSchadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Herstelling_VerzekeringsmaatschappijId",
                table: "Herstelling",
                column: "VerzekeringsmaatschappijId");

            migrationBuilder.CreateIndex(
                name: "IX_Herstelling_VoertuigId",
                table: "Herstelling",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspectieverslag_ChauffeurId",
                table: "Inspectieverslag",
                column: "ChauffeurId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspectieverslag_VoertuigId",
                table: "Inspectieverslag",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Kilometerstand_VoertuigId",
                table: "Kilometerstand",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_NummerplaatVoertuig_VoertuigenId",
                table: "NummerplaatVoertuig",
                column: "VoertuigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_DocumentId",
                table: "Onderhoud",
                column: "DocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_GarageId",
                table: "Onderhoud",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_VoertuigId",
                table: "Onderhoud",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTankkaart_TankkaartenId",
                table: "ServiceTankkaart",
                column: "TankkaartenId");

            migrationBuilder.CreateIndex(
                name: "IX_Tankkaart_KaartNummer",
                table: "Tankkaart",
                column: "KaartNummer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verzekeringsmaatschappij_GemeenteId",
                table: "Verzekeringsmaatschappij",
                column: "GemeenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aanvraag");

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
                name: "ChauffeurVoertuig");

            migrationBuilder.DropTable(
                name: "GeinspecteerdeSchade");

            migrationBuilder.DropTable(
                name: "Kilometerstand");

            migrationBuilder.DropTable(
                name: "NummerplaatVoertuig");

            migrationBuilder.DropTable(
                name: "ServiceTankkaart");

            migrationBuilder.DropTable(
                name: "Onderhoud");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HerstellingType");

            migrationBuilder.DropTable(
                name: "Inspectieverslag");

            migrationBuilder.DropTable(
                name: "Nummerplaat");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.DropTable(
                name: "Herstelling");

            migrationBuilder.DropTable(
                name: "GemeldeSchade");

            migrationBuilder.DropTable(
                name: "Verzekeringsmaatschappij");

            migrationBuilder.DropTable(
                name: "Chauffeur");

            migrationBuilder.DropTable(
                name: "Voertuig");

            migrationBuilder.DropTable(
                name: "Gemeente");

            migrationBuilder.DropTable(
                name: "Tankkaart");
        }
    }
}
