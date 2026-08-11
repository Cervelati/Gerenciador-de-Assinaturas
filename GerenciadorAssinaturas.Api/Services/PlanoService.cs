using GerenciadorAssinaturas.Api.Models;
using GerenciadorAssinaturas.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorAssinaturas.Api.Services;

    // TODO: substituir Plano por CriarPlanoDto/PlanoDto quando os DTOs forem criados
    public class PlanoService
    {
        private readonly GerenciadorDbContext _context;
        public PlanoService (GerenciadorDbContext context)
        {
            _context = context;
        }

        public async Task <Plano> CriarPlanoAsync (Plano plano)
        {
            _context.Planos.Add(plano);
            await _context.SaveChangesAsync();
            return plano;
        }

        public async Task <List<Plano>> BuscarTodosPlanosAsync () 
        {
            return await _context.Planos.ToListAsync();
        }

        public async Task <Plano> BuscarPlanosIdAsync (int id)
        {
            var plano = await _context.Planos.FindAsync(id);
            if (plano == null)
            {
                throw new KeyNotFoundException($"Plano {id} não encontrado");
            }

            return plano;
        }

        public async Task <Plano> AtualizarPlanoAsync (int id, Plano planoAtualizado)
        {
            var planoBuscado = await _context.Planos.FindAsync(id);
            if (planoBuscado == null) 
            {
                throw new KeyNotFoundException($"Plano {id} não encontrado");
            }
            planoBuscado.Nome = planoAtualizado.Nome;
            planoBuscado.Preco = planoAtualizado.Preco;

            await _context.SaveChangesAsync();
            return planoAtualizado;
        }

        public async Task DeletarPlano (int id)
        {
            var planoDeletado = await _context.Planos.FindAsync(id);
            if (planoDeletado == null)
            {
                throw new KeyNotFoundException($"Plano {id} não encontrado");
            }

            _context.Planos.Remove(planoDeletado);
            await _context.SaveChangesAsync();
        }
    }