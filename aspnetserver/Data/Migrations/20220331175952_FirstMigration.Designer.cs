﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetserver.Data;

#nullable disable

namespace aspnetserver.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220331175952_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("aspnetserver.Data.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is post 1 and it was so very interesting content.I have also liked the video and subscribed.",
                            Title = "Post 1"
                        },
                        new
                        {
                            Id = 2,
                            Content = "This is post 2 and it was so very interesting content.I have also liked the video and subscribed.",
                            Title = "Post 2"
                        },
                        new
                        {
                            Id = 3,
                            Content = "This is post 3 and it was so very interesting content.I have also liked the video and subscribed.",
                            Title = "Post 3"
                        },
                        new
                        {
                            Id = 4,
                            Content = "This is post 4 and it was so very interesting content.I have also liked the video and subscribed.",
                            Title = "Post 4"
                        },
                        new
                        {
                            Id = 5,
                            Content = "This is post 5 and it was so very interesting content.I have also liked the video and subscribed.",
                            Title = "Post 5"
                        },
                        new
                        {
                            Id = 6,
                            Content = "This is post 6 and it was so very interesting content.I have also liked the video and subscribed.",
                            Title = "Post 6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
