using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LiraData.FlatFile.CRUD
{
    public class ClienteCRUD : ICliente
    {
        public int Add(Cliente cadastro)
        {
            try
            {
                cadastro.Id = FlatEcommerce.CadastroCliente.Count() + 1;
                FlatEcommerce.CadastroCliente.Add(cadastro);
                FlatEcommerce.SetCadastro<Cliente>(FlatEcommerce.CadastroCliente, FlatEcommerce.ArqCliente);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> AddAsync(Cliente cadastro)
        {
            throw new NotImplementedException();
        }

        public int Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public int Edit(Cliente cadastro)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditAsync(Cliente cadastro)
        {
            throw new NotImplementedException();
        }

        public Cliente Get(int CodigoObjeto)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetAsync(int CodigoObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
