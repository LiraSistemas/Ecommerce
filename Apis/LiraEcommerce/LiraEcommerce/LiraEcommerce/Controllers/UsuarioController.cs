using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiraBelle.Interfaces;
using LiraCore.Entidades;
using LiraCore.Interfaces;
using LiraEcommerce;
using LiraEcommerce.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiraBelle.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuario UsuarioCRUD;
        private readonly IUsuarioRepositorioViewModel UsuarioRepositorio;

        public UsuarioController(IUsuario _Crud, IUsuarioRepositorioViewModel _Repositorio)
        {
            UsuarioCRUD = _Crud;
            UsuarioRepositorio = _Repositorio;
        }

        public async Task<IActionResult> Get()
        {

            try
            {
                var serv = await UsuarioRepositorio.Get();

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
                var serv = await UsuarioRepositorio.Get(Id);

                return Ok(serv);
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Usuario cadastro)
        {
            try
            {
                if (cadastro != null)
                {
                    await UsuarioCRUD.AddAsync(cadastro);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.UsuarioNaoInformado));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Usuario cadastro)
        {
            try
            {
                if (cadastro != null)
                {
                    await UsuarioCRUD.EditAsync(cadastro);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.UsuarioNaoInformado));
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
                    await UsuarioCRUD.DeleteAsync(id ?? 0);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.UsuarioNaoInformado));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }
    }
}

