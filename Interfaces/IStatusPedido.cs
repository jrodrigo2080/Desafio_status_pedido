using Desafio_status_pedido.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_status_pedido.Interfaces
{
    public interface IStatusPedido
    {
        Task <IEnumerable<PedidosDto>> Get();
        Task <PedidosDto> Get(int id);
        Task <PedidosDto> Post(PedidosDto Pedido);
        StatusPedidoDto GetPorcentagemStatus(string  status);
        Task<IEnumerable<StatusPedidoDto>> GetPorcentagem();
    }
}
