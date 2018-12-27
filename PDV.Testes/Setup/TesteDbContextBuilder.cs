using PDV.Infra.Context;

namespace PDV.Testes.Setup
{
    public static class TestDbContextBuilder
    {
        public static PdvContext BuildDbContext()
        {
            return new PdvContext(TestDbContextOptionsBuilder.BuildOptions());
        }
    }
}