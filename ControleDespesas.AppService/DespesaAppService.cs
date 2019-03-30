using ControleDespesas.AppService.DTO;
using ControleDespesas.AppService.Interface;
using ControleDespesas.Dominio;
using ControleDespesas.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDespesas.AppService
{
    public class DespesaAppService : IDespesaAppService
    {
        private readonly IDespesaRepository _despesaRepository;

        public DespesaAppService(IDespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }

        public async Task<Despesa> AddAsync(DespesaDTO obj)
        {
            var despesa = new Despesa()
            {
                Id = Guid.NewGuid(),
                Categoria = obj.Categoria,
                Descricao = obj.Descricao,
                Valor = obj.Valor,
                DataVencimento = obj.DataVencimento,
                DataPagamento = obj.DataPagamento
            };

            await _despesaRepository.AddAsync(despesa);

            return despesa;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _despesaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Despesa>> GetAllAsync()
        {
            return await _despesaRepository.GetAllAsync();
        }

        public async Task<Despesa> GetByIdAsync(Guid id)
        {
            return await _despesaRepository.GetByIdAsync(id);
        }

        public async Task<Despesa> UpdateAsync(Guid id, DespesaDTO obj)
        {
            var despesa = new Despesa()
            {
                Id = id,
                Categoria = obj.Categoria,
                Descricao = obj.Descricao,
                Valor = obj.Valor,
                DataVencimento = obj.DataVencimento,
                DataPagamento = obj.DataPagamento
            };

            await _despesaRepository.UpdateAsync(despesa);

            return await _despesaRepository.GetByIdAsync(id);
        }
    }
}
