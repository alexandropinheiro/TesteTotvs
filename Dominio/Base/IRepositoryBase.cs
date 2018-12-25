using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PDV.Dominio.Base
{
    public interface IRepositoryBase<T> : IRepository where T : EntidadeBase
    {
        void Atualizar(T objeto);
        void Gravar(T objeto);
        void Excluir(T objeto);
        IEnumerable<T> Obter(Expression<Func<T, bool>> condicao);
        T ObterPorId(Guid id);
        List<T> ObterTodos();
    }
}
