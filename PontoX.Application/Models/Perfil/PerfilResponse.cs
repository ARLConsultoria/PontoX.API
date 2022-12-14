﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoX.Application.Models.Perfil
{
    public class PerfilResponse
    {
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public PerfilResponse PerfilPai { get; set; }
    }
}
