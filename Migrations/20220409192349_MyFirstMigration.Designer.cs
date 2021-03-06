// <auto-generated />
using System;
using Api.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(KekemelikDbContext))]
    [Migration("20220409192349_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Api.Ef.Models.İl", b =>
                {
                    b.Property<int>("İlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("İlId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("İlId");

                    b.ToTable("İls");
                });

            modelBuilder.Entity("Api.Ef.Models.İlçe", b =>
                {
                    b.Property<int>("İlçeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("İlçeId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("İlId")
                        .HasColumnType("int");

                    b.HasKey("İlçeId");

                    b.HasIndex("İlId");

                    b.ToTable("İlçes");
                });

            modelBuilder.Entity("Api.Ef.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TherapistId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.HasIndex("TherapistId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Api.Ef.Models.Therapist", b =>
                {
                    b.Property<int>("TherapistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TherapistId"), 1L, 1);

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aproved")
                        .HasColumnType("bit");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("İlçeId")
                        .HasColumnType("int");

                    b.HasKey("TherapistId");

                    b.HasIndex("İlçeId");

                    b.ToTable("Therapists");
                });

            modelBuilder.Entity("Api.Ef.Models.TherapistMessage", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TherapistId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("TherapistId");

                    b.HasIndex("UserId");

                    b.ToTable("TherapistMessages");
                });

            modelBuilder.Entity("Api.Ef.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Api.Ef.Models.UserMessage", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("User1Id")
                        .HasColumnType("int");

                    b.Property<int>("User2Id")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("User1Id");

                    b.HasIndex("User2Id");

                    b.ToTable("UserMessages");
                });

            modelBuilder.Entity("Api.Ef.Models.İlçe", b =>
                {
                    b.HasOne("Api.Ef.Models.İl", "İl")
                        .WithMany("İlçeler")
                        .HasForeignKey("İlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("İl");
                });

            modelBuilder.Entity("Api.Ef.Models.Post", b =>
                {
                    b.HasOne("Api.Ef.Models.Therapist", "Publisher")
                        .WithMany("Posts")
                        .HasForeignKey("TherapistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Api.Ef.Models.Therapist", b =>
                {
                    b.HasOne("Api.Ef.Models.İlçe", "İlçe")
                        .WithMany()
                        .HasForeignKey("İlçeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("İlçe");
                });

            modelBuilder.Entity("Api.Ef.Models.TherapistMessage", b =>
                {
                    b.HasOne("Api.Ef.Models.Therapist", "Therapist")
                        .WithMany("Messages")
                        .HasForeignKey("TherapistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Ef.Models.User", "User")
                        .WithMany("TherapistMessages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Therapist");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Ef.Models.UserMessage", b =>
                {
                    b.HasOne("Api.Ef.Models.User", "User1")
                        .WithMany("User1Messages")
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Api.Ef.Models.User", "User2")
                        .WithMany("User2Messages")
                        .HasForeignKey("User2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("Api.Ef.Models.İl", b =>
                {
                    b.Navigation("İlçeler");
                });

            modelBuilder.Entity("Api.Ef.Models.Therapist", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Api.Ef.Models.User", b =>
                {
                    b.Navigation("TherapistMessages");

                    b.Navigation("User1Messages");

                    b.Navigation("User2Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
