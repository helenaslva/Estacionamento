using EstacionamentoAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstacionamentoAPI.Data.Mappings
{
    public class PrecoMapping : IEntityTypeConfiguration<Preco>
    {
        public void Configure(EntityTypeBuilder<Preco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataValidadeInicial).IsRequired();
            builder.Property(x => x.DataValidadeFinal).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
           
        }
    }
}
