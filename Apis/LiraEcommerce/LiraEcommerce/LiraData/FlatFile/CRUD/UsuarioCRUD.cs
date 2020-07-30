using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraData.FlatFile.CRUD
{
    public class UsuarioCRUD : IUsuario
    {

        public int Add(Usuario cadastro)
        {
            try
            {
                cadastro.Id = FlatLira.CadastroUsuario.Count > 0 ? FlatLira.CadastroUsuario.Max(X => X.Id) + 1 : 1;
                FlatLira.CadastroUsuario.Add(cadastro);
                FlatLira.SetCadastro<Usuario>(FlatLira.CadastroUsuario, FlatLira.ArqUsuario);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> AddAsync(Usuario cadastro)
        {
            Task<int> T = new Task<int>(() => { return Add(cadastro); });
            T.Start();

            return T;
        }

        public int Delete(int ID)
        {
            try
            {
                FlatLira.CadastroUsuario.Remove(FlatLira.CadastroUsuario.Find(X => X.Id == ID));
                FlatLira.SetCadastro<Usuario>(FlatLira.CadastroUsuario, FlatLira.ArqUsuario);

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

        public int Edit(Usuario cadastro)
        {
            try
            {
                var Cad = FlatLira.CadastroUsuario.Find(X => X.Id == cadastro.Id);

                if (Cad != null)
                    FlatLira.CadastroUsuario[FlatLira.CadastroUsuario.IndexOf(Cad)] = cadastro;
                var Prod = FlatLira.CadastroUsuario.Find(X => X.Id == cadastro.Id);                

                FlatLira.SetCadastro<Usuario>(FlatLira.CadastroUsuario, FlatLira.ArqUsuario);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> EditAsync(Usuario cadastro)
        {
            Task<int> T = new Task<int>(() => { return Edit(cadastro); });
            T.Start();

            return T;
        }

        public Usuario Get(int CodigoObjeto)
        {
            return FlatLira.CadastroUsuario.Where(X => X.Id == CodigoObjeto).FirstOrDefault();
        }

        public List<Usuario> Get()
        {
            return FlatLira.CadastroUsuario;
        }

        public Task<Usuario> GetAsync(int CodigoObjeto)
        {
            Task<Usuario> T = new Task<Usuario>(() => { return Get(CodigoObjeto); });
            T.Start();

            return T;
        }

        public Task<List<Usuario>> GetAsync()
        {
            Task<List<Usuario>> T = new Task<List<Usuario>>(() => { return Get(); });
            T.Start();

            return T;
        }
    }
}
