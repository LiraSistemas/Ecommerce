using LiraBelle.Interfaces;
using LiraBelle.ViewModel;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.Repositorios
{
    public class SubCategoriaServicoRepositorioViewModel : ISubCategoriaServicoRepositorioModel
    {
        private ISubCategoriaServico _SubCategoria;
        private ICategoriaServico _Categoria;
        public SubCategoriaServicoRepositorioViewModel(ISubCategoriaServico SubCategoria,
                                       ICategoriaServico Categoria)
        {
            _SubCategoria = SubCategoria;
            _Categoria = Categoria;
        }

        public async Task<List<SubCategoriaServicoViewModel>> Get()
        {
            var subCategorias = await _SubCategoria.GetAsync();
            var categorias = await _Categoria.GetAsync();

            return (from sub in subCategorias
                    join cat in categorias on sub.IdCategoria equals cat.Id
                    select new SubCategoriaServicoViewModel(sub.IdCategoria, sub.Id, sub.Descricao, sub.Link)
                    {
                        Categoria = new CategoriaServicoViewModel(cat.Id,cat.Descricao, cat.LinkImagem)                        

                    }).ToList();
        }
        public async Task<SubCategoriaServicoViewModel> Get(int Id)
        {
            var subCategoria = await _SubCategoria.GetAsync(Id);
            var categoria = await _Categoria.GetAsync(subCategoria.IdCategoria);

            if (subCategoria == null)
                return null;

            var novaSubCategoria = SubCategoriaServicoViewModel.Create(subCategoria, categoria);

            return novaSubCategoria;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
