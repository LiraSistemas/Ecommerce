using LiraCore.Entidades;
using LiraEcommerce.Enum;
using System.ComponentModel;
using System.Reflection;

namespace LiraEcommerce.Entidades
{
    public class RetornoRequestLira : RetornoRequest<RetornoRequisicao>
    {
        public RetornoRequestLira(RetornoRequisicao retorno) : base(retorno) {  }

        protected override void AtribuiValoresRetorno()
        {
            Codigo = (int)this._objRetorno;
            Msg = GetMensagem();
        }

        protected override string GetMensagem()
        {
            return _objRetorno.GetType().GetCustomAttribute<DescriptionAttribute>(false)?.Description;
        }
    }
}
