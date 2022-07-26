﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back.Contexts;

#nullable disable

namespace back.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("back.Models.AttachmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MessageModelId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MessageModelId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("back.Models.GroupDialogModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GroupDialogs");
                });

            modelBuilder.Entity("back.Models.MessageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GroupDialogModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PrivateDialogModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SenderUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupDialogModelId");

                    b.HasIndex("PrivateDialogModelId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("back.Models.PrivateDialogModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FirstUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int>("SecondUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FirstUserId");

                    b.HasIndex("SecondUserId");

                    b.ToTable("PrivateDialogs");
                });

            modelBuilder.Entity("back.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GroupDialogModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupDialogModelId");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("back.Models.AttachmentModel", b =>
                {
                    b.HasOne("back.Models.MessageModel", null)
                        .WithMany("Attachments")
                        .HasForeignKey("MessageModelId");
                });

            modelBuilder.Entity("back.Models.MessageModel", b =>
                {
                    b.HasOne("back.Models.GroupDialogModel", null)
                        .WithMany("Messages")
                        .HasForeignKey("GroupDialogModelId");

                    b.HasOne("back.Models.PrivateDialogModel", null)
                        .WithMany("Messages")
                        .HasForeignKey("PrivateDialogModelId");

                    b.HasOne("back.Models.UserModel", "SenderUser")
                        .WithMany()
                        .HasForeignKey("SenderUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SenderUser");
                });

            modelBuilder.Entity("back.Models.PrivateDialogModel", b =>
                {
                    b.HasOne("back.Models.UserModel", "FirstUser")
                        .WithMany()
                        .HasForeignKey("FirstUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back.Models.UserModel", "SecondUser")
                        .WithMany()
                        .HasForeignKey("SecondUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FirstUser");

                    b.Navigation("SecondUser");
                });

            modelBuilder.Entity("back.Models.UserModel", b =>
                {
                    b.HasOne("back.Models.GroupDialogModel", null)
                        .WithMany("Users")
                        .HasForeignKey("GroupDialogModelId");
                });

            modelBuilder.Entity("back.Models.GroupDialogModel", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("back.Models.MessageModel", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("back.Models.PrivateDialogModel", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
