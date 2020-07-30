using LiraCore.Entidades;
using LiraCore.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.ViewModel
{
    public class EstabelecimentoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Apresentacao { get; set; }
        public string linkLogo { get; set; }
        public StatusEstabelecimento Status { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
