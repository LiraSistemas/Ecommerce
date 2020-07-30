using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
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
                cadastro.Id = FlatLira.CadastroCliente.Count > 0 ? FlatLira.CadastroCliente.Max(X => X.Id) + 1 : 1;
                FlatLira.CadastroCliente.Add(cadastro);
                FlatLira.SetCadastro<Cliente>(FlatLira.CadastroCliente, FlatLira.ArqCliente);

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

        public List<Cliente> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetAsync(int CodigoObjeto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
