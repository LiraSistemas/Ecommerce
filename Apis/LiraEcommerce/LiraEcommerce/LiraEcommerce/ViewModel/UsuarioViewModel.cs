using LiraCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public bool UsuarioAdm { get; set; }
        public List<CategoriaServico> CategoriasHabilitadas { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
    }
}
