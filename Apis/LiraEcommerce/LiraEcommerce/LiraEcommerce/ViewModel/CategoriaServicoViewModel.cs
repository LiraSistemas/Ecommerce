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

        public CategoriaServicoViewModel(int Id, string Descricao, string LinkImagem = null)
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.LinkImagem = LinkImagem;
        }

        public static CategoriaServicoViewModel Create(CategoriaServico Categoria)
        {
            if (Categoria == null)
                return null;

            return new CategoriaServicoViewModel(Categoria.Id, Categoria.Descricao, Categoria.LinkImagem);    
        }
        public static CategoriaServicoViewModel Create(CategoriaServico Categoria, List<SubCategoriaServico> SubCategorias)
        {
            var categoria = Create(Categoria);                        
            categoria.SubCategorias = SubCategorias.Select(SubCategoria => SubCategoriaServicoViewModel.Create(SubCategoria)).ToList();

            return categoria;
        }
    }
}
