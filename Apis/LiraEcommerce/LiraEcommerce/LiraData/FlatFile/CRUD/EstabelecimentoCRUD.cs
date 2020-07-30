using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraData.FlatFile.CRUD
{
    public class EstabelecimentoCRUD : IEstabelecimento
    {
        public int Add(Estabelecimento cadastro)
        {
            try
            {
                cadastro.Id = FlatLira.CadastroEstabelecimento.Count > 0 ? FlatLira.CadastroEstabelecimento.Max(X => X.Id) + 1 : 1;
                FlatLira.CadastroEstabelecimento.Add(cadastro);
                FlatLira.SetCadastro<Estabelecimento>(FlatLira.CadastroEstabelecimento, FlatLira.ArqEstabelecimento);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> AddAsync(Estabelecimento cadastro)
        {
            Task<int> T = new Task<int>(() => { return Add(cadastro); });
            T.Start();

            return T;
        }

        public int Delete(int ID)
        {
            try
            {
                FlatLira.CadastroEstabelecimento.Remove(FlatLira.CadastroEstabelecimento.Find(X => X.Id == ID));
                FlatLira.SetCadastro<Estabelecimento>(FlatLira.CadastroEstabelecimento, FlatLira.ArqEstabelecimento);

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

        public int Edit(Estabelecimento cadastro)
        {
            try
            {
                var Prod = FlatLira.CadastroEstabelecimento.Find(X => X.Id == cadastro.Id);
                Prod = cadastro;

                FlatLira.SetCadastro<Estabelecimento>(FlatLira.CadastroEstabelecimento, FlatLira.ArqEstabelecimento);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> EditAsync(Estabelecimento cadastro)
        {
            Task<int> T = new Task<int>(() => { return Edit(cadastro); });
            T.Start();

            return T;
        }

        public Estabelecimento Get(int CodigoObjeto)
        {
            return FlatLira.CadastroEstabelecimento.Where(X => X.Id == CodigoObjeto).FirstOrDefault();
        }

        public List<Estabelecimento> Get()
        {
            return FlatLira.CadastroEstabelecimento;
        }

        public Task<Estabelecimento> GetAsync(int CodigoObjeto)
        {
            Task<Estabelecimento> T = new Task<Estabelecimento>(() => { return Get(CodigoObjeto); });
            T.Start();

            return T;
        }

        public Task<List<Estabelecimento>> GetAsync()
        {
            Task<List<Estabelecimento>> T = new Task<List<Estabelecimento>>(() => { return Get(); });
            T.Start();

            return T;
        }
    }    
}
