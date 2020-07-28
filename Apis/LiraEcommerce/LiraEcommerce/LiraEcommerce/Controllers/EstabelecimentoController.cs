using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiraCore.Interfaces;
using LiraEcommerce;
using LiraEcommerce.Enum;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiraBelle.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimento EstabelecimentoCRUD;

        public EstabelecimentoController(IEstabelecimento _Crud)
        {
            EstabelecimentoCRUD = _Crud;
        }

        public async Task<IActionResult> Get()
        {

            try
            {
                var serv = await EstabelecimentoCRUD.GetAsync();

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
                var serv = await CategoriaServicoCRUD.GetAsync(Id);

                return Ok(serv);
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoriaServico categoria)
        {
            try
            {
                if (categoria != null)
                {
                    await CategoriaServicoCRUD.AddAsync(categoria);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.CategoriaNaoInformada));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CategoriaServico categoria)
        {
            try
            {
                if (categoria != null)
                {
                    await CategoriaServicoCRUD.EditAsync(categoria);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.CategoriaNaoInformada));
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
                    await CategoriaServicoCRUD.DeleteAsync(id ?? 0);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.CategoriaNaoInformada));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }
    }
}
