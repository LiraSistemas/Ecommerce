using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraCore.Entidades
{
    [Table("ProdutoImagem")]
    public class ProdutoImagem
    {
        public int ProdutoId { get; set; }
        public byte[] Imagem { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string LinkImagem {get;set;}
    }
}
