using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Persistencia
{
    public class Disciplina
    {
        private string arquivo = "c:\\temp\\lista03\\disciplinas.xml";

        public void Insert(Modelo.Disciplina d)
        {
            List<Modelo.Disciplina> disciplinas = abrirArquivo();
            disciplinas.Add(d);
            salvarArquivo(disciplinas);
        }

        public List<Modelo.Disciplina> Select()
        {
            return abrirArquivo();
        }

        public void Update(Modelo.Disciplina d)
        {
            List<Modelo.Disciplina> disciplinas = abrirArquivo();
            disciplinas.Insert(disciplinas.FindIndex(dis => dis.Id == d.Id), d);
            disciplinas.RemoveAt(disciplinas.FindLastIndex(dis => dis.Id == d.Id));
            salvarArquivo(disciplinas);

        }

        public void Delete(Modelo.Disciplina d)
        {
            List<Modelo.Disciplina> disciplinas = abrirArquivo();
            disciplinas.RemoveAt(disciplinas.FindIndex(dis => dis.Id == d.Id));
            salvarArquivo(disciplinas);
        }

        private List<Modelo.Disciplina> abrirArquivo()
        {
            List<Modelo.Disciplina> disciplinas = null;
            try
            {
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Disciplina>));
                    disciplinas = (List<Modelo.Disciplina>)xml.Deserialize(sr);
                }
            }
            catch
            {
                disciplinas = new List<Modelo.Disciplina>();
            }

            return disciplinas;
        }

        private void salvarArquivo(List<Modelo.Disciplina> disciplinas)
        {
            using (StreamWriter sw = new StreamWriter(arquivo))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Disciplina>));
                xml.Serialize(sw, disciplinas);
            }
        }
    }
}
