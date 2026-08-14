using GerenciadorAssinaturas.Api.Models;
using GerenciadorAssinaturas.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorAssinaturas.Api.Services;

    public class UsuarioService
    {
        private readonly GerenciadorDbContext _context;
        public UsuarioService (GerenciadorDbContext context)
        {
            _context = context;
        }

        public async Task <Usuario> CriarUsuarioAsync (Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task <List<Usuario>> ListarTodosUsuariosAsync ()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task <Usuario> ListarUsuarioPorIdAsync (int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"Usuário {id} não encontrado");
            }

            return usuario;
        }

        public async Task<Usuario> AtualizarUsuarioAsync(int id, Usuario usuarioAtualizado)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException($"Usuário {id} não encontrado");

            if (!string.IsNullOrWhiteSpace(usuarioAtualizado.Nome))
                usuario.Nome = usuarioAtualizado.Nome;

            if (!string.IsNullOrWhiteSpace(usuarioAtualizado.Email))
                usuario.Email = usuarioAtualizado.Email;

            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task AlterarSenhaAsync(int id, string senhaAtual, string novaSenha)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException($"Usuário {id} não encontrado");

            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(senhaAtual, usuario.HashSenha);
            if (!senhaCorreta)
                throw new UnauthorizedAccessException("Senha atual incorreta");

            usuario.HashSenha = BCrypt.Net.BCrypt.HashPassword(novaSenha);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarUsuarioAsync (int id)
        {
            var usuarioDeletado = await _context.Usuarios.FindAsync(id);
            if (usuarioDeletado == null)
            {
                throw new KeyNotFoundException($"Usuário {id} não encontrado");
            }

            _context.Usuarios.Remove(usuarioDeletado);
            await _context.SaveChangesAsync();
        }
    }