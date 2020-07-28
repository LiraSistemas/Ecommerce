using LiraCore.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;

namespace LiraData.FlatFile
{
    public class FlatLira
    {
        public const string ArqProdutos = "CadastroProdutos.bin";

        public const string ArqCategoria = "CadastroCategoriaProduto.bin";
        public const string ArqCategoriaServico = "CadastroCategoriaServico.bin";
        public const string ArqSubCategoriaServico = "CadastroSubCategoriaServico.bin";

        public const string ArqParceiro = "CadastroParceiro.bin";
        public const string ArqCliente = "CadastroCliente.bin";

        public const string ArqEstabelecimento = "CadastroEstabelecimento.bin";


        private static List<Produto> _CadastroProdutos;

        private static List<CategoriaProduto> _CadastroCategoriaProduto;
        private static List<CategoriaServico> _CadastroCategoriaServico;
        private static List<SubCategoriaServico> _CadastroSubCategoriaServico;

        private static List<Parceiro> _CadastroParceiro;
        private static List<Cliente> _CadastroCliente;

        private static List<Estabelecimento> _CadastroEstabelecimento;
        public static List<Produto> CadastroProdutos 
        {
            get 
            {
                if (_CadastroProdutos != null)
                {
                    return _CadastroProdutos;

                }
                else
                {
                    _CadastroProdutos = GetCadastro<Produto>(ArqProdutos);
                    return _CadastroProdutos;
                }
            }
            set 
            {
                _CadastroProdutos = value;
            }
        }
        public static List<CategoriaProduto> CadastroCategoriaProduto
        {
            get
            {
                if (_CadastroCategoriaProduto != null)
                {
                    return _CadastroCategoriaProduto;

                }
                else
                {
                    _CadastroCategoriaProduto = GetCadastro<CategoriaProduto>(ArqCategoria);
                    return _CadastroCategoriaProduto;
                }
            }
            set
            {
                _CadastroCategoriaProduto = value;
            }
        }
        public static List<CategoriaServico> CadastroCategoriaServico
        {
            get
            {
                if (_CadastroCategoriaServico != null)
                {
                    return _CadastroCategoriaServico;

                }
                else
                {
                    CadastroCategoriaServico = GetCadastro<CategoriaServico>(ArqCategoriaServico);
                    return _CadastroCategoriaServico;
                }
            }
            set
            {
                _CadastroCategoriaServico = value;
            }
        }
        public static List<SubCategoriaServico> CadastroSubCategoriaServico
        {
            get
            {
                if (_CadastroSubCategoriaServico != null)
                {
                    return _CadastroSubCategoriaServico;

                }
                else
                {
                    CadastroSubCategoriaServico = GetCadastro<SubCategoriaServico>(ArqSubCategoriaServico);
                    return _CadastroSubCategoriaServico;
                }
            }
            set
            {
                _CadastroSubCategoriaServico = value;
            }
        }
        public static List<Parceiro> CadastroParceiro
        {
            get
            {
                if (_CadastroParceiro != null)
                {
                    return _CadastroParceiro;

                }
                else
                {
                    _CadastroParceiro = GetCadastro<Parceiro>(ArqParceiro);
                    return _CadastroParceiro;
                }
            }
            set
            {
                _CadastroParceiro = value;
            }
        }
        public static List<Cliente> CadastroCliente
        {
            get
            {
                if (_CadastroCliente != null)
                {
                    return _CadastroCliente;

                }
                else
                {
                    _CadastroCliente = GetCadastro<Cliente>(ArqParceiro);
                    return _CadastroCliente;
                }
            }
            set
            {
                _CadastroCliente = value;
            }
        }

        public static List<Estabelecimento> CadastroEstabelecimento
        {
            get
            {
                if (_CadastroEstabelecimento != null)
                {
                    return _CadastroEstabelecimento;

                }
                else
                {
                    CadastroEstabelecimento = GetCadastro<Estabelecimento>(ArqEstabelecimento);
                    return _CadastroEstabelecimento;
                }
            }
            set
            {
                _CadastroEstabelecimento = value;
            }
        }

        private static List<T> GetCadastro<T>(string Arquivo)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + Arquivo;

            if (File.Exists(path))
            {
                return GetBin<T>(path);
            }
            else
            {
                return new List<T>();
            }

        }

        public static void SetCadastro<T>(List<T> Cadastro, string Arquivo)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + Arquivo;

            SetBin<T>(Cadastro, path);

        }

        private static List<T> GetBin<T>(string Path)
        {
            //FileStream SR = new FileStream(Path, FileMode.Open);
            //BinaryFormatter BF = new BinaryFormatter();            

            try
            {
                var json = File.ReadAllText(Path);

                return JsonSerializer.Deserialize<List<T>>(json);

                //SR.Seek(0, SeekOrigin.Begin);
                //return (List<T>)BF.Deserialize(SR);
            }
            finally
            {
                //SR.Close();
            }

        }

        private static void SetBin<T>(List<T> Cadastro, string Path)
        {
            //FileStream SR = new FileStream(Path, FileMode.OpenOrCreate);
            //StreamWriter SW = new StreamWriter(Path);            
            //BinaryFormatter BF = new BinaryFormatter();

            try
            {
                
                var json = JsonSerializer.Serialize(Cadastro);
                File.WriteAllText(Path, json);
                //BF.Serialize(SR, Cadastro);
            }
            finally
            {
                //SR.Close();
            }

        }
    }
}
