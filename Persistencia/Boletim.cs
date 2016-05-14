using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Persistencia
{
    public class Boletim
    {
        private string arquivo = "c:\\temp\\lista03\\boletins.xml";

        public void Insert(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = abrirArquivo();
            boletins.Add(b);
            salvarArquivo(boletins);
        }

        public List<Modelo.Boletim> Select()
        {
            return abrirArquivo();
        }

        public void Update(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = abrirArquivo();
            boletins.Insert(boletins.FindIndex(bol => 
            bol.Ano == b.Ano && 
            bol.IdAluno == b.IdAluno &&
            bol.IdDisciplina == b.IdDisciplina), b);
            boletins.RemoveAt(boletins.FindLastIndex(bol =>
            bol.Ano == b.Ano &&
            bol.IdAluno == b.IdAluno &&
            bol.IdDisciplina == b.IdDisciplina));
            salvarArquivo(boletins);
            

        }

        public void Delete(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = abrirArquivo();
            boletins.RemoveAt(boletins.FindLastIndex(bol =>
           bol.Ano == b.Ano &&
           bol.IdAluno == b.IdAluno &&
           bol.IdDisciplina == b.IdDisciplina));
            salvarArquivo(boletins);
        }

        private List<Modelo.Boletim> abrirArquivo()
        {
            List<Modelo.Boletim> boletins = null;
            try
            {
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Boletim>));
                    boletins = (List<Modelo.Boletim>)xml.Deserialize(sr);
                }
            }
            catch
            {
                boletins = new List<Modelo.Boletim>();
            }

            return boletins;
        }

        private void salvarArquivo(List<Modelo.Boletim> boletins)
        {
            using (StreamWriter sw = new StreamWriter(arquivo))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Boletim>));
                xml.Serialize(sw, boletins);
            }
        }
    }
}
