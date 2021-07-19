using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoX9.Models
{
    public class Tipo_Ocorrencia
    {
        public long ID { get; set; }
        public string NOME_TIPO { get; set; }
        public string DESC_TIPO { get; set; }
        public List<Ocorrencias> Ocorrencias { get; set; }
    }
}
