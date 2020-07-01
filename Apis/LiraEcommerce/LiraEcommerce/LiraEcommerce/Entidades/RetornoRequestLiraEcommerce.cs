using LiraCore.Entidades;
using LiraEcommerce.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LiraEcommerce.Entidades
{
    public class RetornoRequestLiraEcommerce : RetornoRequest<RetornoRequisicao>
    {
        public RetornoRequestLiraEcommerce(RetornoRequisicao retorno) : base(retorno) {  }

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
