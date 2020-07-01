using System.ComponentModel;


namespace LiraEcommerce.Enum
{
    public enum RetornoRequisicao
    {
        [DescriptionAttribute("Requisição concluida com sucesso!")]
        OK = 0,
        [DescriptionAttribute("Produto não informado (-50)")]
        ProdutoNaoInformado = 50,
        [DescriptionAttribute("Erro nao identificado (-999)")]
        ErroNaoIdentificado = 999

    }
}
