using SGI.Dominio.Entidades.Ideias;
using SGI.Dominio.Interfaces.Repositorios;
using SGI.Infra.EF;
using System.Linq;

namespace SGI.DAL
{
    public class IdeiaDAL : BaseDAL<Ideia>, IIdeiaDAL
    {
        public IdeiaDAL(IRepositorioContexto contexto)
        {
            this.ContextoEF = contexto;
        }
    }
}