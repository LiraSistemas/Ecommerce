using LiraCore.Entidades;
using LiraCore.Interfaces.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraData.Entity.CRUD
{
    public class ProdutoCRUD : IProduto
    {
        private int Add(EcommerceContext context, Produto produto)
        {
                        
            context.Add(produto);
            return context.SaveChanges();            
        }

        private Task<int> AddAsync(EcommerceContext context, Produto produto)
        {

            context.Add(produto);
            return context.SaveChangesAsync();
        }

        public int Add(Produto produto)
        {
            using (var context = new EcommerceContext())
            {
                context.Add(produto);
                return context.SaveChanges();
            }
        }

        public async Task<int> AddAsync(Produto produto)
        {
            using (var context = new EcommerceContext())
            {
                await context.AddAsync(produto);
                return await context.SaveChangesAsync();
            }
        }

        public int Edit(Produto produto)
        {
            using (var context = new EcommerceContext())
            {
                var prod = context.Produtos.Where(X => X.Id == produto.Id).FirstOrDefault();

                if (prod != null)
                {
                    prod = produto;
                    return context.SaveChanges();
                }
                else
                {
                    return Add(context, produto);
                }

            }
        }

        public async Task<int> EditAsync(Produto produto)
        {
            using (var context = new EcommerceContext())
            {
                var prod = context.Produtos.Where(X => X.Id == produto.Id).FirstOrDefault();

                if (prod != null)
                {
                    prod = produto;
                    return await context.SaveChangesAsync();
                }
                else
                {
                    return await AddAsync(context, produto);
                }

            }
        }
        public int Delete(int ID)
        {
            using (var context = new EcommerceContext())
            {
                var prod = context.Produtos.Where(X => X.Id == ID).FirstOrDefault();

                if (prod != null)
                {
                    context.Produtos.Remove(prod);
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
            using (var context = new EcommerceContext())
            {
                var prod = context.Produtos.Where(X => X.Id == ID).FirstOrDefault();

                if (prod != null)
                {
                    context.Produtos.Remove(prod);
                    return await context.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            }
        }

        public Produto Get(int CodigoObjeto)
        {
            using (var context = new EcommerceContext())
            {
                return context.Produtos.Find(CodigoObjeto);
            }
        }

        public async Task<Produto> GetAsync(int CodigoObjeto)
        {
            using (var context = new EcommerceContext())
            {
                return await context.Produtos.FindAsync(CodigoObjeto);
            }
        }
    }
}
