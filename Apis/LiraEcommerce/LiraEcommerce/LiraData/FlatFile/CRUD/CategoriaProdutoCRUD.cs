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
                cadastro.Id = FlatEcommerce.CadastroCategoriaProduto.Count() + 1;
                FlatEcommerce.CadastroCategoriaProduto.Add(cadastro);
                FlatEcommerce.SetCadastro<CategoriaProduto>(FlatEcommerce.CadastroCategoriaProduto, FlatEcommerce.ArqCategoria);

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
                FlatEcommerce.CadastroCategoriaProduto.Remove(FlatEcommerce.CadastroCategoriaProduto.Find(X => X.Id == ID));
                FlatEcommerce.SetCadastro<CategoriaProduto>(FlatEcommerce.CadastroCategoriaProduto, FlatEcommerce.ArqCategoria);

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
                var Prod = FlatEcommerce.CadastroCategoriaProduto.Find(X => X.Id == cadastro.Id);
                Prod = cadastro;

                FlatEcommerce.SetCadastro<CategoriaProduto>(FlatEcommerce.CadastroCategoriaProduto, FlatEcommerce.ArqCategoria);

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
            return FlatEcommerce.CadastroCategoriaProduto.Where(X => X.Id == CodigoObjeto).FirstOrDefault();
        }

        public Task<CategoriaProduto> GetAsync(int CodigoObjeto)
        {
            Task<CategoriaProduto> T = new Task<CategoriaProduto>(() => { return Get(CodigoObjeto); });
            T.Start();

            return T;
        }
    }
}
