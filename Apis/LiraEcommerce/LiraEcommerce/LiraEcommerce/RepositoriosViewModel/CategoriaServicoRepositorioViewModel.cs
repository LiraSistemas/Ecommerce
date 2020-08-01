using LiraBelle.Interfaces;
using LiraBelle.ViewModel;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.RepositoriosViewModel
{
    public class CategoriaServicoRepositorioViewModel : ICategoriaServicoRepositorioViewModel
    {
        private ICategoriaServico _Categoria;
        private ISubCategoriaServico _SubCategoria;
        public CategoriaServicoRepositorioViewModel(ICategoriaServico Categoria, ISubCategoriaServico SubCategoria)
        {
            _Categoria = Categoria;
            _SubCategoria = SubCategoria;
        }

        public async Task<List<CategoriaServicoViewModel>> Get()
        {
            var categorias = await _Categoria.GetAsync();
            var subCategorias = await _SubCategoria.GetAsync();

            if (categorias == null)
                return null;

            return ( from cat in categorias
                     join sub in subCategorias on cat.Id equals sub.IdCategoria
                     group new { cat, sub} by cat.Id into agrupamento
                     select new CategoriaServicoViewModel(agrupamento.FirstOrDefault().cat.Id,
                                                          agrupamento.FirstOrDefault().cat.Descricao,
                                                          agrupamento.FirstOrDefault().cat.LinkImagem)
                     {

                         SubCategorias = agrupamento.Select(X => SubCategoriaServicoViewModel.Create(X.sub)).ToList()

                     }).ToList();

        }

        public async Task<CategoriaServicoViewModel> Get(int Id)
        {
            var categoria = await _Categoria.GetAsync(Id);

            if (categoria == null)
                return null;

            var subCategorias = await _SubCategoria.GetAsync(categoria);

            return CategoriaServicoViewModel.Create(categoria, subCategorias);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
