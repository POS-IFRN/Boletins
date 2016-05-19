using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NegocioSQL
{
    public class Curso
    {
        private PersistenciaWithSQL.SqlClassesDataContext dc = new PersistenciaWithSQL.SqlClassesDataContext();
  
        public void Insert(Modelo.Curso curs)
        {
            List<Modelo.Curso> cursos = Select();
            if (!cursos.Exists(cur => cur.Id == curs.Id))
            {
                new PersistenciaWithSQL.CursoDAL().Insert(curs);
            }
        }

        public List<Modelo.Curso> Select()
        {
            return new PersistenciaWithSQL.CursoDAL().Select();
        }

        public void Update(Modelo.Curso curs)
        {
            List<Modelo.Curso> cursos = Select();
            if (cursos.Exists(cur => cur.Id == curs.Id))
            {
                new PersistenciaWithSQL.CursoDAL().Update(curs);
            }
        }

        public void Delete(Modelo.Curso curs)
        {
            List<Modelo.Curso> cursos = Select();
            if (cursos.Exists(cur => cur.Id == curs.Id))
            {
                new PersistenciaWithSQL.CursoDAL().Delete(curs);
            }
        }
    }
}
