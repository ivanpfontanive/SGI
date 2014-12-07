using System.Collections.Generic;

namespace SGI.Dominio.Entidades.Ideias
{
    public class IdeiaCategoria : BaseDominio
    {
        private ICollection<Ideia> ideias;

        public virtual ICollection<Ideia> Ideias
        {
            get { return ideias; }
            set { ideias = value; }
        }

        public string Nome { get; set; }
    }
}