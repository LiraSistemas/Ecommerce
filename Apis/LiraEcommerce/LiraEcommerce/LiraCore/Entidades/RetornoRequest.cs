namespace LiraCore.Entidades
{
    public abstract class RetornoRequest<T>
    {
        protected T _objRetorno { get; set; }
        public int Codigo { get; set; }
        public string Msg { get; set; }
        public string MsgAdicional { get; set; }


        public RetornoRequest(T objRetorno)
        {
            _objRetorno = objRetorno;
        }

        /// <summary>
        /// De acordo com o tipo do atributo que será usado, retorna a menssagem apropriada
        /// </summary>
        /// <param name="retorno"></param>
        /// <returns></returns>
        protected abstract string GetMensagem();

        /// <summary>
        /// De acordo com o _objRetorno atribui os valores a codigo, msg e MsgAdicional
        /// </summary>
        /// <param name="retorno"></param>
        protected abstract void AtribuiValoresRetorno();

        
    }
}
