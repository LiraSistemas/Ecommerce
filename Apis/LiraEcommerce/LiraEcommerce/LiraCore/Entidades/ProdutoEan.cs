using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
