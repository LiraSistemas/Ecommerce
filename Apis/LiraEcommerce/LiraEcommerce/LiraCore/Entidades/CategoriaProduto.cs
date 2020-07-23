using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraCore.Entidades
{
    [Table("CategoriaProduto")]
    public class CategoriaProduto
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Descricao { get; set; }
        
        public ICollection<Produto> Produto { get; set; }        
    }
}
