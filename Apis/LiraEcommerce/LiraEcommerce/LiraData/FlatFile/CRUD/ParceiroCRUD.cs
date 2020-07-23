using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraData.FlatFile.CRUD
{
    public class ParceiroCRUD : IParceiro
    {
        public int Add(Parceiro cadastro)
        {
            try
            {
                cadastro.Id = FlatEcommerce.CadastroParceiro.Count() + 1;
                FlatEcommerce.CadastroParceiro.Add(cadastro);
                FlatEcommerce.SetCadastro<Parceiro>(FlatEcommerce.CadastroParceiro, FlatEcommerce.ArqParceiro);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> AddAsync(Parceiro cadastro)
        {
            Task<int> T = new Task<int>(() => { return Add(cadastro); });
            T.Start();

            return T;
        }

        public int Delete(int ID)
        {
            try
            {
                FlatEcommerce.CadastroParceiro.Remove(FlatEcommerce.CadastroParceiro.Find(X => X.Id == ID));
                FlatEcommerce.SetCadastro<Parceiro>(FlatEcommerce.CadastroParceiro, FlatEcommerce.ArqParceiro);

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

        public int Edit(Parceiro cadastro)
        {
            try
            {
                var Prod = FlatEcommerce.CadastroParceiro.Find(X => X.Id == cadastro.Id);
                Prod = cadastro;

                FlatEcommerce.SetCadastro<Parceiro>(FlatEcommerce.CadastroParceiro, FlatEcommerce.ArqParceiro);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> EditAsync(Parceiro cadastro)
        {
            Task<int> T = new Task<int>(() => { return Edit(cadastro); });
            T.Start();

            return T;
        }

        public Parceiro Get(int CodigoObjeto)
        {
            return FlatEcommerce.CadastroParceiro.Where(X => X.Id == CodigoObjeto).FirstOrDefault();
        }

        public Task<Parceiro> GetAsync(int CodigoObjeto)
        {
            Task<Parceiro> T = new Task<Parceiro>(() => { return Get(CodigoObjeto); });
            T.Start();

            return T;
        }
    }
}
