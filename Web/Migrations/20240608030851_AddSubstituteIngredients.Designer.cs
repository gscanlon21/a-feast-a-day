﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20240608030851_AddSubstituteIngredients")]
    partial class AddSubstituteIngredients
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
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

                    b.ToTable("footnote", t =>
                        {
                            t.HasComment("Sage advice");
                        });
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

                    b.ToTable("user_footnote", t =>
                        {
                            t.HasComment("Sage advice");
                        });
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

                    b.Property<int>("EmailStatus")
                        .HasColumnType("integer");

                    b.Property<string>("LastError")
                        .HasColumnType("text");

                    b.Property<DateTime>("SendAfter")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SendAttempts")
                        .HasColumnType("integer");

                    b.Property<string>("SenderId")
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_email", t =>
                        {
                            t.HasComment("A day's workout routine");
                        });
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserFeast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_feast", t =>
                        {
                            t.HasComment("A day's workout routine");
                        });
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

                    b.ToTable("user_feast_recipe", t =>
                        {
                            t.HasComment("A day's workout routine");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Allergens")
                        .HasColumnType("integer");

                    b.Property<double>("CaloriesPerServing")
                        .HasColumnType("double precision");

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<int>("GramsPerCup")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("LastUpdated")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<int>("ServingSizeGrams")
                        .HasColumnType("integer");

                    b.Property<bool>("SkipShoppingList")
                        .HasColumnType("boolean");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("ingredient", t =>
                        {
                            t.HasComment("Recipes listed on the website");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.Nutrient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<int>("Measure")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<long>("Nutrients")
                        .HasColumnType("bigint");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.ToTable("nutrient", t =>
                        {
                            t.HasComment("Recipes listed on the website");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AdjustableServings")
                        .HasColumnType("boolean");

                    b.Property<int>("Allergens")
                        .HasColumnType("integer");

                    b.Property<int>("CookTime")
                        .HasColumnType("integer");

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

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

                    b.ToTable("recipe", t =>
                        {
                            t.HasComment("Recipes listed on the website");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Attributes")
                        .HasColumnType("text");

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<int>("Measure")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int?>("QuantityDenominator")
                        .HasColumnType("integer");

                    b.Property<int?>("QuantityNumerator")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("recipe_ingredient", t =>
                        {
                            t.HasComment("Recipes listed on the website");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.RecipeInstruction", b =>
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

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("recipe_instruction", t =>
                        {
                            t.HasComment("Recipes listed on the website");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AcceptedTerms")
                        .HasColumnType("boolean");

                    b.Property<int>("AtLeastXServingsPerRecipe")
                        .HasColumnType("integer");

                    b.Property<int>("AtLeastXUniqueNutrientsPerRecipe")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ExcludeAllergens")
                        .HasColumnType("integer");

                    b.Property<int>("Features")
                        .HasColumnType("integer");

                    b.Property<int>("FootnoteCountBottom")
                        .HasColumnType("integer");

                    b.Property<int>("FootnoteCountTop")
                        .HasColumnType("integer");

                    b.Property<int>("FootnoteType")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("LastActive")
                        .HasColumnType("date");

                    b.Property<int?>("MaxIngredients")
                        .HasColumnType("integer");

                    b.Property<string>("NewsletterDisabledReason")
                        .HasColumnType("text");

                    b.Property<int>("SendDays")
                        .HasColumnType("integer");

                    b.Property<int>("SendHour")
                        .HasColumnType("integer");

                    b.Property<int>("Verbosity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("user", t =>
                        {
                            t.HasComment("User who signed up for the newsletter");
                        });
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

                    b.Property<int>("SubstituteIngredientId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("SubstituteIngredientId");

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

                    b.Property<bool>("Ignore")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsPrimary")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("LastSeen")
                        .HasColumnType("date");

                    b.Property<int>("Scale")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("user_recipe", t =>
                        {
                            t.HasComment("User's progression level of an exercise");
                        });
                });

            modelBuilder.Entity("Data.Entities.User.UserServing", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Section")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "Section");

                    b.ToTable("user_serving");
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

                    b.ToTable("user_token", t =>
                        {
                            t.HasComment("Auth tokens for a user");
                        });
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
                        .WithMany("UserWorkouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Newsletter.UserFeastRecipe", b =>
                {
                    b.HasOne("Data.Entities.User.Recipe", "Recipe")
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

            modelBuilder.Entity("Data.Entities.User.Ingredient", b =>
                {
                    b.HasOne("Data.Entities.User.Ingredient", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("Ingredients")
                        .HasForeignKey("UserId");

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.Nutrient", b =>
                {
                    b.HasOne("Data.Entities.User.Ingredient", "Ingredient")
                        .WithMany("Nutrients")
                        .HasForeignKey("IngredientId");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Data.Entities.User.Recipe", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.RecipeIngredient", b =>
                {
                    b.HasOne("Data.Entities.User.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Data.Entities.User.RecipeInstruction", b =>
                {
                    b.HasOne("Data.Entities.User.Recipe", "Recipe")
                        .WithMany("Instructions")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
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
                    b.HasOne("Data.Entities.User.Ingredient", "Ingredient")
                        .WithMany("UserIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User.Ingredient", "SubstituteIngredient")
                        .WithMany("UserSubstituteIngredients")
                        .HasForeignKey("SubstituteIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserIngredients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("SubstituteIngredient");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserNutrient", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserNutreints")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserRecipe", b =>
                {
                    b.HasOne("Data.Entities.User.Recipe", "Recipe")
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

            modelBuilder.Entity("Data.Entities.User.UserServing", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserServings")
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

            modelBuilder.Entity("Data.Entities.Newsletter.UserFeast", b =>
                {
                    b.Navigation("UserFeastRecipes");
                });

            modelBuilder.Entity("Data.Entities.User.Ingredient", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Nutrients");

                    b.Navigation("RecipeIngredients");

                    b.Navigation("UserIngredients");

                    b.Navigation("UserSubstituteIngredients");
                });

            modelBuilder.Entity("Data.Entities.User.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Instructions");

                    b.Navigation("UserFeastRecipes");

                    b.Navigation("UserRecipes");
                });

            modelBuilder.Entity("Data.Entities.User.User", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Recipes");

                    b.Navigation("UserEmails");

                    b.Navigation("UserFamilies");

                    b.Navigation("UserFootnotes");

                    b.Navigation("UserIngredients");

                    b.Navigation("UserNutreints");

                    b.Navigation("UserRecipes");

                    b.Navigation("UserServings");

                    b.Navigation("UserTokens");

                    b.Navigation("UserWorkouts");
                });
#pragma warning restore 612, 618
        }
    }
}
