using Easynvest.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easynvest.Test.Infra.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
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

            builder.ToTable("Produtos");
        }
    }
}