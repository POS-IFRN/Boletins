using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaWithSQL
{
    public class CursoDAL
    {
        private EscolaDataContext dc = new EscolaDataContext();

        public void Insert(Modelo.Curso curs)
        {
            Curso cur = new Curso
            {
                id = curs.Id,
                descricao = curs.Descricao
            };
            dc.Cursos.InsertOnSubmit(cur);
            dc.SubmitChanges();
        }

        public List<Modelo.Curso> Select()
        {
            IEnumerable<Curso> objs = from c in dc.Cursos select c;
            List<Modelo.Curso> cursos = new List<Modelo.Curso>();

            foreach (Curso obj in objs)
            {
                Modelo.Curso c = new Modelo.Curso
                {
                    Id = obj.id,
                    Descricao = obj.descricao
                };
                cursos.Add(c);
            }

            return cursos;
        }

        public void Update(Modelo.Curso curs)
        {
            Curso cur = (from c in dc.Cursos where c.id == curs.Id select c).Single();
            cur.descricao = curs.Descricao;
            dc.SubmitChanges();
        }

        public void Delete(Modelo.Curso curs)
        {
            Curso cur = (from c in dc.Cursos where c.id == curs.Id select c).Single();
            dc.Cursos.DeleteOnSubmit(cur);
            dc.SubmitChanges();
        }
    }
}
