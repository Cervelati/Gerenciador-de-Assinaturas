using GerenciadorAssinaturas.Api.Models;
using GerenciadorAssinaturas.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorAssinaturas.Api.Services;

    public class ClienteService
    {
        private readonly GerenciadorDbContext _context;
        public ClienteService (GerenciadorDbContext context)
        {
            _context = context;
        }
        
        public async Task <Cliente> CriarClienteAsync (Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task <List<Cliente>> BuscarTodosClientesAsync ()
        {
            return await _context.Clientes.ToListAsync();   
        }

        public async Task <Cliente> BuscarClientePorIdAsync (int id)
        {
            var clienteBuscado = await _context.Clientes.FindAsync(id);
            if (clienteBuscado == null)
            {
                throw new KeyNotFoundException($"Cliente {id} não encontrado");
            }

            return clienteBuscado;
        }

        // TODO: Criar DTO de request e response, adicionar no lugar do parametro Cliente.
        public async Task <Cliente> AtualizarClienteAsync (int id, Cliente cliente)
        {
            var clienteBuscado = await _context.Clientes.FindAsync(id);
            if (clienteBuscado == null)
            {
                throw new KeyNotFoundException($"Cliente {id} não encontrado");
            }

            clienteBuscado.Nome = cliente.Nome;
            clienteBuscado.Email = cliente.Email;
            clienteBuscado.Telefone = cliente.Telefone;

            await _context.SaveChangesAsync();
            return clienteBuscado;
        }

        public async Task DeletarClienteAsync (int id)
        {
            var clienteBuscado = await _context.Clientes.FindAsync(id);
            if (clienteBuscado == null)
            {
                throw new KeyNotFoundException($"Cliente {id} não encontrado");
            }

            _context.Clientes.Remove(clienteBuscado);
            await _context.SaveChangesAsync();
        }
    }