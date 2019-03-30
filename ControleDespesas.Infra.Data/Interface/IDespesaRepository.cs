using ControleDespesas.Dominio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDespesas.Infra.Data.Interface
{
    public interface IDespesaRepository
    {
        Task AddAsync(Despesa obj);
        Task<Despesa> GetByIdAsync(Guid id);
        Task<IEnumerable<Despesa>> GetAllAsync();
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Despesa obj);
    }
}
