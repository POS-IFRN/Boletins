using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioSQL
{
    public class Aluno
    {

        public void Insert(Modelo.Aluno alun)
        {
            List<Modelo.Aluno> alunos = Select();
            if (!alunos.Exists(al => al.Id == alun.Id))
            {
                new PersistenciaWithSQL.AlunoDAL().Insert(alun);
            }
        }

        public List<Modelo.Aluno> Select()
        {
            return new PersistenciaWithSQL.AlunoDAL().Select();
        }

        public void Update(Modelo.Aluno alun)
        {
            List<Modelo.Aluno> alunos = Select();
            if (alunos.Exists(al => al.Id == alun.Id))
                new PersistenciaWithSQL.AlunoDAL().Update(alun);
        }

        public void Delete(Modelo.Aluno alun)
        {
            List<Modelo.Aluno> alunos = Select();
            if (alunos.Exists(al => al.Id == alun.Id))
                new PersistenciaWithSQL.AlunoDAL().Delete(alun);
        }
    }
}
