using Easynvest.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easynvest.Test.Infra.Mappings
{
    public class OrdemCompraMapping : IEntityTypeConfiguration<OrdemCompra>
    {
        public void Configure(EntityTypeBuilder<OrdemCompra> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataOperacao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Estoque)
                .IsRequired()
                .HasColumnType("decimal(15,2)");

            builder.Property(p => p.PrecoUnitario)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.ValorMinimoDeCompra)
                .IsRequired()
                .HasColumnType("Integer");

            builder.HasOne(f => f.Endereco)
               .WithOne(e => e.Fornecedor);

            builder.HasOne(f => f.Endereco)
               .WithOne(e => e.Fornecedor);

            builder.ToTable("Produtos");
        }
    }
}

public DateTime DataOperacao { get; set; }
public int ProdutoId { get; set; }
public string ClienteId { get; set; }
public int QuantidadeSolicitada { get; set; }
public decimal ValorOperacao { get; set; }
public decimal PrecoUnitario { get; set; }
public OrdemCompraStatus Status { get; set; }