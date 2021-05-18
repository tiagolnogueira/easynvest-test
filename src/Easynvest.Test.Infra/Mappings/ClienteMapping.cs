using Easynvest.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easynvest.Test.Infra.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Endereco)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Idade)
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(p => p.Saldo)
                .IsRequired()
                .HasColumnType("decimal(15,2)");

            builder.ToTable("Clientes");
        }
    }
}

