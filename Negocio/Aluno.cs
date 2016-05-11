using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Aluno
    {

        public void Insert(Modelo.Aluno a)
        {
            List<Modelo.Aluno> alunos = Select();
            if (!alunos.Exists(al => al.Id == a.Id))
            {
                new Persistencia.Aluno().Insert(a);
            }
        }

        public List<Modelo.Aluno> Select()
        {
            return new Persistencia.Aluno().Select();
        }
    }
}
