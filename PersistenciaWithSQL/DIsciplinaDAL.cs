using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaWithSQL
{
    public class DisciplinaDAL
    {
        private EscolaDataContext dc = new EscolaDataContext();

        public void Insert(Modelo.Disciplina disc)
        {
            Disciplina dis = new Disciplina
            {
                id = disc.Id,
                descricao = disc.Descricao
            };
            dc.Disciplinas.InsertOnSubmit(dis);
            dc.SubmitChanges();
        }

        public List<Modelo.Disciplina> Select()
        {
            IEnumerable <Disciplina> objs = from d in dc.Disciplinas select d;
            List<Modelo.Disciplina> disciplinas = new List<Modelo.Disciplina>();

            foreach (Disciplina obj in objs)
            {
                Modelo.Disciplina d = new Modelo.Disciplina
                {
                    Id = obj.id,
                    Descricao = obj.descricao
                };
                disciplinas.Add(d);
            }

            return disciplinas;
        }

        public void Update(Modelo.Disciplina disc)
        {
            Disciplina dis = (from d in dc.Disciplinas where d.id == disc.Id select d).Single();
            dis.descricao = disc.Descricao;
            dc.SubmitChanges();
        }

        public void Delete(Modelo.Disciplina disc)
        {
            Disciplina dis = (from d in dc.Disciplinas where d.id == disc.Id select d).Single();
            dc.Disciplinas.DeleteOnSubmit(dis);
            dc.SubmitChanges();
        }
    }
}
