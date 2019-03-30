using ControleDespesas.Dominio;
using ControleDespesas.Dominio.Config;
using ControleDespesas.Infra.Data.Context;
using ControleDespesas.Infra.Data.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesas.Infra
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly DbContext _context;

        public DespesaRepository(IOptions<DbSettingsConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task AddAsync(Despesa obj)
        {
            await _context.Despesas.InsertOneAsync(obj);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.Despesas.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Despesa>> GetAllAsync()
        {
            return await _context.Despesas.AsQueryable().ToListAsync();
        }

        public async Task<Despesa> GetByIdAsync(Guid id)
        {
            return await _context.Despesas.AsQueryable().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Despesa obj)
        {
            var filter = Builders<Despesa>.Filter.Eq(x => x.Id, obj.Id);

            var updateDefinition = Builders<Despesa>.Update
                .Set(x => x.Categoria, obj.Categoria)
                .Set(x => x.Descricao, obj.Descricao)
                .Set(x => x.Valor, obj.Valor)
                .Set(x => x.DataVencimento, obj.DataVencimento)
                .Set(x => x.DataPagamento, obj.DataPagamento);

            await _context.Despesas.UpdateOneAsync(filter, updateDefinition);
        }
    }
}
