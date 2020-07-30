using LiraCore.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiraCore.Entidades
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj {get;set;}
        public string Apresentacao { get; set; }
        public string linkLogo { get; set; }
        public StatusEstabelecimento Status { get; set; }        

    }
}
