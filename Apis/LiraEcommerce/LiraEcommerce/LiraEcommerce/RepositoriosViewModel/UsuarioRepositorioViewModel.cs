using LiraBelle.Interfaces;
using LiraBelle.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.RepositoriosViewModel
{
    public class UsuarioRepositorioViewModel : IUsuarioRepositorioViewModel
    {

        public Task<List<UsuarioViewModel>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioViewModel> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsuarioViewModel>> Get(EstabelecimentoViewModel estabelecimento)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
