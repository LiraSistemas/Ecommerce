﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LiraCore.Entidades
{
    [Serializable]
    public class SubCategoriaServico
    {
        public int IdCategoria {get;set;}        
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }
    }
}
