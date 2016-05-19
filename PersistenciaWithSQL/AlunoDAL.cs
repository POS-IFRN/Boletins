using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaWithSQL
{
    public class AlunoDAL
    {
        private SqlClassesDataContext dc = new SqlClassesDataContext();

        public void Insert(Modelo.Aluno alun)
        {
            Aluno alu = new Aluno
            {
                id = alun.Id,
                nome = alun.Nome,
                fone = alun.fone,
                email = alun.email,
                idCurso = alun.IdCurso,
                nascimento = alun.nascimento
            };
            dc.Alunos.InsertOnSubmit(alu);
            dc.SubmitChanges();
        }

        public List<Modelo.Aluno> Select()
        {
            IEnumerable<Aluno> objs = from a in dc.Alunos select a;
            List<Modelo.Aluno> alunos = new List<Modelo.Aluno>();

            foreach (Aluno obj in objs)
            {
                Modelo.Aluno aluno = new Modelo.Aluno
                {
                    Id = obj.id,
                    Nome = obj.nome,
                    fone = obj.fone,
                    email = obj.email,
                    nascimento = Convert.ToDateTime(obj.nascimento),
                    IdCurso = Convert.ToInt16(obj.idCurso)
                };
                alunos.Add(aluno);
            }

            return alunos;
        }

        public void Update(Modelo.Aluno alun)
        {
            Aluno alu = (from a in dc.Alunos where a.id == alun.Id select a).Single();
            alu.nome = alun.Nome;
            alu.fone = alun.fone;
            alu.email = alun.email;
            alu.idCurso = alun.IdCurso;
            alu.nascimento = alun.nascimento;
            dc.SubmitChanges();
        }

        public void Delete(Modelo.Aluno alun)
        {
            Aluno alu = (from a in dc.Alunos where a.id == alun.Id select a).Single();
            dc.Alunos.DeleteOnSubmit(alu);
            dc.SubmitChanges();
        }

        public Aluno SelectOneLINQ(int id)
        {
            Aluno alu = (from a in dc.Alunos where a.id == id select a).Single();
            return alu;
        }
    }
}
