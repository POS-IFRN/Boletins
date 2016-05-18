using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaWithSQL
{
    class BoletimDAL
    {
        private SqlClassesDataContext dc = new SqlClassesDataContext();
        public void Insert(Modelo.Boletim bole)
        {
            List<Modelo.Disciplina> disciplinas = new DisciplinaDAL().Select();
            Modelo.Disciplina dis = (from d in disciplinas where d.Id == bole.IdDisciplina select d).Single();

            Boletim b = new Boletim
            {
                ano = bole.Ano,
                idAluno = bole.IdAluno,
                idDisciplina = bole.IdDisciplina,
                //Aluno = new AlunoDAL().SelectOneLINQ(bole.IdAluno),
                //Disciplina = new Disciplina
                //{
                //    id = dis.Id,
                //    descricao = dis.Descricao
                //},
                nota1 = bole.Nota1,
                nota2 = bole.Nota2,
                nota3 = bole.Nota3,
                nota4 = bole.Nota4,
                mediaParcial = bole.MediaParcial,
                notaFinal = bole.NotaFinal,
                mediaFinal = bole.MediaFinal,
            };

            dc.Boletims.InsertOnSubmit(b);
            dc.SubmitChanges();


        }

        public List<Modelo.Boletim> Select()
        {

            IEnumerable<Boletim> objs = from b in dc.Boletims select b;
            List<Modelo.Boletim> boletins = new List<Modelo.Boletim>();

            foreach (Boletim obj in objs)
            {
                Modelo.Boletim boletim = new Modelo.Boletim
                {
                    Ano = obj.ano,
                    IdAluno = obj.idAluno,
                    IdDisciplina = obj.idDisciplina,
                    Nota1 = Convert.ToInt16(obj.nota1),
                    Nota2 = Convert.ToInt16(obj.nota2),
                    Nota3 = Convert.ToInt16(obj.nota3),
                    Nota4 = Convert.ToInt16(obj.nota4),
                    MediaParcial = Convert.ToInt16(obj.mediaParcial),
                    NotaFinal = Convert.ToInt16(obj.notaFinal),
                    MediaFinal = Convert.ToInt16(obj.mediaFinal),
                };

                boletins.Add(boletim);
            }

            return boletins;

        }

        public void Update(Modelo.Boletim bole)
        {

            Boletim bol = (from b in dc.Boletims
                           where b.ano == bole.Ano
                           && b.idAluno == bole.IdAluno
                           && b.idAluno == bole.IdDisciplina
                           select b).Single();

            bol.nota1 = bole.Nota1;
            bol.nota2 = bole.Nota2;
            bol.nota3 = bole.Nota3;
            bol.nota4 = bole.Nota4;
            bol.mediaParcial = bole.MediaParcial;
            bol.notaFinal = bole.NotaFinal;
            bol.mediaFinal = bole.MediaFinal;
            dc.SubmitChanges();

        }

        public void Delete(Modelo.Boletim bole)
        {
            Boletim bol = (from b in dc.Boletims
                           where b.ano == bole.Ano
                           && b.idAluno == bole.IdAluno
                           && b.idAluno == bole.IdDisciplina
                           select b).Single();
            dc.Boletims.DeleteOnSubmit(bol);
            dc.SubmitChanges();
        }

    }
}
