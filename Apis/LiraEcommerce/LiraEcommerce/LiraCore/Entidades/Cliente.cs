using LiraCore.Enuns;
using System;
using System.Collections.Generic;

namespace LiraCore.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public string Opcao { get; set; }
        public bool PushEmail { get; set; }        
        public bool PushSMS { get; set; }
        public int Telefone { get; set; }
        public int Celular { get; set; }        
        public string Senha { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public System.DateTime DataAlteracao { get; set; }                

        public Parceiro Parceiro { get; set; }
        public ICollection<ClienteEndereco> ClienteEndereco { get; set; }
    }
}
