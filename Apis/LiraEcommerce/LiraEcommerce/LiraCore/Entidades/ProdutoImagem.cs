using System.ComponentModel.DataAnnotations.Schema;

namespace LiraCore.Entidades
{
    [Table("ProdutoImagem")]
    public class ProdutoImagem
    {
        public int ProdutoId { get; set; }
        public byte[] Imagem { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string LinkImagem {get;set;}
        public Produto Produto { get; set; }
    }
}
