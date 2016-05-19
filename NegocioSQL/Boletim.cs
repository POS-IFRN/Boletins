using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioSQL
{
    public class Boletim
    {
        public void Insert(Modelo.Boletim bole)
        {
            List<Modelo.Boletim> boletins = Select();
            if (!boletins.Exists(bol => bol.Ano == bole.Ano &&
            bol.IdAluno == bole.IdAluno &&
            bol.IdDisciplina == bole.IdDisciplina))
            {
                new PersistenciaWithSQL.BoletimDAL().Insert(bole);
            }
        }

        public List<Modelo.Boletim> Select()
        {
            return new PersistenciaWithSQL.BoletimDAL().Select();
        }

        public void Update(Modelo.Boletim bole)
        {
            List<Modelo.Boletim> boletins = Select();
            if (boletins.Exists(bol => bol.Ano == bole.Ano &&
            bol.IdAluno == bole.IdAluno &&
            bol.IdDisciplina == bole.IdDisciplina))
            {
                new PersistenciaWithSQL.BoletimDAL().Update(bole);
            }
        }

        public void Delete(Modelo.Boletim bole)
        {
            List<Modelo.Boletim> boletins = Select();
            if (boletins.Exists(bol => bol.Ano == bole.Ano &&
            bol.IdAluno == bole.IdAluno &&
            bol.IdDisciplina == bole.IdDisciplina))
            {
                new PersistenciaWithSQL.BoletimDAL().Delete(bole);
            }
        }
    }
}
