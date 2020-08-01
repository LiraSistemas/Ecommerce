using LiraCore.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }       
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool UsuarioAdm { get; set; }
        public string Telefone { get; set; }        
        public List<CategoriaServicoViewModel> CategoriasHabilitadas { get; set; }
        public EstabelecimentoViewModel Estabelecimento { get; set; }

        public UsuarioViewModel(int id, string nome, string nomeusuario, string email, string telefone, bool usuarioAdm)
        {
            Id = id;
            Nome = nome;
            NomeUsuario = nomeusuario;
            Email = email;
            Telefone = telefone;
            UsuarioAdm = usuarioAdm;

        }

        public UsuarioViewModel(int id, string nome, string nomeusuario, string email, string telefone, bool UsuarioAdm, List<CategoriaServicoViewModel> categoriasHabilitadas) : this(id, nome, nomeusuario, email, telefone,UsuarioAdm)
        {
            CategoriasHabilitadas = categoriasHabilitadas;
        }

        public UsuarioViewModel(int id, string nome, string nomeusuario, string email, string telefone, bool UsuarioAdm, List<CategoriaServicoViewModel> categoriasHabilitadas, EstabelecimentoViewModel Estabelecimento) : this(id, nome, nomeusuario, email, telefone, UsuarioAdm, categoriasHabilitadas)
        {
            this.Estabelecimento = Estabelecimento;
        }

        public static UsuarioViewModel Create(Usuario usuario)
        {
            return new UsuarioViewModel(usuario.Id,
                                        usuario.Nome,
                                        usuario.NomeUsuario,
                                        usuario.Email,
                                        usuario.Telefone,
                                        usuario.UsuarioAdm,
                                        usuario.CategoriasHabilitadas.Select(X => CategoriaServicoViewModel.Create(X)).ToList());
        }

        public static UsuarioViewModel Create(Usuario usuario, Estabelecimento estabelecimento)
        {
            var Usuario = Create(usuario);
            Usuario.Estabelecimento = EstabelecimentoViewModel.Create(estabelecimento);

            return Usuario;
        }
    }
}
