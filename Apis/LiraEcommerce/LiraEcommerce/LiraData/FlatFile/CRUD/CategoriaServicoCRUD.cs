using LiraCore.Entidades;
using LiraCore.Interfaces;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraData.FlatFile.CRUD
{
    public class CategoriaServicoCRUD : ICategoriaServico
    {
        public int Add(CategoriaServico cadastro)
        {
            try
            {
                cadastro.Id = FlatLira.CadastroCategoriaServico.Max(X => X.Id) + 1;
                FlatLira.CadastroCategoriaServico.Add(cadastro);
                FlatLira.SetCadastro<CategoriaServico>(FlatLira.CadastroCategoriaServico, FlatLira.ArqCategoriaServico);

                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public Task<int> AddAsync(CategoriaServico cadastro)
        {
            Task<int> T = new Task<int>(() => { return Add(cadastro); });
            T.Start();

            return T;
        }

        public int Delete(int ID)
        {
            try
            {
                FlatLira.CadastroCategoriaServico.Remove(FlatLira.CadastroCategoriaServico.Find(X => X.Id == ID));
                FlatLira.SetCadastro<CategoriaServico>(FlatLira.CadastroCategoriaServico, FlatLira.ArqCategoriaServico);

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

        public int Edit(CategoriaServico cadastro)
        {
            try
            {
                var Cad = FlatLira.CadastroCategoriaServico.Find(X => X.Id == cadastro.Id);

                if(Cad != null)
                FlatLira.CadastroCategoriaServico[FlatLira.CadastroCategoriaServico.IndexOf(Cad)] = cadastro;


                FlatLira.SetCadastro<CategoriaServico>(FlatLira.CadastroCategoriaServico, FlatLira.ArqCategoriaServico);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Task<int> EditAsync(CategoriaServico cadastro)
        {
            Task<int> T = new Task<int>(() => { return Edit(cadastro); });
            T.Start();

            return T;
        }

        public CategoriaServico Get(int CodigoObjeto)
        {
            var retorno = FlatLira.CadastroCategoriaServico.Where(X => X.Id == CodigoObjeto).FirstOrDefault();
            retorno.SubCategorias = FlatLira.CadastroSubCategoriaServico.Where(X => X.IdCategoria == retorno.Id).ToList();

            return retorno;
        }

        public List<CategoriaServico> Get()
        {
            List<CategoriaServico> retorno;

            if (FlatLira.CadastroSubCategoriaServico.Count > 0)
            {
                 retorno = (from cat in FlatLira.CadastroCategoriaServico
                              join sub in FlatLira.CadastroSubCategoriaServico.DefaultIfEmpty() on cat.Id equals sub?.IdCategoria ?? 0
                              group new { cat, sub } by cat.Id into newgroup
                              select new CategoriaServico()
                              {
                                  Id = newgroup.FirstOrDefault().cat.Id,
                                  Descricao = newgroup.FirstOrDefault().cat.Descricao,
                                  SubCategorias = newgroup.Select(X => new SubCategoriaServico()
                                  { 
                                      Id = X.sub.Id,
                                      IdCategoria = X.sub.IdCategoria,
                                      Descricao = X.sub.Descricao,
                                      Link = X.sub.Link

                                      }).ToList()
                              }).ToList();
            }
            else
            {
                retorno = FlatLira.CadastroCategoriaServico;
            }


            return retorno.ToList();
        }

        public Task<CategoriaServico> GetAsync(int CodigoObjeto)
        {
            Task<CategoriaServico> T = new Task<CategoriaServico>(() => { return Get(CodigoObjeto); });
            T.Start();

            return T;
        }

        public Task<List<CategoriaServico>> GetAsync()
        {
            Task<List<CategoriaServico>> T = new Task<List<CategoriaServico>>(() => { return Get(); });
            T.Start();

            return T;
        }
    }
}
