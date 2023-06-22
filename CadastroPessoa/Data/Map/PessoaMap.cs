using CadastroPessoa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroPessoa.Data.Map
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CpfOuCnpj).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DataCadastro).IsRequired().HasMaxLength(10);

        }
    }
}
