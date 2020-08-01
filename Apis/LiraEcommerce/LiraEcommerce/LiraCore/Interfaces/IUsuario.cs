using LiraCore.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiraCore.Interfaces
{
    public interface IUsuario : ICadastro<Usuario>
    {
        public List<Usuario> Get(Estabelecimento estabelecimento);
        public Task<List<Usuario>> GetAsync(Estabelecimento estabelecimento);
    }
}
