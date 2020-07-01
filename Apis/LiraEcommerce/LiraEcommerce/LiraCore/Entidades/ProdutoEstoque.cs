using LiraCore.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraCore.Entidades
{
    [Table("ProdutoEstoque")]
    public class ProdutoEstoque
    {
        public int ProdutoId { get; set; }
        public TipoMedida TipoMedida { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Quantidade {get;set;}

    }
}
