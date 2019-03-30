using ControleDespesas.Dominio;
using ControleDespesas.Dominio.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ControleDespesas.Infra.Data.Context
{
    public class DbContext
    {
        private readonly IMongoDatabase _db;

        public DbContext(IOptions<DbSettingsConfig> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _db = client.GetDatabase(settings.Value.Database);

            CheckIndexContext();
        }

        public IMongoCollection<Despesa> Despesas => _db.GetCollection<Despesa>("Despesa");

        private void CheckIndexContext()
        {
            IMongoCollection<Despesa> collection = _db.GetCollection<Despesa>("Despesa");
        }
    }
}
