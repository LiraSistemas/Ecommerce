using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraCore.Entidades
{
    [Table("TipoProduto")]
    public class TipoProduto
    {
        public int Codigo { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Descricao { get; set; }
        
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
    }
}
