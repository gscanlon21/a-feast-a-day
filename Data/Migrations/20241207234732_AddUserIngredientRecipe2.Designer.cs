﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20241207234732_AddUserIngredientRecipe2")]
    partial class AddUserIngredientRecipe2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.Footnote.Footnote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Source")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("footnote");
                });

            modelBuilder.Entity("Data.Entities.Footnote.UserFootnote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Source")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("UserLastSeen")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_footnote");
                });

            modelBuilder.Entity("Data.Entities.Ingredient.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("Allergens")
                        .HasColumnType("bigint");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<int>("DefaultMeasure")
                        .HasColumnType("integer");

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<double>("GramsPerCup")
                        .HasColumnType("double precision");

                    b.Property<double>("GramsPerMeasure")
                        .HasColumnType("double precision");

                    b.Property<double>("GramsPerServing")
                        .HasColumnType("double precision");

                    b.Property<DateOnly>("LastUpdated")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<bool>("SkipShoppingList")
                        .HasColumnType("boolean");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ingredient");
                });

            modelBuilder.Entity("Data.Entities.Ingredient.IngredientAlternative", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<int>("AlternativeIngredientId")
                        .HasColumnType("integer");

                    b.HasKey("IngredientId", "AlternativeIngredientId");

                    b.HasIndex("AlternativeIngredientId");

                    b.ToTable("ingredient_alternative");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("LastError")
                        .HasColumnType("text");

                    b.Property<DateTime>("SendAfter")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SendAttempts")
                        .HasColumnType("integer");

                    b.Property<string>("SenderId")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_email");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserFeast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Logs")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_feast");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserFeastRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<int>("Scale")
                        .HasColumnType("integer");

                    b.Property<int>("Section")
                        .HasColumnType("integer");

                    b.Property<int>("UserFeastId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserFeastId");

                    b.ToTable("user_feast_recipe");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserFeastRecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<int>("Measure")
                        .HasColumnType("integer");

                    b.Property<double>("Quantity")
                        .HasColumnType("double precision");

                    b.Property<int>("UserFeastRecipeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("UserFeastRecipeId");

                    b.ToTable("user_feast_recipe_ingredient");
                });

            modelBuilder.Entity("Data.Entities.Recipe.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AdjustableServings")
                        .HasColumnType("boolean");

                    b.Property<int>("CookTime")
                        .HasColumnType("integer");

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<long>("Equipment")
                        .HasColumnType("bigint");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<int>("Measure")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("PrepTime")
                        .HasColumnType("integer");

                    b.Property<int>("Section")
                        .HasColumnType("integer");

                    b.Property<int>("Servings")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("recipe");
                });

            modelBuilder.Entity("Data.Entities.Recipe.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Attributes")
                        .HasColumnType("text");

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<int?>("IngredientRecipeId")
                        .HasColumnType("integer");

                    b.Property<int>("Measure")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<bool>("Optional")
                        .HasColumnType("boolean");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("QuantityDenominator")
                        .HasColumnType("integer");

                    b.Property<int>("QuantityNumerator")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("IngredientRecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("recipe_ingredient");
                });

            modelBuilder.Entity("Data.Entities.Recipe.RecipeInstruction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("recipe_instruction");
                });

            modelBuilder.Entity("Data.Entities.User.Nutrient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<int>("Measure")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<long>("Nutrients")
                        .HasColumnType("bigint");

                    b.Property<bool>("Synthetic")
                        .HasColumnType("boolean");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.ToTable("nutrient");
                });

            modelBuilder.Entity("Data.Entities.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AcceptedTerms")
                        .HasColumnType("boolean");

                    b.Property<long>("Allergens")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Equipment")
                        .HasColumnType("bigint");

                    b.Property<int>("Features")
                        .HasColumnType("integer");

                    b.Property<int>("FootnoteCountBottom")
                        .HasColumnType("integer");

                    b.Property<int>("FootnoteCountTop")
                        .HasColumnType("integer");

                    b.Property<int>("FootnoteType")
                        .HasColumnType("integer");

                    b.Property<int>("IngredientOrder")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("LastActive")
                        .HasColumnType("date");

                    b.Property<int?>("MaxIngredients")
                        .HasColumnType("integer");

                    b.Property<string>("NewsletterDisabledReason")
                        .HasColumnType("text");

                    b.Property<int>("SendDay")
                        .HasColumnType("integer");

                    b.Property<int>("SendHour")
                        .HasColumnType("integer");

                    b.Property<int>("Verbosity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("Data.Entities.User.UserFamily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CaloriesPerDay")
                        .HasColumnType("integer");

                    b.Property<int>("Person")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_family");
                });

            modelBuilder.Entity("Data.Entities.User.UserIngredient", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<bool>("Ignore")
                        .HasColumnType("boolean");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int?>("SubstituteIngredientId")
                        .HasColumnType("integer");

                    b.Property<int?>("SubstituteRecipeId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "IngredientId", "RecipeId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("SubstituteIngredientId");

                    b.HasIndex("SubstituteRecipeId");

                    b.ToTable("user_ingredient");
                });

            modelBuilder.Entity("Data.Entities.User.UserNutrient", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<long>("Nutrient")
                        .HasColumnType("bigint");

                    b.Property<int>("End")
                        .HasColumnType("integer");

                    b.Property<int>("Start")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "Nutrient");

                    b.ToTable("user_nutrient");
                });

            modelBuilder.Entity("Data.Entities.User.UserRecipe", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<int>("Section")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("IgnoreUntil")
                        .HasColumnType("date");

                    b.Property<int>("LagRefreshXWeeks")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("LastSeen")
                        .HasColumnType("date");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("PadRefreshXWeeks")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("RefreshAfter")
                        .HasColumnType("date");

                    b.Property<int>("Servings")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RecipeId", "Section");

                    b.HasIndex("RecipeId");

                    b.ToTable("user_recipe");
                });

            modelBuilder.Entity("Data.Entities.User.UserSection", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Section")
                        .HasColumnType("integer");

                    b.Property<int>("AtLeastXNutrientsPerRecipe")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "Section");

                    b.ToTable("user_section");
                });

            modelBuilder.Entity("Data.Entities.User.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "Token");

                    b.ToTable("user_token");
                });

            modelBuilder.Entity("Data.Entities.Footnote.UserFootnote", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserFootnotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Ingredient.Ingredient", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("Ingredients")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Ingredient.IngredientAlternative", b =>
                {
                    b.HasOne("Data.Entities.Ingredient.Ingredient", "AlternativeIngredient")
                        .WithMany("AlternativeIngredients")
                        .HasForeignKey("AlternativeIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Ingredient.Ingredient", "Ingredient")
                        .WithMany("Alternatives")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlternativeIngredient");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserEmail", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserEmails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserFeast", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserFeasts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserFeastRecipe", b =>
                {
                    b.HasOne("Data.Entities.Recipe.Recipe", "Recipe")
                        .WithMany("UserFeastRecipes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Newsletter.UserFeast", "UserFeast")
                        .WithMany("UserFeastRecipes")
                        .HasForeignKey("UserFeastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("UserFeast");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserFeastRecipeIngredient", b =>
                {
                    b.HasOne("Data.Entities.Ingredient.Ingredient", "Ingredient")
                        .WithMany("UserFeastRecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Newsletter.UserFeastRecipe", "UserFeastRecipe")
                        .WithMany("UserFeastRecipeIngredients")
                        .HasForeignKey("UserFeastRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("UserFeastRecipe");
                });

            modelBuilder.Entity("Data.Entities.Recipe.Recipe", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Recipe.RecipeIngredient", b =>
                {
                    b.HasOne("Data.Entities.Ingredient.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId");

                    b.HasOne("Data.Entities.Recipe.Recipe", "IngredientRecipe")
                        .WithMany("RecipeIngredientRecipes")
                        .HasForeignKey("IngredientRecipeId");

                    b.HasOne("Data.Entities.Recipe.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("IngredientRecipe");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Data.Entities.Recipe.RecipeInstruction", b =>
                {
                    b.HasOne("Data.Entities.Recipe.Recipe", "Recipe")
                        .WithMany("Instructions")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Data.Entities.User.Nutrient", b =>
                {
                    b.HasOne("Data.Entities.Ingredient.Ingredient", "Ingredient")
                        .WithMany("Nutrients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Data.Entities.User.UserFamily", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserFamilies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserIngredient", b =>
                {
                    b.HasOne("Data.Entities.Ingredient.Ingredient", "Ingredient")
                        .WithMany("UserIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Recipe.Recipe", "Recipe")
                        .WithMany("UserIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Ingredient.Ingredient", "SubstituteIngredient")
                        .WithMany("UserSubstituteIngredients")
                        .HasForeignKey("SubstituteIngredientId");

                    b.HasOne("Data.Entities.Recipe.Recipe", "SubstituteRecipe")
                        .WithMany("UserSubstituteRecipes")
                        .HasForeignKey("SubstituteRecipeId");

                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserIngredients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");

                    b.Navigation("SubstituteIngredient");

                    b.Navigation("SubstituteRecipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserNutrient", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserNutrients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserRecipe", b =>
                {
                    b.HasOne("Data.Entities.Recipe.Recipe", "Recipe")
                        .WithMany("UserRecipes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserRecipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserSection", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserSections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserToken", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Ingredient.Ingredient", b =>
                {
                    b.Navigation("AlternativeIngredients");

                    b.Navigation("Alternatives");

                    b.Navigation("Nutrients");

                    b.Navigation("RecipeIngredients");

                    b.Navigation("UserFeastRecipeIngredients");

                    b.Navigation("UserIngredients");

                    b.Navigation("UserSubstituteIngredients");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserFeast", b =>
                {
                    b.Navigation("UserFeastRecipes");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserFeastRecipe", b =>
                {
                    b.Navigation("UserFeastRecipeIngredients");
                });

            modelBuilder.Entity("Data.Entities.Recipe.Recipe", b =>
                {
                    b.Navigation("Instructions");

                    b.Navigation("RecipeIngredientRecipes");

                    b.Navigation("RecipeIngredients");

                    b.Navigation("UserFeastRecipes");

                    b.Navigation("UserIngredients");

                    b.Navigation("UserRecipes");

                    b.Navigation("UserSubstituteRecipes");
                });

            modelBuilder.Entity("Data.Entities.User.User", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Recipes");

                    b.Navigation("UserEmails");

                    b.Navigation("UserFamilies");

                    b.Navigation("UserFeasts");

                    b.Navigation("UserFootnotes");

                    b.Navigation("UserIngredients");

                    b.Navigation("UserNutrients");

                    b.Navigation("UserRecipes");

                    b.Navigation("UserSections");

                    b.Navigation("UserTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
