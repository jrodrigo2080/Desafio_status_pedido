using Desafio_status_pedido.Dtos;
using Desafio_status_pedido.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace Desafio_status_pedido.Repositories
{
    public class StatusPedidoRepository : IStatusPedido
    {
        public readonly StatusPedidoContext _context;
        public StatusPedidoRepository(StatusPedidoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PedidosDto>> Get()
        {
            var result = await _context.Pedidos.ToListAsync();
            return result;
        }

        public async Task<PedidosDto> Get(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public Task<IEnumerable<StatusPedidoDto>> GetPorcentagem()
        {
            return CalculaPorcentagem();
        }

        public StatusPedidoDto GetPorcentagemStatus(string status)
        {
            var pedido = new StatusPedidoDto();
            var quantidade =  from tabela in _context.Pedidos.FromSqlRaw($"Select * from Pedidos where status = '{status}'")  select tabela;           
            int count = quantidade.Count();

            pedido = CalculaPorcentagemStatus(count, status);
            return pedido;
        }

        public StatusPedidoDto CalculaPorcentagemStatus(int totalStatus, string status)
        {
            var pedido = new StatusPedidoDto();
            var Registro = from tabela in _context.Pedidos select tabela;
            int totalRegistro = Registro.Count();
            
           var porcentagem = RetornaPorcentagem(totalStatus, totalRegistro);
           pedido = new StatusPedidoDto
              {
                Porcentagem = porcentagem.ToString()+"%",
                Status = status
              };
           return pedido;           
               
        }

        public async Task<IEnumerable<StatusPedidoDto>> CalculaPorcentagem()
        {
            var pedido = new StatusPedidoDto();
            var Registro = from tabela in _context.Pedidos select tabela;
            int totalRegistro = Registro.Count();

            var closedOrder = from tabela in _context.Pedidos.FromSqlRaw($"Select * from Pedidos where status = 'ClosedOrder'") select tabela;
            int countClosedOrder = closedOrder.Count();

            var openOrder = from tabela in _context.Pedidos.FromSqlRaw($"Select * from Pedidos where status = 'OpenOrder'") select tabela;
            int countOpenOrder = openOrder.Count();

            var blockedOrder = from tabela in _context.Pedidos.FromSqlRaw($"Select * from Pedidos where status = 'BlockedOrder'") select tabela;
            int countBlockedOrder = blockedOrder.Count();

            var porcentagemBlockedOrder = RetornaPorcentagem(countBlockedOrder, totalRegistro);
            var porcentagemOpenOrder = RetornaPorcentagem(countOpenOrder, totalRegistro);
            var porcentagemClosedOrder = RetornaPorcentagem(countClosedOrder, totalRegistro);

            var list = new List<StatusPedidoDto>();

            list.Add(new StatusPedidoDto { Porcentagem = porcentagemOpenOrder.ToString() + "%", Status = "OpenOrder" });
            list.Add(new StatusPedidoDto { Porcentagem = porcentagemBlockedOrder.ToString() + "%", Status = "BlockedOrder" });
            list.Add(new StatusPedidoDto { Porcentagem = porcentagemClosedOrder.ToString() + "%", Status = "ClosedOrder" });


           return list;
            
        }

        public float RetornaPorcentagem(float totalStatus, float totalRegistro)
        {
            return (totalStatus * 100) / totalRegistro;
        }

        public async Task<PedidosDto> Post(PedidosDto Pedido)
        {
            _context.Add(Pedido);
            await _context.SaveChangesAsync();

            return Pedido;
        }

    }
}
