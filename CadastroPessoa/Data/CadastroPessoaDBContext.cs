using CadastroPessoa.Data.Map;
using CadastroPessoa.Models.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Data
{
    public class CadastroPessoaDBContext : DbContext
    {
        public CadastroPessoaDBContext(DbContextOptions<CadastroPessoaDBContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
