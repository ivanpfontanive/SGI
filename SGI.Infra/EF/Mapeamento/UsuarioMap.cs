using SGI.Dominio;
using SGI.Dominio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Infra.EF.Mapeamento
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            this.ToTable("Usuarios");

            this.HasKey(x => x.Id);

            this.Property(x => x.Email).HasMaxLength(100);

            this.Property(x => x.Login).HasMaxLength(20).IsRequired();

            this.Property(x => x.Nome).IsRequired().HasMaxLength(150);

            this.Property(x => x.Senha).HasMaxLength(14).IsRequired();

            this.HasMany(x => x.IdeiasInseridas)
                .WithRequired(x => x.InseridoPor)
                .HasForeignKey(x => x.IdInseridoPor)
                .WillCascadeOnDelete(false);
        }
    }
}