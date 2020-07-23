using LiraCore.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraCore.Entidades
{
    [Table("Produto")]
    public class Produto
    {       
        public int Id { get; set; }
        public Status Status { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Descricao { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal ValorBruto { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal PercDescAVista { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal VlDescAVista { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal VlAVista { get; set; }
        public int? Linha { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string NCM { get; set; }
        public int? TipoICMS { get; set; }
        public int? CFOPICMS { get; set; }
        public int? Origem { get; set; }
        public int? CSTICMS { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? AliquotaICMS { get; set; }
        public int? CSTPisCofins { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? AliquotaPis { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? AliquotaCofins { get; set; }        
        public DateTime DataHoraUltimaAlteracao { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public ProdutoEstoque Estoque { get; set; }
        public ProdutoImagem ProdutoImagem { get; set; }
        public Parceiro Parceiro { get; set; }
        public List<ProdutoEan> Eans { get; set; }





     
    }
}
