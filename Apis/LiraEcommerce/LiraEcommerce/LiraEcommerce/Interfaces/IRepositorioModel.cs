using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraBelle.Interfaces
{
    public interface IRepositorioModel<T> : IDisposable
    {
        Task<List<T>> Get();
        Task<T> Get(int Id);
    }
}
