namespace GerenciadorAssinaturas.Api.Models;

public class Plano
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required decimal Preco { get; set; }
    public DateTime DataCriacao { get; set; }

    public ICollection<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
}