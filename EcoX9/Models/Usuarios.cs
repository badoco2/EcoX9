using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoX9.Models
{
    public class Usuarios
    {
        public long Id { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONE { get; set; }
        public string SENHA { get; set; }
        public string FLAG_SIT { get; set; }
        public string FLAG { get; set; }
        public List<Ocorrencias> Ocorrencias { get; set; }
    }
}
