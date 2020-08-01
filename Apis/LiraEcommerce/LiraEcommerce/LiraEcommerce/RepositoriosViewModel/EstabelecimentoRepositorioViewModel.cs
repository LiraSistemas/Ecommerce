using LiraBelle.Interfaces;
using LiraBelle.ViewModel;
using LiraCore.Entidades;
using LiraCore.Enuns;
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

            return (from est in estabelecimentos
                    join users in Usuarios on est.Id equals users.EstabelecimentoId
                    group new { est, users } by est.Id into newgroup
                    select new EstabelecimentoViewModel(newgroup.FirstOrDefault().est.Id,
                                                        newgroup.FirstOrDefault().est.Nome,
                                                        newgroup.FirstOrDefault().est.CpfCnpj,
                                                        newgroup.FirstOrDefault().est.Apresentacao,
                                                        newgroup.FirstOrDefault().est.linkLogo,                                                        
                                                        newgroup.FirstOrDefault().est.IdUsuarioAdm,
                                                        newgroup.FirstOrDefault().est.Endereco,
                                                        newgroup.FirstOrDefault().est.EnderecoNumero,
                                                        newgroup.FirstOrDefault().est.Bairro,
                                                        newgroup.FirstOrDefault().est.Cidade,
                                                        newgroup.FirstOrDefault().est.Complemento,
                                                        newgroup.FirstOrDefault().est.Telefones,
                                                        newgroup.FirstOrDefault().est.Status)
                    {
                        Usuarios = newgroup.Select(X => UsuarioViewModel.Create(X.users)).ToList()
                    }).ToList();
        }

        public async Task<EstabelecimentoViewModel> Get(int Id)
        {
            var estabelecimento = await _Estabelecimento.GetAsync(Id);

            var Usuarios = await _Usuario.GetAsync(estabelecimento);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
