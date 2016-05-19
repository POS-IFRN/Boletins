using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioSQL
{
    public class Disciplina
    {
        public void Insert(Modelo.Disciplina disc)
        {
            List<Modelo.Disciplina> disciplinas = Select();
            if (!disciplinas.Exists(dis => dis.Id == disc.Id))
            {
                new PersistenciaWithSQL.DisciplinaDAL().Insert(disc);
            }
        }

        public List<Modelo.Disciplina> Select()
        {
            return new PersistenciaWithSQL.DisciplinaDAL().Select();
        }

        public void Update(Modelo.Disciplina disc)
        {
            List<Modelo.Disciplina> disciplinas = Select();
            if (disciplinas.Exists(dis => dis.Id == disc.Id))
            {
                new PersistenciaWithSQL.DisciplinaDAL().Update(disc);
            }
        }

        public void Delete(Modelo.Disciplina disc)
        {
            List<Modelo.Disciplina> disciplinas = Select();
            if (disciplinas.Exists(dis => dis.Id == disc.Id))
            {
                new PersistenciaWithSQL.DisciplinaDAL().Delete(disc);
            }
        }
    }
}
