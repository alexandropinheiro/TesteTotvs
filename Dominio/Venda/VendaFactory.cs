using System;

namespace PDV.Dominio.Venda
{
    public class VendaFactory
    {
        private readonly decimal _valorTotal;
        private readonly decimal _valorRecebido;

        public VendaFactory(decimal valorTotal, decimal valorRecebido)
        {
            _valorTotal = valorTotal;
            _valorRecebido = valorRecebido;
        }

        public Venda Criar()
        {
            if (_valorRecebido < _valorTotal)
                throw new Exception("Valor recebido insuficiente.");

            return new Venda(_valorTotal, _valorRecebido)
            {
                Id = Guid.NewGuid()
            };
        }
    }
}
