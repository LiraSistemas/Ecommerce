using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraData.FlatFile.CRUD
{
    public class CategoriaProdutoCRUD : ICategoriaProduto
    {
        public int Add(CategoriaProduto cadastro)
        {
            try
            {
                cadastro.Id = FlatLira.CadastroCategoriaProduto.Count > 0 ? FlatLira.CadastroCategoriaProduto.Max(X => X.Id) + 1 : 1;
                FlatLira.CadastroCategoriaProduto.Add(cadastro);
                FlatLira.SetCadastro<CategoriaProduto>(FlatLira.CadastroCategoriaProduto, FlatLira.ArqCategoria);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> AddAsync(CategoriaProduto cadastro)
        {
            Task<int> T = new Task<int>(() => { return Add(cadastro); });
            T.Start();

            return T;
        }

        public int Delete(int ID)
        {
            try
            {
                FlatLira.CadastroCategoriaProduto.Remove(FlatLira.CadastroCategoriaProduto.Find(X => X.Id == ID));
                FlatLira.SetCadastro<CategoriaProduto>(FlatLira.CadastroCategoriaProduto, FlatLira.ArqCategoria);

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

        public int Edit(CategoriaProduto cadastro)
        {
            try
            {
                var Prod = FlatLira.CadastroCategoriaProduto.Find(X => X.Id == cadastro.Id);
                Prod = cadastro;

                FlatLira.SetCadastro<CategoriaProduto>(FlatLira.CadastroCategoriaProduto, FlatLira.ArqCategoria);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> EditAsync(CategoriaProduto cadastro)
        {
            Task<int> T = new Task<int>(() => { return Edit(cadastro); });
            T.Start();

            return T;
        }

        public CategoriaProduto Get(int CodigoObjeto)
        {
            return FlatLira.CadastroCategoriaProduto.Where(X => X.Id == CodigoObjeto).FirstOrDefault();
        }

        public List<CategoriaProduto> Get()
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaProduto> GetAsync(int CodigoObjeto)
        {
            Task<CategoriaProduto> T = new Task<CategoriaProduto>(() => { return Get(CodigoObjeto); });
            T.Start();

            return T;
        }

        public Task<List<CategoriaProduto>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
