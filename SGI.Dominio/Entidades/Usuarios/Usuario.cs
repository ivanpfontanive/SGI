using SGI.Dominio.Entidades.Ideias;
using System.Collections.Generic;

namespace SGI.Dominio.Entidades.Usuarios
{
    public class Usuario : BaseDominio
    {
        public Usuario()
        {
            this.ideiasIdealizadas = new List<Ideia>();
            this.ideiasInseridas = new List<Ideia>();
        }

        private ICollection<Ideia> ideiasInseridas;

        private ICollection<Ideia> ideiasIdealizadas;

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// Ideias que foram cadastradas no sistema pelo usuáiro.
        /// </summary>
        public virtual ICollection<Ideia> IdeiasInseridas
        {
            get { return ideiasInseridas; }
            set { ideiasInseridas = value; }
        }

        /// <summary>
        /// Ideias que foram identificadas e criadas pelo usuário.
        /// </summary>
        public virtual ICollection<Ideia> IdeiasIdealizadas
        {
            get { return ideiasIdealizadas; }
            set { ideiasIdealizadas = value; }
        }
    }
}