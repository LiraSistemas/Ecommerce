using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraData.FlatFile.CRUD
{
    public class CategoriaServicoCRUD : ICategoriaServico
    {
        public int Add(CategoriaServico cadastro)
        {
            try
            {
                cadastro.Id = FlatLira.CadastroCategoriaServico.Count + 1;
                FlatLira.CadastroCategoriaServico.Add(cadastro);
                FlatLira.SetCadastro<CategoriaServico>(FlatLira.CadastroCategoriaServico, FlatLira.ArqCategoriaServico);

                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public Task<int> AddAsync(CategoriaServico cadastro)
        {
            Task<int> T = new Task<int>(() => { return Add(cadastro); });
            T.Start();

            return T;
        }

        public int Delete(int ID)
        {
            try
            {
                FlatLira.CadastroCategoriaServico.Remove(FlatLira.CadastroCategoriaServico.Find(X => X.Id == ID));
                FlatLira.SetCadastro<CategoriaServico>(FlatLira.CadastroCategoriaServico, FlatLira.ArqCategoriaServico);

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

        public int Edit(CategoriaServico cadastro)
        {
            try
            {
                var Cad = FlatLira.CadastroCategoriaServico.Find(X => X.Id == cadastro.Id);

                if(Cad != null)
                FlatLira.CadastroCategoriaServico[FlatLira.CadastroCategoriaServico.IndexOf(Cad)] = cadastro;


                FlatLira.SetCadastro<CategoriaServico>(FlatLira.CadastroCategoriaServico, FlatLira.ArqCategoriaServico);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> EditAsync(CategoriaServico cadastro)
        {
            Task<int> T = new Task<int>(() => { return Edit(cadastro); });
            T.Start();

            return T;
        }

        public CategoriaServico Get(int CodigoObjeto)
        {
            return FlatLira.CadastroCategoriaServico.Where(X => X.Id == CodigoObjeto).FirstOrDefault();
        }

        public List<CategoriaServico> Get()
        {
            return FlatLira.CadastroCategoriaServico;
        }

        public Task<CategoriaServico> GetAsync(int CodigoObjeto)
        {
            Task<CategoriaServico> T = new Task<CategoriaServico>(() => { return Get(CodigoObjeto); });
            T.Start();

            return T;
        }

        public Task<List<CategoriaServico>> GetAsync()
        {
            Task<List<CategoriaServico>> T = new Task<List<CategoriaServico>>(() => { return Get(); });
            T.Start();

            return T;
        }
    }
}
