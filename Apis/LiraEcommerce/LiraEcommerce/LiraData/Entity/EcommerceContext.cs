using LiraConnection.Interfaces;
using LiraCore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LiraData.Entity
{
    public class EcommerceContext : DbContext
    {
        ISQLConnection _Conexao { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoEan> ProdutoEan { get; set; }
        public DbSet<ProdutoEstoque> ProdutoEstoque { get; set; }
        public DbSet<ProdutoImagem> ProdutoImagem { get; set; }
        public DbSet<TipoProduto> TiposProduto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            _Conexao = ConexaoFactory.GetConexao();

            options.UseSqlServer(_Conexao.SQLServerString(LiraConnection.Enum.SqlServer.Ecommerce, true));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurarChaves(modelBuilder);          
            ConfigurarRelacionamentos(modelBuilder);
            
        }

        private void ConfigurarChaves(ModelBuilder modelBuilder)
        {
            ConfigurarChavesProduto(modelBuilder);
        }
        private void ConfigurarRelacionamentos(ModelBuilder modelBuilder)
        {
            ConfigurarRelacionamentosProduto(modelBuilder);
        }
        #region Produto
        private void ConfigurarChavesProduto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasKey(P => P.Id);

            modelBuilder.Entity<ProdutoEan>()
                .HasKey(P => new { P.ProdutoId, P.EAN });

            modelBuilder.Entity<ProdutoEstoque>()
                .HasKey(P => P.ProdutoId);

            modelBuilder.Entity<ProdutoImagem>()
                .HasKey(P => P.ProdutoId);

            modelBuilder.Entity<TipoProduto>()
                .HasKey(P => P.Codigo);
        }
         private void ConfigurarRelacionamentosProduto(ModelBuilder modelBuilder)
        {
            // Relação unica, Eans não tem ligação inversa
            modelBuilder.Entity<Produto>()
                .HasMany(P => P.Eans)
                .WithOne(E => E.Produto)
                .HasForeignKey(E => E.ProdutoId)                
                .IsRequired();

            // Relação unica, Estoque não tem ligação inversa
            modelBuilder.Entity<Produto>()
                .HasOne(P => P.Estoque)
                .WithOne()
                .HasForeignKey<ProdutoEstoque>( E => E.ProdutoId)
                .IsRequired();                

            // Relação unica, Imagem não tem ligação inversa
            modelBuilder.Entity<Produto>()
                .HasOne(P => P.ProdutoImagem)
                .WithOne()
                .HasForeignKey<ProdutoImagem>(I => I.ProdutoId)
                .IsRequired();

            // Relação unica, TipoProduto não tem ligação inversa
            
            modelBuilder.Entity<Produto>()
                .HasOne(P => P.TipoProduto)
                .WithOne(P => P.Produto)    
                .HasForeignKey<TipoProduto>(P => P.ProdutoId)
                .IsRequired();
        }
        #endregion
    }
}
