using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiraCore.Entidades;
using LiraCore.Interfaces.Produtos;
using LiraEcommerce.Entidades;
using LiraEcommerce.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiraEcommerce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProduto ProdutoCRUD;

        public ProdutoController(IProduto _Crud)
        {
            ProdutoCRUD = _Crud;
        }

        [Route("get/{Id}")]
        public async Task<IActionResult> GetProduto(int Id)
        {

            try
            {
                var prod = await ProdutoCRUD.GetAsync(Id);

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));                
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddProduto([FromBody] Produto produto)
        {
            try
            {
                if (produto != null)
                {
                    await ProdutoCRUD.AddAsync(produto);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ProdutoNaoInformado));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }            
        }

        [Route("edit")]
        [HttpPut]
        public async Task<IActionResult> EditProduto([FromBody] Produto produto)
        {
            try
            {
                if (produto != null)
                {
                    await ProdutoCRUD.EditAsync(produto);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ProdutoNaoInformado));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduto(int? id)
        {
            try
            {
                if (id != null)
                {
                    await ProdutoCRUD.DeleteAsync(id ?? 0);

                    return Ok();
                }
                else
                {
                    return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ProdutoNaoInformado));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ExtencaoController.GetRetorno(RetornoRequisicao.ErroNaoIdentificado, ex));
            }
        }

    }
}
