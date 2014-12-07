using SGI.Dominio.Entidades;
using SGI.Dominio.Entidades.Ideias;
using SGI.Dominio.Entidades.Usuarios;
using SGI.Infra.EF.Mapeamento;
using System.Data.Entity;

namespace SGI.Infra.EF
{
    public class IdeiaEFContext : DbContext, IRepositorioContexto
    {
        public IdeiaEFContext()
            : base("IdeiaEFContext")
        {
            // ROLA - This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
            // As it is installed in the GAC, Copy Local does not work. It is required for probing.
            // Fixed "Provider not loaded" error
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            Database.SetInitializer<IdeiaEFContext>(new CreateDatabaseIfNotExists<IdeiaEFContext>());
        }

        public IDbSet<Usuario> Usuarios { get; set; }

        public IDbSet<Ideia> Ideias { get; set; }

        public IDbSet<IdeiaCategoria> IdeiasCategorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new IdeiaMap());
            modelBuilder.Configurations.Add(new IdeiaCategoriaMap());

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseDominio
        {
            return base.Set<TEntity>();
        }
    }
}