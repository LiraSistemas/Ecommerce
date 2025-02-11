﻿using System;
using System.Threading.Tasks;
using LiraBelle.Interfaces;
using LiraCore.Entidades;
using LiraCore.Interfaces;
using LiraEcommerce;
using LiraEcommerce.Enum;
using Microsoft.AspNetCore.Mvc;

namespace LiraBelle.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaServicoController : ControllerBase
    {
        private readonly ICategoriaServico CategoriaServicoCRUD;
        private readonly ICategoriaServicoRepositorioViewModel CategoriaServicoRepositorio;

        public CategoriaServicoController(ICategoriaServico _Crud, ICategoriaServicoRepositorioViewModel _CategoriaServicoViewModel)
        {
            CategoriaServicoCRUD = _Crud;
            CategoriaServicoRepositorio = _CategoriaServicoViewModel;
        }
        
        public async Task<IActionResult> Get()
        {

            try
            {
                var serv = await CategoriaServicoRepositorio.Get();

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
                var serv = await CategoriaServicoRepositorio.Get(Id);

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
