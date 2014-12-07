using SGI.Dominio;
using SGI.Dominio.Entidades.Usuarios;
using SGI.Dominio.Interfaces.Repositorios;
using SGI.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.DAL
{
    public class UsuarioDAL : BaseDAL<Usuario>, IUsuarioDAL
    {
        public UsuarioDAL(IRepositorioContexto contexto)
        {
            this.ContextoEF = contexto;
        }
    }
}