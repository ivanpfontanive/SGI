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
    public class IdeiaMap : EntityTypeConfiguration<Ideia>
    {
        public IdeiaMap()
        {
            this.ToTable("Ideias");

            this.HasKey(x => x.Id);

            this.Property(x => x.DataCriacao).IsRequired();

            this.Property(x => x.Descricao).IsVariableLength();

            this.Property(x => x.Ordem).IsRequired();

            this.Property(x => x.Prioridade).IsRequired();

            this.Property(x => x.Titulo).HasMaxLength(200).IsRequired();

            this.HasMany(x => x.Idealizadores)
                .WithMany(x => x.IdeiasIdealizadas)
                .Map(x =>
                    {
                        x.ToTable("IdeiasUsuarios");
                        x.MapLeftKey("idIdeia");
                        x.MapRightKey("idUsuario");
                    });

            this.HasMany(x => x.Categorias)
                .WithMany(x => x.Ideias)
                .Map(x =>
                    {
                        x.ToTable("IdeiasComCategorias");
                        x.MapLeftKey("idIdeia");
                        x.MapRightKey("idCategoria");
                    });
        }
    }
}