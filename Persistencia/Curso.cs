using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Persistencia
{
    public class Curso
    {
        private string arquivo = "c:\\temp\\lista03\\cursos.xml";

        public void Insert(Modelo.Curso c)
        {
            List<Modelo.Curso> cursos = abrirArquivo();
            cursos.Add(c);
            salvarArquivo(cursos);
        }

        public List<Modelo.Curso> Select()
        {
            return abrirArquivo();
        }

        public void Update(Modelo.Curso c)
        {
            List<Modelo.Curso> cursos = abrirArquivo();
            cursos.Insert(cursos.FindIndex(cur => cur.Id == c.Id), c);
            cursos.RemoveAt(cursos.FindLastIndex(cur => cur.Id == c.Id));
            salvarArquivo(cursos);

        }

        public void Delete(Modelo.Curso c)
        {
            List<Modelo.Curso> cursos = abrirArquivo();
            cursos.RemoveAt(cursos.FindIndex(cur => cur.Id == c.Id));
            salvarArquivo(cursos);
        }

        private List<Modelo.Curso> abrirArquivo()
        {
            List<Modelo.Curso> cursos = null;
            try
            {
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Curso>));
                    cursos = (List<Modelo.Curso>)xml.Deserialize(sr);
                }
            }
            catch
            {
                cursos = new List<Modelo.Curso>();
            }

            return cursos;
        }

        private void salvarArquivo(List<Modelo.Curso> cursos)
        {
            using (StreamWriter sw = new StreamWriter(arquivo))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Curso>));
                xml.Serialize(sw, cursos);
            }
        }
    }
}
