using System;
using System.Collections.Generic;
using System.Text;

namespace LiraCore.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public bool UsuarioAdm { get; set; }
        public List<CategoriaServico> CategoriasHabilitadas { get; set; }
        public int EstabelecimentoId { get; set; }
    }
}
