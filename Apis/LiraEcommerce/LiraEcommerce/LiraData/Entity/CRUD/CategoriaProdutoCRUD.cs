using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraData.Entity.CRUD
{
    public class CategoriaProdutoCRUD : ICategoriaProduto
    {
        private int Add(LiraContext context, CategoriaProduto cadastro)
        {

            context.Add(cadastro);
            return context.SaveChanges();
        }

        private Task<int> AddAsync(LiraContext context, CategoriaProduto cadastro)
        {

            context.Add(cadastro);
            return context.SaveChangesAsync();
        }

        public int Add(CategoriaProduto cadastro)
        {
            using (var context = new LiraContext())
            {
                context.Add(cadastro);
                return context.SaveChanges();
            }
        }

        public async Task<int> AddAsync(CategoriaProduto cadastro)
        {
            using (var context = new LiraContext())
            {
                await context.AddAsync(cadastro);
                return await context.SaveChangesAsync();
            }
        }

        public int Edit(CategoriaProduto cadastro)
        {
            using (var context = new LiraContext())
            {
                var cad = context.CategoriaProduto.Where(X => X.Id == cadastro.Id).FirstOrDefault();

                if (cad != null)
                {
                    cad = cadastro;
                    return context.SaveChanges();
                }
                else
                {
                    return Add(context, cadastro);
                }

            }
        }

        public async Task<int> EditAsync(CategoriaProduto cadastro)
        {
            using (var context = new LiraContext())
            {
                var cad = context.CategoriaProduto.Where(X => X.Id == cadastro.Id).FirstOrDefault();

                if (cad != null)
                {
                    cad = cadastro;
                    return await context.SaveChangesAsync();
                }
                else
                {
                    return await AddAsync(context, cadastro);
                }

            }
        }
        public int Delete(int ID)
        {
            using (var context = new LiraContext())
            {
                var cad = context.CategoriaProduto.Where(X => X.Id == ID).FirstOrDefault();

                if (cad != null)
                {
                    context.CategoriaProduto.Remove(cad);
                    return context.SaveChanges();
                }
                else
                {
                    return 0;
                }
            }
        }

        public async Task<int> DeleteAsync(int ID)
        {
            using (var context = new LiraContext())
            {
                var cad = context.CategoriaProduto.Where(X => X.Id == ID).FirstOrDefault();

                if (cad != null)
                {
                    context.CategoriaProduto.Remove(cad);
                    return await context.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            }
        }

        public CategoriaProduto Get(int CodigoObjeto)
        {
            using (var context = new LiraContext())
            {
                return context.CategoriaProduto.Find(CodigoObjeto);
            }
        }

        public async Task<CategoriaProduto> GetAsync(int CodigoObjeto)
        {
            using (var context = new LiraContext())
            {
                return await context.CategoriaProduto.FindAsync(CodigoObjeto);
            }
        }

        public List<CategoriaProduto> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoriaProduto>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
