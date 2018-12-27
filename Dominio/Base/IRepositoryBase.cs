using System.Collections.Generic;

namespace PDV.Dominio.Base
{
    public interface IRepositoryBase<T> : IRepository where T : EntidadeBase
    {
        void Gravar(T objeto);
        List<T> ObterTodos();
    }
}
