﻿using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraData.Entity.CRUD
{
    public class ParceiroCRUD : IParceiro
    {
        private int Add(EcommerceContext context, Parceiro parceiro)
        {

            context.Add(parceiro);
            return context.SaveChanges();
        }

        private Task<int> AddAsync(EcommerceContext context, Parceiro parceiro)
        {

            context.Add(parceiro);
            return context.SaveChangesAsync();
        }

        public int Add(Parceiro cadastro)
        {
            using (var context = new EcommerceContext())
            {
                context.Add(cadastro);
                return context.SaveChanges();
            }
        }

        public async Task<int> AddAsync(Parceiro cadastro)
        {
            using (var context = new EcommerceContext())
            {
                await context.AddAsync(cadastro);
                return await context.SaveChangesAsync();
            }
        }

        public int Edit(Parceiro cadastro)
        {
            using (var context = new EcommerceContext())
            {
                var parc = context.Parceiros.Where(X => X.Id == cadastro.Id).FirstOrDefault();

                if (parc != null)
                {
                    parc = cadastro;
                    return context.SaveChanges();
                }
                else
                {
                    return Add(context, cadastro);
                }

            }
        }

        public async Task<int> EditAsync(Parceiro cadastro)
        {
            using (var context = new EcommerceContext())
            {
                var parc = context.Parceiros.Where(X => X.Id == cadastro.Id).FirstOrDefault();

                if (parc != null)
                {
                    parc = cadastro;
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
            using (var context = new EcommerceContext())
            {
                var parc = context.Parceiros.Where(X => X.Id == ID).FirstOrDefault();

                if (parc != null)
                {
                    context.Parceiros.Remove(parc);
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
                var parc = context.Parceiros.Where(X => X.Id == ID).FirstOrDefault();

                if (parc != null)
                {
                    context.Parceiros.Remove(parc);
                    return await context.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            }
        }

        public Parceiro Get(int CodigoObjeto)
        {
            using (var context = new EcommerceContext())
            {
                return context.Parceiros.Find(CodigoObjeto);
            }
        }

        public async Task<Parceiro> GetAsync(int CodigoObjeto)
        {
            using (var context = new EcommerceContext())
            {
                return await context.Parceiros.FindAsync(CodigoObjeto);
            }
        }
    }
}
