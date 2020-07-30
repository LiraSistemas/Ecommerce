using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LiraData.FlatFile.CRUD
{
    public class ProdutoCRUD : IProduto
    {
        public int Add(Produto cadastro)
        {
            try
            {
                cadastro.Id = FlatLira.CadastroProdutos.Count > 0 ? FlatLira.CadastroProdutos.Max(X => X.Id) + 1 : 1;
                FlatLira.CadastroProdutos.Add(cadastro);
                FlatLira.SetCadastro<Produto>(FlatLira.CadastroProdutos, FlatLira.ArqProdutos);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> AddAsync(Produto cadastro)
        {
            Task<int> T = new Task<int>(() => { return Add(cadastro); });
            T.Start();

            return T;
        }

        public int Delete(int ID)
        {
            try
            {
                FlatLira.CadastroProdutos.Remove(FlatLira.CadastroProdutos.Find(X => X.Id == ID));
                FlatLira.SetCadastro<Produto>(FlatLira.CadastroProdutos, FlatLira.ArqProdutos);

                return 1;
            }
            catch
            {
                return 0;
                
            }
        }

        public Task<int> DeleteAsync(int ID)
        {
            Task<int> T = new Task<int>(() => { return Delete(ID); });
            T.Start();

            return T;
        }

        public int Edit(Produto cadastro)
        {
            try
            {
                var Prod = FlatLira.CadastroProdutos.Find(X => X.Id == cadastro.Id);
                Prod = cadastro;

                FlatLira.SetCadastro<Produto>(FlatLira.CadastroProdutos, FlatLira.ArqProdutos);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> EditAsync(Produto cadastro)
        {
            Task<int> T = new Task<int>(() => { return Edit(cadastro); });
            T.Start();

            return T;
        }

        public Produto Get(int CodigoObjeto)
        {
            return FlatLira.CadastroProdutos.Where(X => X.Id == CodigoObjeto).FirstOrDefault();
        }

        public List<Produto> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetAsync(int CodigoObjeto)
        {
            Task<Produto> T = new Task<Produto>(() => { return Get(CodigoObjeto); });
            T.Start();

            return T;
        }

        public Task<List<Produto>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
