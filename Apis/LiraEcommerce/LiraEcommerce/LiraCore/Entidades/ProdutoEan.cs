using System.ComponentModel.DataAnnotations.Schema;

namespace LiraCore.Entidades
{

    [Table("ProdutoEan")]
    public class ProdutoEan
    {        
        public int ProdutoId { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal EAN { get; set; }
        public Produto Produto { get; set; }        
    }
}
