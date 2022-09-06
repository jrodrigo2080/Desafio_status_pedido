using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_status_pedido.Dtos
{
    public class PedidosDto
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
