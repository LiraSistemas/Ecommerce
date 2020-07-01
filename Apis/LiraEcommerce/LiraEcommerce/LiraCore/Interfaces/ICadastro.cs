using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiraCore.Interfaces
{
    public interface ICadastro<T> where T : class
    {
        T Get(int CodigoObjeto);
        Task<T> GetAsync(int CodigoObjeto);
        int Add(T cadastro);
        Task<int> AddAsync(T cadastro);
        int Edit(T cadastro);
        Task<int> EditAsync(T cadastro);
        int Delete(int ID);
        Task<int> DeleteAsync(int ID);
    }
}
