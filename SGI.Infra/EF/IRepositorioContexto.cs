using SGI.Dominio;
using SGI.Dominio.Entidades;
using SGI.Dominio.Entidades.Ideias;
using SGI.Dominio.Entidades.Usuarios;
using System;
using System.Data.Entity;

namespace SGI.Infra.EF
{
    public interface IRepositorioContexto : IDisposable
    {
        IDbSet<Usuario> Usuarios { get; set; }

        IDbSet<Ideia> Ideias { get; set; }

        IDbSet<IdeiaCategoria> IdeiasCategorias { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseDominio;

        int SaveChanges();
    }
}