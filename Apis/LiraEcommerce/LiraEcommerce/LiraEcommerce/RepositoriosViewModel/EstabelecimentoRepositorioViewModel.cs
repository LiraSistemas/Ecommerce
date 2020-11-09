using LiraBelle.Interfaces;
using LiraBelle.ViewModel;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.RepositoriosViewModel
{
    public class EstabelecimentoRepositorioViewModel : IEstabelecimentoRepositorioViewModel
    {
        private IEstabelecimento _Estabelecimento { get; set; }
        private IUsuario _Usuario { get; set; }
        public EstabelecimentoRepositorioViewModel(IEstabelecimento Estabelecimento, IUsuario Usuario)
        {
            _Estabelecimento = Estabelecimento;
            _Usuario = Usuario;
        }
        public async Task<List<EstabelecimentoViewModel>> Get()
        {
            var estabelecimentos = await _Estabelecimento.GetAsync();
            var Usuarios = await _Usuario.GetAsync();

            try
            {
                // transformar em um join posteriormente, dando pau e nao quis perder tempo
                var estab = (from est in estabelecimentos
                             select new EstabelecimentoViewModel(est.Id,
                                                                 est.Nome,
                                                                 est.CpfCnpj,
                                                                 est.Apresentacao,
                                                                 est.linkLogo,
                                                                 est.IdUsuarioAdm,
                                                                 est.Endereco,
                                                                 est.EnderecoNumero,
                                                                 est.Bairro,
                                                                 est.Cidade,
                                                                 est.Complemento,
                                                                 est.Telefones,
                                                                 est.Status)).ToList();

                estab.All(X => {
                    X.Usuarios = Usuarios.Where(Y => Y.EstabelecimentoId == X.Id).Select(Z => UsuarioViewModel.Create(Z)).ToList();
                    return true;
                });

                return estab.ToList();
            }
            catch (Exception ex)
            {

                return null;
            }



        }

        public async Task<EstabelecimentoViewModel> Get(int Id)
        {
            var estabelecimento = await _Estabelecimento.GetAsync(Id);

            if (estabelecimento == null)
                return null;

            var Usuarios = await _Usuario.GetAsync(estabelecimento);

            return EstabelecimentoViewModel.Create(estabelecimento, Usuarios);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
