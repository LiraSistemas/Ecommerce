using LiraCore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiraCore.Interfaces
{
    public interface ISubCategoriaServico : ICadastro<SubCategoriaServico>
    {
        List<SubCategoriaServico> Get(CategoriaServico categoria);
        Task<List<SubCategoriaServico>> GetAsync(CategoriaServico categoria);
    }
}
