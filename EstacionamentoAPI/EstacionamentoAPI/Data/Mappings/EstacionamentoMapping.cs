using EstacionamentoAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstacionamentoAPI.Data.Mappings
{
    public class EstacionamentoMapping : IEntityTypeConfiguration<Estacionamento>
    {
        public void Configure(EntityTypeBuilder<Estacionamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Placa).IsRequired();
            builder.Property(x => x.DataEntrada).IsRequired();
            builder.Property(x => x.DataSaida).IsRequired();
            builder.Property(x => x.Duracao).IsRequired();
            builder.Property(x => x.TempoCobrado).IsRequired();
            builder.Property(x => x.DataInsert).IsRequired();
            builder.Property(x => x.DataAlteracao).IsRequired(false);
           

            builder
                .HasOne(x => x.Preco)
                .WithMany(x => x.Estacionamentos)
                .HasForeignKey(x => x.PrecoId)
                .HasPrincipalKey(x => x.Id);

               


        }
    }
}
