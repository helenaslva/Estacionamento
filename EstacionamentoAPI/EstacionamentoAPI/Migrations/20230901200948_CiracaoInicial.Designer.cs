﻿// <auto-generated />
using System;
using EstacionamentoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EstacionamentoAPI.Migrations
{
    [DbContext(typeof(EstacionamentoContext))]
    [Migration("20230901200948_CiracaoInicial")]
    partial class CiracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EstacionamentoAPI.Entities.Estacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInsert")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("Duracao")
                        .HasColumnType("time(6)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PrecoId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TempoCobrado")
                        .HasColumnType("time(6)");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("PrecoId");

                    b.ToTable("Estacionamentos");
                });

            modelBuilder.Entity("EstacionamentoAPI.Entities.Preco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataValidadeFinal")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataValidadeInicial")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Precos");
                });

            modelBuilder.Entity("EstacionamentoAPI.Entities.Estacionamento", b =>
                {
                    b.HasOne("EstacionamentoAPI.Entities.Preco", "Preco")
                        .WithMany("Estacionamentos")
                        .HasForeignKey("PrecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Preco");
                });

            modelBuilder.Entity("EstacionamentoAPI.Entities.Preco", b =>
                {
                    b.Navigation("Estacionamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
