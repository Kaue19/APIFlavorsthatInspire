namespace Api.Models
{
    public class StatusDaEntregaModel
    {
        public int StatusDaEntregaId { get; set; }
        public int UsuarioId { get; set; }
        public int PedidoId { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
