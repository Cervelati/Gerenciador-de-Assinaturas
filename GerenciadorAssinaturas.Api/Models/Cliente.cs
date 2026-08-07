namespace GerenciadorAssinaturas.Api.Models;

public class Cliente
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string CPF { get; set; }
    public required string Telefone { get; set; }
    public DateTime DataCriacao { get; set; }

    public ICollection<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
    public ICollection<Cartao> Cartoes { get; set; } = new List<Cartao>();
}