using LiraCore.Entidades;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LiraBelle.ViewModel
{
    public class SubCategoriaServicoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string LinkImagem { get; set; }
        public int IdCategoria { get; set; }
        public CategoriaServicoViewModel Categoria { get; set; }

        public SubCategoriaServicoViewModel(int IdCategoria, int Id, string Descricao, string LinkImagem )
        {
            this.Id = Id;
            this.IdCategoria = IdCategoria;
            this.Descricao = Descricao;
            this.LinkImagem = LinkImagem;
        }

        public static SubCategoriaServicoViewModel Create(SubCategoriaServico SubCategoria)
        {
            return new SubCategoriaServicoViewModel(SubCategoria.IdCategoria, SubCategoria.Id, SubCategoria.Descricao, SubCategoria.Link);
        }

        public static SubCategoriaServicoViewModel Create(SubCategoriaServico SubCategoria, CategoriaServico Categoria)
        {
            var novo = Create(SubCategoria);            
            novo.Categoria = CategoriaServicoViewModel.Create(Categoria);

            return novo;
        }
    }
}
