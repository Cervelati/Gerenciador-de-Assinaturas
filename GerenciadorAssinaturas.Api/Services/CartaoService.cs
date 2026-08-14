using GerenciadorAssinaturas.Api.Data;
using GerenciadorAssinaturas.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorAssinaturas.Api.Services;

    public class CartaoService
    {
        private readonly GerenciadorDbContext _context;
        public CartaoService (GerenciadorDbContext context)
        {
            _context = context;
        }

        public async Task <Cartao> CriarCartaoAsync (Cartao cartao)
        {
            _context.Cartoes.Add(cartao);
            await _context.SaveChangesAsync();
            return cartao;
        }

        public async Task <List<Cartao>> ListarTodosCartoesAsync ()
        {
            return await _context.Cartoes.ToListAsync();
        }

        public async Task <Cartao> BuscarCartaoPorIdAsync (int id)
        {
            var cartaoBuscado = _context.Cartoes.FindAsync(id);
            if (cartaoBuscado == null)
            {
                throw new KeyNotFoundException($"Cartão {id} não encontrado");
            }

            return cartaoBuscado;
        }

        // TODO criar DTO de request e response para mudar o parametro Cartao
        //public async Task <Cartao> AtualizarCartaoAsync (int id, Cartao cartao)
        //{
        //    var cartaoBuscado = _context.Cartoes.FindAsync(id);
        //    if (cartaoBuscado == null)
        //    {
        //        throw new KeyNotFoundException ($"Cartão {id} não encontrado");
        //    }
        public async Task DeletarCartaoAsync (int id)
        {
            var cartaoBuscado = await _context.Cartoes.FindAsync(id);
            if (cartaoBuscado == null)
            {
                throw new KeyNotFoundException($"Cartão {id} não encontrado");
            }

            _context.Cartoes.Remove(cartaoBuscado);
            await _context.SaveChangesAsync();
        }
    }