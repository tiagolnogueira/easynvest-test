using Easynvest.Test.Application.Interfaces;
using Easynvest.Test.Domain.Entities;
using Easynvest.Test.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easynvest.Test.Application.Services
{
    public class OrdemCompraService : BaseService, IOrdemCompraService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IOrdemCompraRepository _ordemCompraRepository;

        public OrdemCompraService(IClienteRepository clienteRepository,
                                  IProdutoRepository produtoRepository,
                                  IOrdemCompraRepository ordemCompraRepository,
                                  INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _ordemCompraRepository = ordemCompraRepository;
        }

        public async Task<Guid> RegistrarOrdemCompra(OrdemCompra ordemCompra)
        {
            var cliente = await _clienteRepository.ObterPorId(ordemCompra.ClienteId).ConfigureAwait(false);
            var produto = await _produtoRepository.ObterPorId(ordemCompra.ProdutoId).ConfigureAwait(false);

            if (ordemCompra.QuantidadeSolicitada <= 0)
                throw new InvalidOperationException("Quantidade solicitada não suficiente para compra.");

            if (produto.Estoque <= 0)
                throw new InvalidOperationException("Quantidade em estoque não suficiente para compra.");

            var valorOperacao = Math.Round(decimal.Parse(produto.PrecoUnitario) * ordemCompra.QuantidadeSolicitada, 2);
            if (valorOperacao > cliente.Saldo)
                throw new InvalidOperationException("Cliente não possui saldo suficiente para compra.");

            if (Math.Round(ordemCompra.QuantidadeSolicitada * decimal.Parse(produto.PrecoUnitario), 2) < produto.ValorMinimoDeCompra)
                throw new InvalidOperationException("Quantidade mínima não atendida para compra.");

            if (valorOperacao > produto.Estoque)
                throw new InvalidOperationException("Quantidade em estoque não suficiente para compra.");

            var novaOrdemDeCompra = new OrdemCompra
            {
                ClienteId = cliente.Id,
                ProdutoId = produto.Id,
                DataOperacao = DateTime.Now,
                PrecoUnitario = decimal.Parse(produto.PrecoUnitario),
                ValorOperacao = valorOperacao,
                QuantidadeSolicitada = ordemCompra.QuantidadeSolicitada
            };

            novaOrdemDeCompra = await _ordemCompraRepository.Adicionar(novaOrdemDeCompra).ConfigureAwait(false);
            return novaOrdemDeCompra;
        }

        public async Task<bool> AlterarStatudOrdemDeCompraParaEmAnalise(Guid ordemDeCompraId)
        {
            var ordemDeCompra = await _ordemCompraRepository.ObterPorId(ordemDeCompraId).ConfigureAwait(false);
            if (string.IsNullOrEmpty(ordemDeCompra.Id.ToString()))
                throw new InvalidOperationException("");

            try
            {
                ordemDeCompra.Status = OrdemCompraStatus.EmAnalise;
                await _ordemCompraRepository.Atualizar(ordemDeCompra).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

            return true;
        }

        public async Task<IEnumerable<OrdemCompra>> EnviarOrdensPendentes()
        {
            var ordenPendentes = await _ordemCompraRepository.ObterOrdensPendentes();

            ordenPendentes.ToList().ForEach(async op =>
            {
                try
                {
                    op.Status = OrdemCompraStatus.EmAnalise;
                    await _ordemCompraRepository.Atualizar(op).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
            return ordenPendentes;
        }
    }
}