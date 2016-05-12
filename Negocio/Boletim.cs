using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Boletim
    {

        public void Insert(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = Select();
            if (!boletins.Exists(bol => bol.Ano == b.Ano && 
            bol.IdAluno == b.IdAluno && 
            bol.IdDisciplina == b.IdDisciplina))
            {
                new Persistencia.Boletim().Insert(b);
            }
        }

        public List<Modelo.Boletim> Select()
        {
            return new Persistencia.Boletim().Select();
        }

        public void Update(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = Select();
            if (boletins.Exists(bol => bol.Ano == b.Ano &&
            bol.IdAluno == b.IdAluno &&
            bol.IdDisciplina == b.IdDisciplina))
            {
                new Persistencia.Boletim().Update(b);
            }
        }

        public void Delete(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = Select();
            if (boletins.Exists(bol => bol.Ano == b.Ano &&
            bol.IdAluno == b.IdAluno &&
            bol.IdDisciplina == b.IdDisciplina))
            {
                new Persistencia.Boletim().Delete(b);
            }
        }
    }
}
