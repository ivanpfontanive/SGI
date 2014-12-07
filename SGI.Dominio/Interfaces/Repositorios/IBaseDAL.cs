using SGI.Dominio.Entidades;
using System.Linq;

namespace SGI.Dominio.Interfaces.Repositorios
{
    public interface IBaseDAL<T> where T : BaseDominio
    {
        T Obter(int id);

        IQueryable<T> ObterTodos();

        void Adicionar(T entidade);

        void Atualizar(T entidade);

        void Deletar(int id);
    }
}