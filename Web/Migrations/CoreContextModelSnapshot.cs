﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    [DbContext(typeof(CoreContext))]
    partial class CoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
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

                    b.Property<string>("DisabledReason")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<long>("Nutrients")
                        .HasColumnType("bigint");

                    b.Property<bool>("SkipShoppingList")
                        .HasColumnType("boolean");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ingredient", t =>
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

            modelBuilder.Entity("Data.Entities.User.UserIngredientGroup", b =>
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
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserIngredients")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.Recipe", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserRecipes")
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

            modelBuilder.Entity("Data.Entities.User.UserIngredientGroup", b =>
                {
                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserIngredientGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User.UserRecipe", b =>
                {
                    b.HasOne("Data.Entities.User.Recipe", "Recipe")
                        .WithMany("UserUserRecipes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User.User", "User")
                        .WithMany("UserUserRecipes")
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
                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("Data.Entities.User.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Instructions");

                    b.Navigation("UserFeastRecipes");

                    b.Navigation("UserUserRecipes");
                });

            modelBuilder.Entity("Data.Entities.User.User", b =>
                {
                    b.Navigation("UserEmails");

                    b.Navigation("UserFootnotes");

                    b.Navigation("UserIngredientGroups");

                    b.Navigation("UserIngredients");

                    b.Navigation("UserRecipes");

                    b.Navigation("UserServings");

                    b.Navigation("UserTokens");

                    b.Navigation("UserUserRecipes");

                    b.Navigation("UserWorkouts");
                });
#pragma warning restore 612, 618
        }
    }
}
