namespace GerenciadorAssinaturas.Api.Models;

public class Cartao
{
    public int Id { get; set; }
    public required string NomeTitular { get; set; }
    public required string UltimosDigitos { get; set; }
    public required string Bandeira { get; set; }
    public DateTime DataCriacao { get; set; }

    public int ClienteId { get; set; }
    public required Cliente Cliente { get; set; }
}