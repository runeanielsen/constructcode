using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Constructcode.Web.Persistence;

namespace Constructcode.Web.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20161107194140_RemovedPostCategory")]
    partial class RemovedPostCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Constructcode.Web.Core.Domain.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Constructcode.Web.Core.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PostId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Constructcode.Web.Core.Domain.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("Name");

                    b.Property<int?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Constructcode.Web.Core.Domain.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Constructcode.Web.Core.Domain.Category", b =>
                {
                    b.HasOne("Constructcode.Web.Core.Domain.Post")
                        .WithMany("Categories")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("Constructcode.Web.Core.Domain.Message", b =>
                {
                    b.HasOne("Constructcode.Web.Core.Domain.Post", "Post")
                        .WithMany("Messages")
                        .HasForeignKey("PostId");
                });
        }
    }
}
