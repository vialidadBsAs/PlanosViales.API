﻿namespace Sistema_de_planos.Dominio.Entidades
{
    public partial class Plano
    {
        public int Id { get; set; }
        public int NumPlano { get; set; }
        public string Propietario { get; set; } = string.Empty;
        public double Arancel { get; set; }
        public DateTime FechaOriginal { get; set; }
        public int EstadoId { get; set; }
        public int? PartidoId { get; set; }

        public string? PartidoInmobiliario { get; set; } = String.Empty;
        public string? Tipo { get; set; }
        public Estado Estado { get; set; }
        public PartidosArba Partido { get; set; }
        public List<Historico> Historicos { get; set; } = new List<Historico>();
        public DateTime? FechaRetiro { get; set; }
        public string? NombreRetiro { get; set; }
        public string? Observaciones { get; set; }
        public string? Revisor { get; set; }
        public string? Prioridad { get; set; }

        



    }
}
