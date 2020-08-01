using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiraBelle.Interfaces;
using LiraBelle.Repositorios;
using LiraCore.Entidades;
using LiraCore.Interfaces;
using LiraData.FlatFile.CRUD;
using LiraEcommerce;
using LiraEcommerce.Enum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LiraBelle.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubCategoriaServicoController : ControllerBase
    {
        private readonly ISubCategoriaServico SubCategoriaServicoCRUD;        
        private readonly ISubCategoriaServicoRepositorioModel subCategoriaRepositorioModel;

        public SubCategoriaServicoController(ISubCategoriaServico _Crud, ISubCategoriaServicoRepositorioModel _Model)
        {
            SubCategoriaServicoCRUD = _Crud;            
            subCategoriaRepositorioModel = _Model;

            //var host = CreateHostBuilder().Build();
            //host.Services.GetRequiredService<ISubCategoriaServicoRepositorioModel>();
        }

        public async Task<IActionResult> Get()
        {

            try
            {
                return Ok(await subCategoriaRepositorioModel.Get());               
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        [Route("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {

            try
            {
                return Ok(await subCategoriaRepositorioModel.Get(Id));
                
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SubCategoriaServico categoria)
        {
            try
            {
                if (categoria != null)
                {
                    await SubCategoriaServicoCRUD.AddAsync(categoria);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.SubCategoriaNaoInformada));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] SubCategoriaServico categoria)
        {
            try
            {
                if (categoria != null)
                {
                    await SubCategoriaServicoCRUD.EditAsync(categoria);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.SubCategoriaNaoInformada));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id != null)
                {
                    await SubCategoriaServicoCRUD.DeleteAsync(id ?? 0);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.SubCategoriaNaoInformada));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
