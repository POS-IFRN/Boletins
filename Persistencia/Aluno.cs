using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Persistencia
{
    public class Aluno
    {
        private string arquivo = "c:\\temp\\lista03\\alunos.xml";

        public void Insert(Modelo.Aluno a)
        {
            List<Modelo.Aluno> alunos = abrirArquivo();
            alunos.Add(a);
            salvarArquivo(alunos);
        }

        public List<Modelo.Aluno> Select()
        {
            return abrirArquivo();
        }

        public void Update(Modelo.Aluno a)
        {
            List<Modelo.Aluno> alunos = abrirArquivo();
            alunos.Insert(alunos.FindIndex(al => al.Id == a.Id), a);
            alunos.RemoveAt(alunos.FindLastIndex(al => al.Id == a.Id));
            salvarArquivo(alunos);

        }

        public void Delete(Modelo.Aluno a)
        {
            List<Modelo.Aluno> alunos = abrirArquivo();
            alunos.RemoveAt(alunos.FindLastIndex(al => al.Id == a.Id));
            salvarArquivo(alunos);
        }

        private List<Modelo.Aluno> abrirArquivo()
        {
            List<Modelo.Aluno> alunos = null;
            try
            {
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Aluno>));
                    alunos = (List<Modelo.Aluno>)xml.Deserialize(sr);
                }
            }
            catch
            {
                alunos = new List<Modelo.Aluno>();
            }

            return alunos;
        }

        private void salvarArquivo(List<Modelo.Aluno> alunos)
        {
            using (StreamWriter sw = new StreamWriter(arquivo))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Aluno>));
                xml.Serialize(sw, alunos);
            }
        }
    }
}
