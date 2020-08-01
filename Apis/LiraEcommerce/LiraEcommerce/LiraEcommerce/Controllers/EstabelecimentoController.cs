using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiraBelle.Interfaces;
using LiraCore.Entidades;
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
        private readonly IEstabelecimentoRepositorioViewModel EstabelecimentoRepositorio;
        public EstabelecimentoController(IEstabelecimento _Crud, IEstabelecimentoRepositorioViewModel _Repositorio)
        {
            EstabelecimentoCRUD = _Crud;
            EstabelecimentoRepositorio = _Repositorio;
        }

        public async Task<IActionResult> Get()
        {

            try
            {
                var serv = await EstabelecimentoRepositorio.Get();

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
                var serv = await EstabelecimentoRepositorio.Get(Id);

                return Ok(serv);
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Estabelecimento cadastro)
        {
            try
            {
                if (cadastro != null)
                {
                    await EstabelecimentoCRUD.AddAsync(cadastro);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.EstabelecimentoNaoInformado));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Estabelecimento cadastro)
        {
            try
            {
                if (cadastro != null)
                {
                    await EstabelecimentoCRUD.EditAsync(cadastro);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.EstabelecimentoNaoInformado));
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
                    await EstabelecimentoCRUD.DeleteAsync(id ?? 0);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.EstabelecimentoNaoInformado));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }
    }
}
