using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Boletim
    {
        public int Ano { get; set; }
        public int IdAluno { get; set; }
        public int IdDisciplina { get; set; }
        public int Nota1 { get; set; }
        public int Nota2 { get; set; }
        public int Nota3 { get; set; }
        public int Nota4 { get; set; }
        public int MediaParcial { get; set; }
        public int NotaFinal { get; set; }
        public int MediaFinal { get; set; }
    }
}
