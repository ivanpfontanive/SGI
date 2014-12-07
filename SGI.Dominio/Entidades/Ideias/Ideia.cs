using SGI.Dominio.Entidades.Usuarios;
using System;
using System.Collections.Generic;

namespace SGI.Dominio.Entidades.Ideias
{
    /// <summary>
    /// Define uma inovação para futuro projeto.
    /// </summary>
    public class Ideia : BaseDominio
    {
        public Ideia()
        {
            this.idealizadores = new List<Usuario>();
            this.categorias = new List<IdeiaCategoria>();
        }

        private ICollection<IdeiaCategoria> categorias;

        private ICollection<Usuario> idealizadores;

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Define uma prioridade para idéia. Baixa, Média, Alta.
        /// </summary>
        public Prioridade Prioridade { get; set; }

        /// <summary>
        /// Define uma posição para a ideia dentro de uma determinada prioridade.
        /// </summary>
        public int Ordem { get; set; }

        public int IdInseridoPor { get; set; }

        /// <summary>
        /// Usuário operador do sistema no momento do cadastro de uma ideia.
        /// </summary>
        public Usuario InseridoPor { get; set; }

        /// <summary>
        /// Usuários que colaboraram entre sí, idenfificaram e organizaram uma Inovação, Idéia.
        /// </summary>
        public virtual ICollection<Usuario> Idealizadores
        {
            get { return idealizadores; }
            set { idealizadores = value; }
        }

        /// <summary>
        /// Categorias de ideias. (Tecnologia, Agronegócio, Empresarial)
        /// </summary>
        public virtual ICollection<IdeiaCategoria> Categorias
        {
            get { return categorias; }
            set { categorias = value; }
        }
    }
}