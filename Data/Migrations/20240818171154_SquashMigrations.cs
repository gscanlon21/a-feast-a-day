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
                },
                comment: "Sage advice");

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
                    MaxIngredients = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Verbosity = table.Column<int>(type: "integer", nullable: false),
                    ExcludeAllergens = table.Column<long>(type: "bigint", nullable: false),
                    LastActive = table.Column<DateOnly>(type: "date", nullable: true),
                    NewsletterDisabledReason = table.Column<string>(type: "text", nullable: true),
                    Features = table.Column<int>(type: "integer", nullable: false),
                    FootnoteCountTop = table.Column<int>(type: "integer", nullable: false),
                    FootnoteCountBottom = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                },
                comment: "User who signed up for the newsletter");

            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SkipShoppingList = table.Column<bool>(type: "boolean", nullable: false),
                    Allergens = table.Column<long>(type: "bigint", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    DefaultMeasure = table.Column<int>(type: "integer", nullable: false),
                    GramsPerMeasure = table.Column<double>(type: "double precision", nullable: false),
                    GramsPerCup = table.Column<double>(type: "double precision", nullable: false),
                    GramsPerServing = table.Column<double>(type: "double precision", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
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
                },
                comment: "Recipes listed on the website");

            migrationBuilder.CreateTable(
                name: "recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PrepTime = table.Column<int>(type: "integer", nullable: false),
                    CookTime = table.Column<int>(type: "integer", nullable: false),
                    Servings = table.Column<int>(type: "integer", nullable: false),
                    Measure = table.Column<int>(type: "integer", nullable: false),
                    AdjustableServings = table.Column<bool>(type: "boolean", nullable: false),
                    Equipment = table.Column<int>(type: "integer", nullable: false),
                    Section = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
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
                },
                comment: "Recipes listed on the website");

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
                },
                comment: "A day's workout routine");

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
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateTable(
                name: "user_footnote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserLastSeen = table.Column<DateOnly>(type: "date", nullable: false),
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
                },
                comment: "Sage advice");

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
                name: "user_serving",
                columns: table => new
                {
                    Section = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    AtLeastXNutrientsPerRecipe = table.Column<int>(type: "integer", nullable: false),
                    AtLeastXServingsPerRecipe = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serving", x => new { x.UserId, x.Section });
                    table.ForeignKey(
                        name: "FK_user_serving_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                },
                comment: "Auth tokens for a user");

            migrationBuilder.CreateTable(
                name: "ingredient_alternative",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    AlternativeIngredientId = table.Column<int>(type: "integer", nullable: false)
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
                },
                comment: "Alternative ingredients");

            migrationBuilder.CreateTable(
                name: "nutrient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IngredientId = table.Column<int>(type: "integer", nullable: true),
                    Nutrients = table.Column<long>(type: "bigint", nullable: false),
                    Measure = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    Synthetic = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutrient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nutrient_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id");
                },
                comment: "Recipes listed on the website");

            migrationBuilder.CreateTable(
                name: "recipe_ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: true),
                    IngredientRecipeId = table.Column<int>(type: "integer", nullable: true),
                    QuantityNumerator = table.Column<int>(type: "integer", nullable: false),
                    QuantityDenominator = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Optional = table.Column<bool>(type: "boolean", nullable: false),
                    Measure = table.Column<int>(type: "integer", nullable: false),
                    Attributes = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_ingredient", x => x.Id);
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
                },
                comment: "A recipe's ingredients");

            migrationBuilder.CreateTable(
                name: "recipe_instruction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
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
                },
                comment: "Recipes listed on the website");

            migrationBuilder.CreateTable(
                name: "user_ingredient",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    SubstituteIngredientId = table.Column<int>(type: "integer", nullable: true),
                    SubstituteRecipeId = table.Column<int>(type: "integer", nullable: true),
                    Ignore = table.Column<bool>(type: "boolean", nullable: false)
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
                        name: "FK_user_ingredient_ingredient_SubstituteIngredientId",
                        column: x => x.SubstituteIngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_ingredient_recipe_SubstituteRecipeId",
                        column: x => x.SubstituteRecipeId,
                        principalTable: "recipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_ingredient_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_recipe",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    Ignore = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    LastSeen = table.Column<DateOnly>(type: "date", nullable: false),
                    RefreshAfter = table.Column<DateOnly>(type: "date", nullable: true),
                    LagRefreshXWeeks = table.Column<int>(type: "integer", nullable: false),
                    PadRefreshXWeeks = table.Column<int>(type: "integer", nullable: false)
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
                },
                comment: "User's progression level of an exercise");

            migrationBuilder.CreateTable(
                name: "user_feast_recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Scale = table.Column<int>(type: "integer", nullable: false),
                    UserFeastId = table.Column<int>(type: "integer", nullable: false),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Section = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_feast_recipe", x => x.Id);
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
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_UserId",
                table: "ingredient",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_alternative_AlternativeIngredientId",
                table: "ingredient_alternative",
                column: "AlternativeIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_nutrient_IngredientId",
                table: "nutrient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_UserId",
                table: "recipe",
                column: "UserId");

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
                name: "IX_user_feast_recipe_RecipeId",
                table: "user_feast_recipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_UserFeastId",
                table: "user_feast_recipe",
                column: "UserFeastId");

            migrationBuilder.CreateIndex(
                name: "IX_user_footnote_UserId",
                table: "user_footnote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ingredient_IngredientId",
                table: "user_ingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ingredient_SubstituteIngredientId",
                table: "user_ingredient",
                column: "SubstituteIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ingredient_SubstituteRecipeId",
                table: "user_ingredient",
                column: "SubstituteRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_recipe_RecipeId",
                table: "user_recipe",
                column: "RecipeId");

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
                name: "recipe_ingredient");

            migrationBuilder.DropTable(
                name: "recipe_instruction");

            migrationBuilder.DropTable(
                name: "user_email");

            migrationBuilder.DropTable(
                name: "user_family");

            migrationBuilder.DropTable(
                name: "user_feast_recipe");

            migrationBuilder.DropTable(
                name: "user_footnote");

            migrationBuilder.DropTable(
                name: "user_ingredient");

            migrationBuilder.DropTable(
                name: "user_nutrient");

            migrationBuilder.DropTable(
                name: "user_recipe");

            migrationBuilder.DropTable(
                name: "user_serving");

            migrationBuilder.DropTable(
                name: "user_token");

            migrationBuilder.DropTable(
                name: "user_feast");

            migrationBuilder.DropTable(
                name: "ingredient");

            migrationBuilder.DropTable(
                name: "recipe");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
