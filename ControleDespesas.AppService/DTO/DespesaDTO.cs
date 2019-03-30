using System;

namespace ControleDespesas.AppService.DTO
{
    public class DespesaDTO
    {
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
