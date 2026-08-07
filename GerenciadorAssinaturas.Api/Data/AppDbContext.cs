using Microsoft.EntityFrameworkCore;
using GerenciadorAssinaturas.Api.Models;

namespace GerenciadorAssinaturas.Api.Data;

    public class GerenciadorDbContext : DbContext {

        public GerenciadorDbContext (DbContextOptions <GerenciadorDbContext> options) 
        : base(options){}

        public DbSet <Cliente> Clientes {get; set;}
        public DbSet <Usuario> Usuarios {get; set;}
        public DbSet <Plano> Planos {get; set;}
        public DbSet <Assinatura> Assinaturas {get; set;}

    }