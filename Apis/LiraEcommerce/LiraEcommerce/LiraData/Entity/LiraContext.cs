using LiraConnection.Interfaces;
using LiraCore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LiraData.Entity
{
    public class LiraContext : DbContext
    {
        private ISQLConnection _Conexao;
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoEan> ProdutoEan { get; set; }
        public DbSet<ProdutoEstoque> ProdutoEstoque { get; set; }
        public DbSet<ProdutoImagem> ProdutoImagem { get; set; }
        public DbSet<CategoriaProduto> CategoriaProduto { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

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
            ConfigurarChavesParceiro(modelBuilder);
            ConfigurarChavesCliente(modelBuilder);
        }
        private void ConfigurarRelacionamentos(ModelBuilder modelBuilder)
        {
            ConfigurarRelacionamentosProduto(modelBuilder);
            ConfigurarRelacionamentosParceiro(modelBuilder);
            ConfigurarRelacionamentosCliente(modelBuilder);
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

            modelBuilder.Entity<CategoriaProduto>()
                .HasKey(P => P.Id);
        }
         private void ConfigurarRelacionamentosProduto(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Produto>()
                .HasOne(P => P.Categoria)
                .WithMany(P => P.Produto)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .HasOne(P => P.Parceiro)
                .WithMany(Pa => Pa.Produtos)
                .IsRequired();

            modelBuilder.Entity<ProdutoEan>()
                .HasOne(P => P.Produto)
                .WithMany(E => E.Eans)
                .HasForeignKey(E => E.ProdutoId)
                .IsRequired();
            
            modelBuilder.Entity<ProdutoEstoque>()
                .HasOne(E => E.Produto)
                .WithOne(P => P.Estoque)                
                .IsRequired();                
            
            modelBuilder.Entity<ProdutoImagem>()
                .HasOne(I => I.Produto)
                .WithOne(P => P.ProdutoImagem)                
                .IsRequired();

            modelBuilder.Entity<CategoriaProduto>()
                .HasMany(C => C.Produto)
                .WithOne(P => P.Categoria);

        }
        #endregion
        #region Parceiro
        private void ConfigurarChavesParceiro(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parceiro>()
                .HasKey(P => P.Id);
        }

        private void ConfigurarRelacionamentosParceiro(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Parceiro>()
                .HasMany(Pa => Pa.Produtos)
                .WithOne(P => P.Parceiro);

            modelBuilder.Entity<Parceiro>()
                .HasMany(C => C.Clientes)
                .WithOne(P => P.Parceiro)
                .IsRequired();

        }
        #endregion
        #region Cliente
        private void ConfigurarChavesCliente(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(P => P.Id);
        }

        private void ConfigurarRelacionamentosCliente(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>()
                .HasOne(P => P.Parceiro)
                .WithMany(C => C.Clientes);

            modelBuilder.Entity<Cliente>()
                .HasMany(E => E.ClienteEndereco)
                .WithOne(C => C.Cliente);
        }
        #endregion
    }
}
