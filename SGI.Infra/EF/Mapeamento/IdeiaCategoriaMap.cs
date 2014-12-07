using SGI.Dominio;
using SGI.Dominio.Entidades.Ideias;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Infra.EF.Mapeamento
{
    public class IdeiaCategoriaMap : EntityTypeConfiguration<IdeiaCategoria>
    {
        public IdeiaCategoriaMap()
        {
            this.ToTable("IdeiasCategorias");

            this.HasKey(x => x.Id);

            this.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        }
    }
}