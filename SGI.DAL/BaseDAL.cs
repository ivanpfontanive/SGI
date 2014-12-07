using SGI.Dominio.Entidades;
using SGI.Dominio.Interfaces.Repositorios;
using SGI.Infra.EF;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace SGI.DAL
{
    public abstract class BaseDAL<T> : IBaseDAL<T> where T : BaseDominio
    {
        protected IRepositorioContexto ContextoEF { get; set; }

        public virtual T Obter(int id)
        {
            return this.ContextoEF.Set<T>().Find(id);
        }

        public virtual IQueryable<T> ObterTodos()
        {
            return this.ContextoEF.Set<T>();
        }

        public virtual void Adicionar(T entidade)
        {
            try
            {
                this.ContextoEF.Set<T>().Add(entidade);
                this.ContextoEF.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (DbEntityValidationException ex)
            {
                throw;
            }
        }

        public virtual void Atualizar(T entidade)
        {
            try
            {
                this.ContextoEF.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (DbEntityValidationException ex)
            {
                throw;
            }
        }

        public virtual void Deletar(int id)
        {
            try
            {
                this.ContextoEF.Set<T>().Remove(this.Obter(id));
                //this.ContextoEF.ChangeTracker.Entries<T>();
                this.ContextoEF.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}