using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Disciplina
    {
        public void Insert(Modelo.Disciplina d)
        {
            List<Modelo.Disciplina> disciplinas = Select();
            if (!disciplinas.Exists(dis => dis.Id == d.Id))
            {
                new Persistencia.Disciplina().Insert(d);
            }
        }

        public List<Modelo.Disciplina> Select()
        {
            return new Persistencia.Disciplina().Select();
        }
    }
}
