using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Curso
    {

        public void Insert(Modelo.Curso c)
        {
            List<Modelo.Curso> cursos = Select();
            if (!cursos.Exists(cur => cur.Id == c.Id))
            {
                new Persistencia.Curso().Insert(c);
            }
        }

        public List<Modelo.Curso> Select()
        {
            return new Persistencia.Curso().Select();
        }

        public void Update(Modelo.Curso c)
        {
            List<Modelo.Curso> cursos = Select();
            if (cursos.Exists(cur => cur.Id == c.Id))
            {
                new Persistencia.Curso().Update(c);
            }
        }

        public void Delete(Modelo.Curso c)
        {
            List<Modelo.Curso> cursos = Select();
            if (cursos.Exists(cur => cur.Id == c.Id))
            {
                new Persistencia.Curso().Delete(c);
            }
        }
    }
}
