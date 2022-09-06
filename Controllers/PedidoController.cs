using Desafio_status_pedido.Dtos;
using Desafio_status_pedido.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio_status_pedido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IStatusPedido _statusPedido;
        public PedidoController(IStatusPedido statusPedido)
        {
            _statusPedido = statusPedido;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidosDto>> GetPedidos()
        {
            return await _statusPedido.Get();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosDto>> GetPedidos(int id)
        {
            return await _statusPedido.Get(id);
        }
        
        [HttpGet("pedido/{status}")]
        public StatusPedidoDto GetPorcentagemStatus(string status)
        {
            return  _statusPedido.GetPorcentagemStatus(status);
        }

        [HttpPost]
        public async Task<ActionResult<PedidosDto>> CreateOrder([FromBody] PedidosDto pedido)
        {
            var newOrder = await _statusPedido.Post(pedido);
            return pedido;
        }

        [HttpGet("pedido/get")]
        public Task<IEnumerable<StatusPedidoDto>> GetPorcentagem()
        {
            return _statusPedido.GetPorcentagem();
        }
    }
}
