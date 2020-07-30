using LiraCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.ViewModel
{
    public class CategoriaServicoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string LinkImagem { get; set; }
        public List<SubCategoriaServicoViewModel> SubCategorias { get; set; }

    }
}
