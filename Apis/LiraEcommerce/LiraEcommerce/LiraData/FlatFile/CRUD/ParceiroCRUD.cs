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
                cadastro.Id = FlatLira.CadastroParceiro.Max(X => X.Id) + 1;
                FlatLira.CadastroParceiro.Add(cadastro);
                FlatLira.SetCadastro<Parceiro>(FlatLira.CadastroParceiro, FlatLira.ArqParceiro);

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
                FlatLira.CadastroParceiro.Remove(FlatLira.CadastroParceiro.Find(X => X.Id == ID));
                FlatLira.SetCadastro<Parceiro>(FlatLira.CadastroParceiro, FlatLira.ArqParceiro);

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
                var Prod = FlatLira.CadastroParceiro.Find(X => X.Id == cadastro.Id);
                Prod = cadastro;

                FlatLira.SetCadastro<Parceiro>(FlatLira.CadastroParceiro, FlatLira.ArqParceiro);

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
            return FlatLira.CadastroParceiro.Where(X => X.Id == CodigoObjeto).FirstOrDefault();
        }

        public List<Parceiro> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Parceiro> GetAsync(int CodigoObjeto)
        {
            Task<Parceiro> T = new Task<Parceiro>(() => { return Get(CodigoObjeto); });
            T.Start();

            return T;
        }

        public Task<List<Parceiro>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
