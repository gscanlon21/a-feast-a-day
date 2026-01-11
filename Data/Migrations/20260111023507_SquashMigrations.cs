using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "footnote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_footnote", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gene", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AcceptedTerms = table.Column<bool>(type: "boolean", nullable: false),
                    FootnoteType = table.Column<int>(type: "integer", nullable: false),
                    SendDay = table.Column<int>(type: "integer", nullable: false),
                    Equipment = table.Column<int>(type: "integer", nullable: false),
                    SendHour = table.Column<int>(type: "integer", nullable: false),
                    FontSizeAdjust = table.Column<int>(type: "integer", nullable: false),
                    MaxIngredients = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Verbosity = table.Column<int>(type: "integer", nullable: false),
                    Allergens = table.Column<long>(type: "bigint", nullable: false),
                    LastActive = table.Column<DateOnly>(type: "date", nullable: true),
                    NewsletterDisabledReason = table.Column<string>(type: "text", nullable: true),
                    Features = table.Column<int>(type: "integer", nullable: false),
                    IngredientOrder = table.Column<int>(type: "integer", nullable: false),
                    FootnoteCountTop = table.Column<int>(type: "integer", nullable: false),
                    FootnoteCountBottom = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "snp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    GeneId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_snp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_snp_gene_GeneId",
                        column: x => x.GeneId,
                        principalTable: "gene",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Group = table.Column<string>(type: "text", nullable: false),
                    SkipShoppingList = table.Column<bool>(type: "boolean", nullable: false),
                    Allergens = table.Column<long>(type: "bigint", nullable: false),
                    Category = table.Column<long>(type: "bigint", nullable: false),
                    DefaultMeasure = table.Column<int>(type: "integer", nullable: false),
                    GramsPerMeasure = table.Column<double>(type: "double precision", nullable: false),
                    GramsPerFineCup = table.Column<double>(type: "double precision", nullable: false),
                    GramsPerCoarseCup = table.Column<double>(type: "double precision", nullable: false),
                    GramsPerServing = table.Column<double>(type: "double precision", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true),
                    LastUpdated = table.Column<DateOnly>(type: "date", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingredient_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Section = table.Column<int>(type: "integer", nullable: false),
                    Measure = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    PrepTime = table.Column<int>(type: "integer", nullable: false),
                    CookTime = table.Column<int>(type: "integer", nullable: false),
                    Servings = table.Column<int>(type: "integer", nullable: false),
                    BaseRecipe = table.Column<bool>(type: "boolean", nullable: false),
                    AdjustableServings = table.Column<bool>(type: "boolean", nullable: false),
                    KeepIngredientOrder = table.Column<bool>(type: "boolean", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipe_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user_email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    SendAfter = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SenderId = table.Column<string>(type: "text", nullable: true),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    SendAttempts = table.Column<int>(type: "integer", nullable: false),
                    LastError = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_email_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_family",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Person = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    CaloriesPerDay = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_family", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_family_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_feast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Logs = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_feast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_feast_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_footnote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LastSeen = table.Column<DateOnly>(type: "date", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_footnote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_footnote_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_nutrient",
                columns: table => new
                {
                    Nutrient = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<int>(type: "integer", nullable: false),
                    End = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_nutrient", x => new { x.UserId, x.Nutrient });
                    table.ForeignKey(
                        name: "FK_user_nutrient_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_section",
                columns: table => new
                {
                    Section = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    AtLeastXNutrientsPerRecipe = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_section", x => new { x.UserId, x.Section });
                    table.ForeignKey(
                        name: "FK_user_section_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_token",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_token_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "study",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    SNPId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study", x => x.Id);
                    table.ForeignKey(
                        name: "FK_study_snp_SNPId",
                        column: x => x.SNPId,
                        principalTable: "snp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ingredient_alternative",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    AlternativeIngredientId = table.Column<int>(type: "integer", nullable: false),
                    Scale = table.Column<double>(type: "double precision", nullable: false, defaultValue: 1.0),
                    IsAggregateElement = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient_alternative", x => new { x.IngredientId, x.AlternativeIngredientId });
                    table.ForeignKey(
                        name: "FK_ingredient_alternative_ingredient_AlternativeIngredientId",
                        column: x => x.AlternativeIngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ingredient_alternative_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nutrient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    Nutrients = table.Column<long>(type: "bigint", nullable: false),
                    Measure = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutrient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nutrient_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_ingredient",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_ingredient", x => new { x.UserId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_user_ingredient_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_ingredient_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipe_ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: true),
                    IngredientRecipeId = table.Column<int>(type: "integer", nullable: true),
                    QuantityNumerator = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    QuantityDenominator = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Optional = table.Column<bool>(type: "boolean", nullable: false),
                    Adjustable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CoarseCut = table.Column<bool>(type: "boolean", nullable: false),
                    Measure = table.Column<int>(type: "integer", nullable: false),
                    CookedIngredientId = table.Column<int>(type: "integer", nullable: true),
                    CookedScale = table.Column<double>(type: "double precision", nullable: false, defaultValue: 1.0),
                    Attributes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipe_ingredient_ingredient_CookedIngredientId",
                        column: x => x.CookedIngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_recipe_ingredient_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_recipe_ingredient_recipe_IngredientRecipeId",
                        column: x => x.IngredientRecipeId,
                        principalTable: "recipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_recipe_ingredient_recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipe_instruction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Equipment = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RecipeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_instruction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipe_instruction_recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_recipe",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    IgnoreUntil = table.Column<DateOnly>(type: "date", nullable: true),
                    LastSeen = table.Column<DateOnly>(type: "date", nullable: true),
                    RefreshAfter = table.Column<DateOnly>(type: "date", nullable: true),
                    LagRefreshXWeeks = table.Column<int>(type: "integer", nullable: false),
                    PadRefreshXWeeks = table.Column<int>(type: "integer", nullable: false),
                    Servings = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_recipe", x => new { x.UserId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_user_recipe_recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_recipe_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_feast_recipe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Scale = table.Column<int>(type: "integer", nullable: false),
                    ParentRecipeId = table.Column<int>(type: "integer", nullable: true),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    UserFeastId = table.Column<int>(type: "integer", nullable: false),
                    Section = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_feast_recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_feast_recipe_recipe_ParentRecipeId",
                        column: x => x.ParentRecipeId,
                        principalTable: "recipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_feast_recipe_recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_feast_recipe_user_feast_UserFeastId",
                        column: x => x.UserFeastId,
                        principalTable: "user_feast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "study_ingredient",
                columns: table => new
                {
                    StudyId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_ingredient", x => new { x.StudyId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_study_ingredient_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_study_ingredient_study_StudyId",
                        column: x => x.StudyId,
                        principalTable: "study",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_recipe_ingredient",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RecipeIngredientId = table.Column<int>(type: "integer", nullable: false),
                    Measure = table.Column<int>(type: "integer", nullable: true),
                    QuantityNumerator = table.Column<int>(type: "integer", nullable: true),
                    QuantityDenominator = table.Column<int>(type: "integer", nullable: true),
                    SubstituteRecipeId = table.Column<int>(type: "integer", nullable: true),
                    SubstituteIngredientId = table.Column<int>(type: "integer", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Ignore = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_recipe_ingredient", x => new { x.UserId, x.RecipeIngredientId });
                    table.ForeignKey(
                        name: "FK_user_recipe_ingredient_ingredient_SubstituteIngredientId",
                        column: x => x.SubstituteIngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_recipe_ingredient_recipe_SubstituteRecipeId",
                        column: x => x.SubstituteRecipeId,
                        principalTable: "recipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_recipe_ingredient_recipe_ingredient_RecipeIngredientId",
                        column: x => x.RecipeIngredientId,
                        principalTable: "recipe_ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_recipe_ingredient_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_feast_recipe_ingredient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    RecipeIngredientId = table.Column<int>(type: "integer", nullable: false),
                    UserFeastRecipeId = table.Column<long>(type: "bigint", nullable: false),
                    CookedScale = table.Column<double>(type: "double precision", nullable: false, defaultValue: 1.0),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    Measure = table.Column<int>(type: "integer", nullable: false),
                    CoarseCut = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_feast_recipe_ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_feast_recipe_ingredient_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_feast_recipe_ingredient_user_feast_recipe_UserFeastRec~",
                        column: x => x.UserFeastRecipeId,
                        principalTable: "user_feast_recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_UserId",
                table: "ingredient",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_UserId_DisabledReason",
                table: "ingredient",
                column: "UserId",
                filter: "\"DisabledReason\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_alternative_AlternativeIngredientId",
                table: "ingredient_alternative",
                column: "AlternativeIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_alternative_IngredientId_IsAggregateElement",
                table: "ingredient_alternative",
                columns: new[] { "IngredientId", "IsAggregateElement" });

            migrationBuilder.CreateIndex(
                name: "IX_nutrient_IngredientId",
                table: "nutrient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_UserId",
                table: "recipe",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_UserId_DisabledReason",
                table: "recipe",
                column: "UserId",
                filter: "\"DisabledReason\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredient_CookedIngredientId",
                table: "recipe_ingredient",
                column: "CookedIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredient_IngredientId",
                table: "recipe_ingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredient_IngredientRecipeId",
                table: "recipe_ingredient",
                column: "IngredientRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredient_RecipeId",
                table: "recipe_ingredient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_instruction_RecipeId",
                table: "recipe_instruction",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_snp_GeneId",
                table: "snp",
                column: "GeneId");

            migrationBuilder.CreateIndex(
                name: "IX_study_SNPId",
                table: "study",
                column: "SNPId");

            migrationBuilder.CreateIndex(
                name: "IX_study_ingredient_IngredientId",
                table: "study_ingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                table: "user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_email_UserId",
                table: "user_email",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_family_UserId",
                table: "user_family",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_UserId",
                table: "user_feast",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_ParentRecipeId",
                table: "user_feast_recipe",
                column: "ParentRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_RecipeId",
                table: "user_feast_recipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_UserFeastId",
                table: "user_feast_recipe",
                column: "UserFeastId");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_ingredient_IngredientId",
                table: "user_feast_recipe_ingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_ingredient_UserFeastRecipeId",
                table: "user_feast_recipe_ingredient",
                column: "UserFeastRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_footnote_UserId",
                table: "user_footnote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ingredient_IngredientId",
                table: "user_ingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_user_recipe_RecipeId",
                table: "user_recipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_recipe_ingredient_RecipeIngredientId",
                table: "user_recipe_ingredient",
                column: "RecipeIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_user_recipe_ingredient_SubstituteIngredientId",
                table: "user_recipe_ingredient",
                column: "SubstituteIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_user_recipe_ingredient_SubstituteRecipeId",
                table: "user_recipe_ingredient",
                column: "SubstituteRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_token_UserId_Token",
                table: "user_token",
                columns: new[] { "UserId", "Token" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "footnote");

            migrationBuilder.DropTable(
                name: "ingredient_alternative");

            migrationBuilder.DropTable(
                name: "nutrient");

            migrationBuilder.DropTable(
                name: "recipe_instruction");

            migrationBuilder.DropTable(
                name: "study_ingredient");

            migrationBuilder.DropTable(
                name: "user_email");

            migrationBuilder.DropTable(
                name: "user_family");

            migrationBuilder.DropTable(
                name: "user_feast_recipe_ingredient");

            migrationBuilder.DropTable(
                name: "user_footnote");

            migrationBuilder.DropTable(
                name: "user_ingredient");

            migrationBuilder.DropTable(
                name: "user_nutrient");

            migrationBuilder.DropTable(
                name: "user_recipe");

            migrationBuilder.DropTable(
                name: "user_recipe_ingredient");

            migrationBuilder.DropTable(
                name: "user_section");

            migrationBuilder.DropTable(
                name: "user_token");

            migrationBuilder.DropTable(
                name: "study");

            migrationBuilder.DropTable(
                name: "user_feast_recipe");

            migrationBuilder.DropTable(
                name: "recipe_ingredient");

            migrationBuilder.DropTable(
                name: "snp");

            migrationBuilder.DropTable(
                name: "user_feast");

            migrationBuilder.DropTable(
                name: "ingredient");

            migrationBuilder.DropTable(
                name: "recipe");

            migrationBuilder.DropTable(
                name: "gene");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
