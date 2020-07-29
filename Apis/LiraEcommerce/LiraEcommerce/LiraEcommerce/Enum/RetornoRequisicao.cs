using System.ComponentModel;


namespace LiraEcommerce.Enum
{
    public enum RetornoRequisicao
    {
        [DescriptionAttribute("Requisição concluida com sucesso!")]
        OK = 0,
        [DescriptionAttribute("Produto não informado (-50)")]
        ProdutoNaoInformado = 50,
        [DescriptionAttribute("Categoria não informado(-60)")]
        CategoriaNaoInformada = 60,
        [DescriptionAttribute("SubCategoria não informado(-70)")]
        SubCategoriaNaoInformada = 70,
        [DescriptionAttribute("Estabelecimento não informado(-80)")]
        Estabelecimento = 80,
        [DescriptionAttribute("Erro nao identificado (-999)")]
        ErroNaoIdentificado = 999

    }
}
