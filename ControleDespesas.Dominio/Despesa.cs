using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ControleDespesas.Dominio
{
    public class Despesa
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
