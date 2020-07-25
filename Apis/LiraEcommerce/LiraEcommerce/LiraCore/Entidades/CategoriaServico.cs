using System;
using System.Collections.Generic;

namespace LiraCore.Entidades
{
    [Serializable]
    public class CategoriaServico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string LinkImagem { get; set; }
        public List<SubCategoriaServico> SubCategorias { get; set; }
    }
}
