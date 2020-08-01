using LiraCore.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiraCore.Interfaces
{
    public interface IUsuario : ICadastro<Usuario>
    {
        public Task<List<Usuario>> Get(Estabelecimento estabelecimento);
    }
}
