using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PDV.Dominio.Base;
using PDV.Infra.Context;

namespace PDV.Infra.Repository
{
    public class Repository<TEntity> : IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        protected PdvContext _context { get; set; }
        protected DbSet<TEntity> DbSet;

        public Repository(PdvContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public virtual void Gravar(TEntity objeto)
        {
            DbSet.Add(objeto);
        }

        public virtual List<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }
    }
}
