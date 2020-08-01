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
        public string LinkLogo { get; set; }
        public List<Telefone> Telefones { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public StatusEstabelecimento Status { get; set; }

        public int IdUsuarioAdm { get; set; }
        public List<UsuarioViewModel> Usuarios { get; set; }

        public EstabelecimentoViewModel(int id, string nome, string cpfcnpj, string apresentacao, 
                                        string linkLogo, int idUsuarioAdm,   string endereco, string enderecoNumero,
                                        string bairro, string cidade, string complemento, List<Telefone> telefones, 
                                        StatusEstabelecimento status)
        {
            Id = id;
            Nome = nome;
            CpfCnpj = cpfcnpj;
            Apresentacao = apresentacao;
            LinkLogo = linkLogo;
            IdUsuarioAdm = idUsuarioAdm;
            Status = status;
            Endereco = endereco;
            EnderecoNumero = EnderecoNumero;
            Bairro = bairro;
            Cidade = cidade;
            Complemento = complemento;
            Telefones = telefones;

        }

        public static EstabelecimentoViewModel Create(Estabelecimento estabelecimento)
        {
            return new EstabelecimentoViewModel(estabelecimento.Id,
                                                estabelecimento.Nome,
                                                estabelecimento.CpfCnpj,
                                                estabelecimento.Apresentacao,
                                                estabelecimento.linkLogo,
                                                estabelecimento.IdUsuarioAdm,
                                                estabelecimento.Endereco,
                                                estabelecimento.EnderecoNumero,
                                                estabelecimento.Bairro,
                                                estabelecimento.Cidade,
                                                estabelecimento.Complemento,
                                                estabelecimento.Telefones,
                                                estabelecimento.Status);
            
        }

        public static EstabelecimentoViewModel Create(Estabelecimento estabelecimento, List<Usuario> usuarios)
        {
            var novoViewModel = Create(estabelecimento);
            novoViewModel.Usuarios = usuarios.Select(X => UsuarioViewModel.Create(X)).ToList();

            return novoViewModel;
        }
    }
}
