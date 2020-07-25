using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiraCore.Entidades;
using LiraCore.Interfaces;
using LiraEcommerce;
using LiraEcommerce.Enum;
using Microsoft.AspNetCore.Mvc;

namespace LiraBelle.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubCategoriaServicoController : ControllerBase
    {
        private readonly ISubCategoriaServico SubCategoriaServicoCRUD;

        public SubCategoriaServicoController(ISubCategoriaServico _Crud)
        {
            SubCategoriaServicoCRUD = _Crud;
        }

        public async Task<IActionResult> Get()
        {

            try
            {
                var serv = await SubCategoriaServicoCRUD.GetAsync();

                return Ok(serv);
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
                var serv = await SubCategoriaServicoCRUD.GetAsync(Id);

                return Ok(serv);
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
    }
}
