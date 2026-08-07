using GerenciadorAssinaturas.Api.Enums;

namespace GerenciadorAssinaturas.Api.Models;

    public class Assinatura
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public required StatusAssinatura Status { get; set; }

        public int PlanoId { get; set; }
        public required Plano Plano { get; set; }

        public int CartaoId { get; set; }
        public required Cartao Cartao { get; set; }

        public int ClienteId { get; set; }
        public required Cliente Cliente { get; set; }
    }