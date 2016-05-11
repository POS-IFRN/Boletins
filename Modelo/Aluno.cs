using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string email { get; set; }
        public string fone { get; set; }
        public DateTime nascimento { get; set; }
        public int IdCurso { get; set; }

    }
}
