﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.altervista.numerone.framework
{
    public class Opzioni
    {
        public string NomeUtente { get; set; }
        public string NomeCpu { get; set; }
        public bool briscolaDaPunti { get; set; }
        public bool avvisaTalloneFinito { get; set; }
        public string nomeMazzo { get; set;}
        public UInt16 livello { get; set; }
        public bool stessoSeme { get; set; }
    }
}
