using Microsoft.Extensions.DependencyInjection;
using PDV.Dominio.ValorMonetario;
using PDV.Ioc;
using System;
using System.Collections.Generic;

namespace PDV.Testes
{
    public abstract class BaseTeste : IDisposable
    {
        protected List<Valor> Valores;

        public BaseTeste(){            
            PreencheValores();

            IServiceCollection services = new ServiceCollection();
            InjecaoDeDependencia.RegisterServices(services);
        }

        public void Dispose()
        {
            //var valoresNaBase = _valorRepository.ObterTodos();
            //valoresNaBase.ForEach(x => _valorRepository.Excluir(x));
            //_uow.Commit();
        }

        public void PersisteValores()
        {
        //    Valores.ForEach(x => _valorRepository.Gravar(x));
        //    _uow.Commit();
        }

        public void PreencheValores()
        {
            Valores = new List<Valor>
            {
                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Nota,
                    ValorMonetario = 100,
                    DescricaoValor = "R$100,00"
                },

                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Nota,
                    ValorMonetario = 50,
                    DescricaoValor = "R$50,00"
                },

                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Nota,
                    ValorMonetario = 20,
                    DescricaoValor = "R$20,00"
                },

                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Nota,
                    ValorMonetario = 10,
                    DescricaoValor = "R$10,00"
                },

                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Moeda,
                    ValorMonetario = Convert.ToDecimal(0.5),
                    DescricaoValor = "R$0,50"
                },

                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Moeda,
                    ValorMonetario = Convert.ToDecimal(0.1),
                    DescricaoValor = "R$0,10"
                },

                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Moeda,
                    ValorMonetario = Convert.ToDecimal(0.05),
                    DescricaoValor = "R$0,05"
                },

                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Moeda,
                    ValorMonetario = Convert.ToDecimal(0.01),
                    DescricaoValor = "R$0,01"
                }
            };            
        }

        //[TearDown]
        //public void TearDown()
        //{

        //}
    }
}
