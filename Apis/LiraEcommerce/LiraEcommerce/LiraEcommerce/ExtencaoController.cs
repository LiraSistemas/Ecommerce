using LiraEcommerce.Entidades;
using LiraEcommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiraEcommerce
{
    public static class ExtencaoController
    {
        public static RetornoRequestLiraEcommerce GetRetorno(RetornoRequisicao retorno)
        {
            return new RetornoRequestLiraEcommerce(retorno);
        }

        public static RetornoRequestLiraEcommerce GetRetorno(RetornoRequisicao retorno, Exception ex)
        {
            var ret = GetRetorno(retorno);
            ret.MsgAdicional = ex.Message;

            return ret;
        }
    }
}
