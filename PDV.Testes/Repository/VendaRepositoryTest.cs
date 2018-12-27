using PDV.Dominio;
using PDV.Dominio.Venda;
using PDV.Infra;
using PDV.Infra.Repository;
using System;
using Xunit;

namespace PDV.Testes.Infra
{
    public class VendaRepositoryTest : TesteBase, IDisposable
    {
        private IVendaRepository _repository;
        private readonly IUnitOfWork _uow;

        public VendaRepositoryTest()
        {
            Setup();
            _repository = new VendaRepository(Context);
            _uow = new UnitOfWork(Context);
        }

        [Fact]
        public void Gravar_Venda()
        {
            #region Teste de insert e retornar 1 objeto
            var vendaFactory = new VendaFactory
            {
                ValorTotal = 100,
                ValorRecebido = 120
            };
            var venda = vendaFactory.Criar();

            _repository.Gravar(venda);
            _uow.Commit();

            var _vendas = _repository.ObterTodos();
            Assert.Single(_vendas);

            #endregion

            #region retornar 2 objetos
            var vendaFactory2 = new VendaFactory
            {
                ValorTotal = 50,
                ValorRecebido = 90
            };
            var venda2 = vendaFactory.Criar();

            _repository.Gravar(venda2);
            _uow.Commit();

            var _vendas2 = _repository.ObterTodos();

            Assert.Equal(2, _vendas2.Count);
            #endregion
        }
                
        public void Dispose()
        {
            var vendas = _repository.ObterTodos();
            foreach(var v in vendas)
                Context.Remove<Venda>(v);

            Context.SaveChanges();

            TearDown();
        }
    }
}
