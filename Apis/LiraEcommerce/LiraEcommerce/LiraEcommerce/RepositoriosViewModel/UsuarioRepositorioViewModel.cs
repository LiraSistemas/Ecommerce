using LiraBelle.Interfaces;
using LiraBelle.ViewModel;
using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.RepositoriosViewModel
{
    public class UsuarioRepositorioViewModel : IUsuarioRepositorioViewModel
    {

        IUsuario _Usuario { get; set; } 
        IEstabelecimento _Estabelecimento { get;set; }
        public UsuarioRepositorioViewModel(IUsuario usuario, IEstabelecimento estabelecimento)
        {
            _Usuario = usuario;
            _Estabelecimento = estabelecimento;
        }
        public async Task<List<UsuarioViewModel>> Get()
        {
            var usuarios = await _Usuario.GetAsync();
            var estabelecimento = await _Estabelecimento.GetAsync();

            return (from user in usuarios
                    join est in estabelecimento.DefaultIfEmpty() on user.EstabelecimentoId equals est.Id                    
                    select new UsuarioViewModel(user.Id,
                                                user.Nome,
                                                user.NomeUsuario,
                                                user.Email,
                                                user.Telefone,
                                                user.UsuarioAdm)
                    {

                        CategoriasHabilitadas = user.CategoriasHabilitadas?.Select(X => CategoriaServicoViewModel.Create(X)).ToList(),
                        Estabelecimento = est != null ? EstabelecimentoViewModel.Create(est) : null

                    }).ToList();
        }

        public async Task<UsuarioViewModel> Get(int Id)
        {
            var usuario = await _Usuario.GetAsync(Id);

            if (usuario == null)
                return null;

            var estabelecimento = await _Estabelecimento.GetAsync(usuario.EstabelecimentoId);

            var user = UsuarioViewModel.Create(usuario);
            user.Estabelecimento = EstabelecimentoViewModel.Create(estabelecimento);

            return user;

        }

        public async Task<List<UsuarioViewModel>> Get(EstabelecimentoViewModel estabelecimento)
        {
            var est = await _Estabelecimento.GetAsync(estabelecimento.Id);

            if (est == null)
                return null;

            var usuarios = await _Usuario.GetAsync(est);

            return usuarios.Select(X => UsuarioViewModel.Create(X)).ToList();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
