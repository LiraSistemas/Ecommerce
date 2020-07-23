using System.Collections.Generic;

namespace LiraCore.Entidades
{
    public class Parceiro
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string CPNJ { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public int Celular { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string PontoReferencia { get; set; }
        public string TipoLogradouro { get; set; }
        public byte[] LogoMarca { get; set; }
        public string Instagran { get; set; }
        public string Facebook { get; set; }

        public IEnumerable<Cliente> Clientes {get;set;}
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
