using LiraCore.Entidades;
using LiraCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraData.FlatFile.CRUD
{
    public class SubCategoriaServicoCRUD : ISubCategoriaServico
    {

        public int Add(SubCategoriaServico cadastro)
        {
            try
            {
                cadastro.Id = FlatLira.CadastroSubCategoriaServico.Count > 0 ? FlatLira.CadastroSubCategoriaServico.Max(X => X.Id) + 1 : 1;                
                FlatLira.CadastroSubCategoriaServico.Add(cadastro);
                FlatLira.SetCadastro<SubCategoriaServico>(FlatLira.CadastroSubCategoriaServico, FlatLira.ArqSubCategoriaServico);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> AddAsync(SubCategoriaServico cadastro)
        {
            Task<int> T = new Task<int>(() => { return Add(cadastro); });
            T.Start();

            return T;
        }

        public int Delete(int ID)
        {
            try
            {
                FlatLira.CadastroSubCategoriaServico.Remove(FlatLira.CadastroSubCategoriaServico.Find(X => X.Id == ID));
                FlatLira.SetCadastro<SubCategoriaServico>(FlatLira.CadastroSubCategoriaServico, FlatLira.ArqSubCategoriaServico);

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

        public int Edit(SubCategoriaServico cadastro)
        {
            try
            {
                var Cad = FlatLira.CadastroSubCategoriaServico.Find(X => X.Id == cadastro.Id);                
                              
                if (Cad != null)
                {                    
                    FlatLira.CadastroSubCategoriaServico[FlatLira.CadastroSubCategoriaServico.IndexOf(cadastro)] = cadastro;
                }

                FlatLira.SetCadastro<SubCategoriaServico>(FlatLira.CadastroSubCategoriaServico, FlatLira.ArqSubCategoriaServico);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> EditAsync(SubCategoriaServico cadastro)
        {
            Task<int> T = new Task<int>(() => { return Edit(cadastro); });
            T.Start();

            return T;
        }

        public SubCategoriaServico Get(int CodigoObjeto)
        {
            return FlatLira.CadastroSubCategoriaServico.Where(X => X.Id == CodigoObjeto).FirstOrDefault();
        }

        public List<SubCategoriaServico> Get()
        {
            return FlatLira.CadastroSubCategoriaServico;
        }

        public Task<SubCategoriaServico> GetAsync(int CodigoObjeto)
        {
            Task<SubCategoriaServico> T = new Task<SubCategoriaServico>(() => { return Get(CodigoObjeto); });
            T.Start();

            return T;
        }

        public Task<List<SubCategoriaServico>> GetAsync()
        {
            Task<List<SubCategoriaServico>> T = new Task<List<SubCategoriaServico>>(() => { return Get(); });
            T.Start();

            return T;
        }
    }
}
