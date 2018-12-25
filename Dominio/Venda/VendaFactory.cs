using System;

namespace PDV.Dominio.Venda
{
    public class VendaFactory
    {
        public decimal ValorTotal;
        public decimal ValorRecebido;

        public Venda Criar()
        {
            if (ValorRecebido < ValorTotal)
                throw new Exception("Valor recebido insuficiente.");

            return new Venda(ValorTotal, ValorRecebido)
            {
                Id = Guid.NewGuid()
            };
        }
    }
}
