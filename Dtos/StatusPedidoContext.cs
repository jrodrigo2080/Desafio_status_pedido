using Microsoft.EntityFrameworkCore;

namespace Desafio_status_pedido.Dtos
{
    public class StatusPedidoContext : DbContext
    {
        public StatusPedidoContext(DbContextOptions<StatusPedidoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public  DbSet<PedidosDto> Pedidos { get; set; }
    }
}
