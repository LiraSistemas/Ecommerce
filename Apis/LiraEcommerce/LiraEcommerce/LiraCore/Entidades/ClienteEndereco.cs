using LiraCore.Enuns;
using System;

namespace LiraCore.Entidades
{
    public class ClienteEndereco
    {
        public long Id { get; set; }        
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string PontoReferencia { get; set; }
        public string TipoLogradouro { get; set; }
        public Status Status { get; set; }        
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataUltimaUtilizacao { get; set; }
        public  Cliente Cliente { get; set; }
    }
}
