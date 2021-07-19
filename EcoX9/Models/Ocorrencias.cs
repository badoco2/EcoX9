﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoX9.Models
{
    public class Ocorrencias
    {
        public long Id { get; set; }
        public string COD_OCO { get; set; }
        public string DESC_OCO { get; set; }
        public DateTime DT_OCO { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string DESC_INFRA { get; set; }
        public string PONTO_REF { get; set; }
        public string FOTO { get; set; }
        public string FLAG_SIT { get; set; }
        public string FLAG { get; set; }
        public long UsuariosId { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public long TiposId { get; set; }
        public virtual Tipo_Ocorrencia Tipo_Ocorrencia { get; set; }
    }
}
