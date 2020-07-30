using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.ViewModel
{
    public class SubCategoriaServicoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }
        public int IdCategoria { get; set; }
        public CategoriaServicoViewModel Categoria { get; set; }
    }
}
