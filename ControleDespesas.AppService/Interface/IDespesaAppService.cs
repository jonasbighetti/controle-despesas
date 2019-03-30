using ControleDespesas.AppService.DTO;
using ControleDespesas.Dominio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDespesas.AppService.Interface
{
    public interface IDespesaAppService
    {
        Task<Despesa> AddAsync(DespesaDTO obj);
        Task<Despesa> GetByIdAsync(Guid id);
        Task<IEnumerable<Despesa>> GetAllAsync();
        Task DeleteAsync(Guid id);
        Task<Despesa> UpdateAsync(Guid id, DespesaDTO obj);
    }
}
