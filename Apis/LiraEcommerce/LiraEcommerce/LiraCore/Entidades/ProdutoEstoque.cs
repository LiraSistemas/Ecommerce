using LiraCore.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraCore.Entidades
{
    [Table("ProdutoEstoque")]
    public class ProdutoEstoque
    {
        public int ProdutoId { get; set; }
        public TipoMedida TipoMedida { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Quantidade {get;set;}

        public Produto Produto { get; set; }

    }
}
