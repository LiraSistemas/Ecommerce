using LiraCore.Enuns;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace LiraCore.Entidades
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Apresentacao { get; set; }
        public string linkLogo { get; set; }
        public List<Telefone> Telefones { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public StatusEstabelecimento Status { get; set; }
        public int IdUsuarioAdm {get;set;}

    }
}
