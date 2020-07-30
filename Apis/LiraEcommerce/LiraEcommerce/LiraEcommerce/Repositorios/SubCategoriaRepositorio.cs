using LiraBelle.ViewModel;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.Repositorios
{
    public class SubCategoriaRepositorio
    {
        private ISubCategoriaServico _SubCategoria;
        private ICategoriaServico _Categoria;
        public SubCategoriaRepositorio(ISubCategoriaServico SubCategoria,
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
                    select new SubCategoriaServicoViewModel()
                    {
                        IdCategoria = sub.IdCategoria,
                        Id = sub.Id,
                        Descricao = sub.Descricao,
                        Link = sub.Descricao,
                        Categoria = new CategoriaServicoViewModel()
                        {
                            Id = cat.Id,
                            Descricao = cat.Descricao,
                            LinkImagem = cat.LinkImagem
                        }

                    }).ToList();
        }
    }
}
